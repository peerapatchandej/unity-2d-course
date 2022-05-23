using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("PlayerHitbox"))
    {
      EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
      enemyMovement.Death();
    }
  }
}
