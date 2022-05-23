using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
  [SerializeField]
  private GameObject[] healths = default;

  [SerializeField]
  private GameObject[] keys = default;

  public void UpdateHealth(int index, bool active)
  {
    healths[index].SetActive(active);
  }

  public void UpdateKey(int index)
  {
    keys[index].SetActive(true);
  }
}
