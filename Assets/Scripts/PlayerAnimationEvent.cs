using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
  [SerializeField]
  private GameObject groundCheck = default;

  private PlayerSound playerSound = null;

  private void Start()
  {
    playerSound = GetComponent<PlayerSound>();
  }

  public void PlayRunSound()
  {
    playerSound.Play(PlayerSound.Clips.Run);
  }

  public void PlayAttackSound()
  {
    playerSound.Play(PlayerSound.Clips.Attack);
  }

  public void ActiveGroundCheck()
  {
    groundCheck.SetActive(true);
  }

  public void InActiveGroundCheck()
  {
    groundCheck.SetActive(false);
  }
}
