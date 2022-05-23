using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubDoor : MonoBehaviour
{
  private Animator animator = null;
  private AudioSource audioSource = null;
  private bool clearGame = false;
  private float timer = 0f;

  private void Start()
  {
    animator = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
  }

  private void Update()
  {
    if (clearGame == true)
    {
      if (timer < 3f)
      {
        timer += Time.deltaTime;
      }
      else
      {
        SceneManager.LoadScene("MainMenu");
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      KeyItem keyItem = collision.GetComponent<KeyItem>();

      if (keyItem.GetKeyCount() == KeyItem.KEY_REQUIRE && clearGame == false)
      {
        clearGame = true;
        animator.Play("Open");
        audioSource.Play();
      }
    }
  }
}
