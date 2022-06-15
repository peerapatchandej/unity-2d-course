using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIJoystick : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    gameObject.SetActive(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.LinuxEditor);
  }
}
