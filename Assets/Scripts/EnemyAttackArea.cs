using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
  private bool attackState = false;

  public bool GetAttackState()
  {
    return attackState;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      attackState = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      attackState = false;
    }
  }
}
