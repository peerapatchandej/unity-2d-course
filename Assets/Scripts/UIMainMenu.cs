using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
  [SerializeField]
  private Button startGame = default;

  [SerializeField]
  private Button exitGame = default;

  [SerializeField]
  private AudioSource audioSource = default;

  private bool clickStart = false;
  private float timer = 0f;

  void Start()
  {
    startGame.onClick.AddListener(() =>
    {
      audioSource.Play();
      startGame.interactable = false;
      clickStart = true;
    });

    exitGame.onClick.AddListener(() =>
    {
      Application.Quit();
    });
  }

  private void Update()
  {
    if (clickStart == true)
    {
      if (timer < 1f)
      {
        timer += Time.deltaTime;
      }
      else
      {
        SceneManager.LoadScene("Game");
      }
    }
  }
}
