using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
  private bool foundPlayer = false;

  public bool CheckFoundPlayer()
  {
    return foundPlayer;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      foundPlayer = true;
      Debug.Log("Found Player!!");
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      foundPlayer = false;
      Debug.Log("Not Found Player!!");
    }
  }
}
