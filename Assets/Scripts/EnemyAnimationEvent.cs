using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
  private EnemySound enemySound = null;

  private void Start()
  {
    enemySound = GetComponent<EnemySound>();
  }

  public void PlayAttackSound()
  {
    enemySound.Play(EnemySound.Clips.Attack);
  }

  public void OnDeathAnimationEnd()
  {
    Destroy(gameObject);
  }
}
