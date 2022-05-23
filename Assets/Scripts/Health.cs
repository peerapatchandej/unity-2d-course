using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

      if (playerHealth.GetHealth() < PlayerHealth.HEALTH_MAX)
      {
        playerHealth.AddHealth();
        Destroy(gameObject);
      }
    }
  }
}
