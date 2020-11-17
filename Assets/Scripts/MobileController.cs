using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileController : MonoBehaviour
{
    public static MobileController Instance;
    private bool FireButtonDown;
    [SerializeField] private Joystick joystick;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetFireButton(bool state)
    {
        FireButtonDown = state;
    }

  public  bool GetFireButton()
    {
        return FireButtonDown;
    }

  public  Vector2 GetjoyStickAxies()
    {
        return new Vector2(joystick.Horizontal,joystick.Vertical);
    }

}
