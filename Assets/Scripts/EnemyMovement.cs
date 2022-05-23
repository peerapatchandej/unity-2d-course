using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  private enum Direction
  {
    Left = -1,
    Right = 1
  }

  [SerializeField]
  private Transform pointA = default;

  [SerializeField]
  private Transform pointB = default;

  [SerializeField]
  private PlayerDetector playerDetector = default;

  [SerializeField]
  private EnemyAttackArea attackArea = default;

  [SerializeField]
  private float walkSpeed = 2f;

  [SerializeField]
  private float runSpeed = 4f;

  [SerializeField]
  private Direction dir = Direction.Left;

  private Animator animator = null;
  private BoxCollider2D bodyCollider = null;
  private Vector2 target = Vector2.zero;
  private Transform playerObj = null;
  private PlayerMovement playerMovement = null;
  private EnemySound enemySound = null;
  private bool foundPlayer = false;
  private bool isDeath = false;

  private void Start()
  {
    animator = GetComponent<Animator>();
    bodyCollider = GetComponent<BoxCollider2D>();
    enemySound = GetComponent<EnemySound>();

    playerObj = GameObject.Find("Player").transform;
    playerMovement = playerObj.GetComponent<PlayerMovement>();

    if (dir == Direction.Left) target = pointA.position;
    else if (dir == Direction.Right) target = pointB.position;
  }

  private void FixedUpdate()
  {
    if (isDeath == true)
    {
      return;
    }

    foundPlayer = playerDetector.CheckFoundPlayer() && playerMovement.CheckPlayerDeath() == false;
    animator.SetBool("FoundPlayer", foundPlayer);

    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && foundPlayer == false)
    {
      return;
    }

    if (attackArea.GetAttackState() == false)
    {
      if (target == (Vector2)pointA.position)
      {
        Flip((int)Direction.Left);
      }
      else if (target == (Vector2)pointB.position)
      {
        Flip((int)Direction.Right);
      }

      if (foundPlayer == false)
      {
        Move(target, walkSpeed);
      }
      else
      {
        if (transform.position.x < playerObj.position.x)
        {
          Flip((int)Direction.Right);
          target = pointB.position;
        }
        else if (transform.position.x > playerObj.position.x)
        {
          Flip((int)Direction.Left);
          target = pointA.position;
        }

        Move(target, runSpeed);
      }

      animator.SetBool("Attack", false);
      animator.SetBool("Run", foundPlayer);
    }
    else
    {
      animator.SetBool("Attack", true);
      animator.Play("Attack");
    }

    if (transform.position.x >= pointB.position.x)
    {
      animator.SetTrigger("Idle");
      target = pointA.position;
    }
    else if (transform.position.x <= pointA.position.x)
    {
      animator.SetTrigger("Idle");
      target = pointB.position;
    }
  }

  private void Move(Vector2 target, float speed)
  {
    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
  }

  private void Flip(float value)
  {
    transform.localScale = new Vector2(value, 1);
  }

  public void Death()
  {
    if (isDeath == false)
    {
      isDeath = true;
      bodyCollider.enabled = false;
      animator.SetTrigger("Death");
      enemySound.Play(EnemySound.Clips.Death);
    }
  }
}
