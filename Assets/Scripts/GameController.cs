using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
  [SerializeField]
  private Button pauseButton = default;

  private GameInputAction gameInputAction = null;
  private GameObject uiPause = null;

  private void Start()
  {
    gameInputAction = new GameInputAction();
    gameInputAction.GameController.Enable();
    gameInputAction.GameController.Pause.performed += PausePerformed;

    pauseButton.onClick.AddListener(CreateUIPause);
  }

  private void PausePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    if (obj.performed == true)
    {
      CreateUIPause();
    }
  }

  private void CreateUIPause()
  {
    if (uiPause == null)
    {
      uiPause = Instantiate(Resources.Load<GameObject>("UIPause"));
      uiPause.GetComponent<UIPause>().Setup(() =>
      {
        uiPause = null;
      });
    }
  }

  private void OnDestroy()
  {
    gameInputAction.GameController.Pause.performed -= PausePerformed;
  }

  //void Update()
  //{
  //  if (Input.GetKeyDown(KeyCode.Escape))
  //  {
  //    GameObject uiPause = Resources.Load<GameObject>("UIPause");
  //    Instantiate(uiPause);
  //  }
  //}
}
