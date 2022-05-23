using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
  public enum Clips
  {
    Run = 0,
    Jump,
    Land,
    Attack,
    Death,
    GetKey,
    GetHealth
  }

  [SerializeField]
  private AudioSource audioSource = default;

  [SerializeField]
  private AudioClip[] audioClips = default;

  public void Play(Clips clip)
  {
    audioSource.PlayOneShot(audioClips[(int)clip]);
  }
}
