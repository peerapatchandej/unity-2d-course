using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
  private static GameObject bgm = null;

  void Start()
  {
    if (bgm == null)
    {
      bgm = gameObject;
      DontDestroyOnLoad(bgm);
    }
    else
    {
      Destroy(gameObject);
    }
  }
}
