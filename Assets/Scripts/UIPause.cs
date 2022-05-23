using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
  [SerializeField]
  private Button resume = default;

  [SerializeField]
  private Button mainMenu = default;

  private void Start()
  {
    Canvas canvas = GetComponent<Canvas>();
    canvas.worldCamera = Camera.main;

    Time.timeScale = 0f;

    resume.onClick.AddListener(() =>
    {
      Time.timeScale = 1f;
      Destroy(gameObject);
    });

    mainMenu.onClick.AddListener(() =>
    {
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");
      Destroy(gameObject);
    });
  }
}
