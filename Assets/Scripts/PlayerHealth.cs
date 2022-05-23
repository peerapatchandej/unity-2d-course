using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField]
  private HUD hud = default;

  public const int HEALTH_MAX = 3;

  private Animator animator = null;
  private PlayerMovement playerMovement = null;
  private PlayerSound playerSound = null;
  private int health = HEALTH_MAX;
  private bool iFrameState = false;
  private float iFrameTime = 1f;
  private float timer = 0f;

  private void Start()
  {
    animator = GetComponent<Animator>();
    playerMovement = GetComponent<PlayerMovement>();
    playerSound = GetComponent<PlayerSound>();
  }

  private void Update()
  {
    if (iFrameState == true)
    {
      timer += Time.deltaTime;

      if (timer >= iFrameTime)
      {
        timer = 0f;
        iFrameState = false;
      }
    }
  }

  public void AddHealth()
  {
    hud.UpdateHealth(health, true);
    health++;
    playerSound.Play(PlayerSound.Clips.GetHealth);
  }

  public int GetHealth()
  {
    return health;
  }

  private void Hurt()
  {
    if (iFrameState == false)
    {
      health--;
      hud.UpdateHealth(health, false);

      if (health > 0)
      {
        iFrameState = true;
        animator.SetTrigger("Hurt");
      }
      else
      {
        playerMovement.Death();
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("EnemyHitbox"))
    {
      Hurt();
    }
  }
}
