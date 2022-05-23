using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      GameObject uiPause = Resources.Load<GameObject>("UIPause");
      Instantiate(uiPause);
    }
  }
}
