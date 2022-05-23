using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
  public enum Clips
  {
    Attack = 0,
    Death
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
