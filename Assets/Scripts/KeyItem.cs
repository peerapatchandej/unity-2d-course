using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
  [SerializeField]
  private HUD hud = default;

  public const int KEY_REQUIRE = 3;
  private int key = 0;
  private PlayerSound playerSound = null;

  private void Start()
  {
    playerSound = GetComponent<PlayerSound>();
  }

  public void AddKey()
  {
    hud.UpdateKey(key);
    key++;
    playerSound.Play(PlayerSound.Clips.GetKey);
  }

  public int GetKeyCount()
  {
    return key;
  }
}
