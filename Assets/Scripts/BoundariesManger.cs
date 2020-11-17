using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesManger : MonoBehaviour
{
    public static BoundariesManger Instance=null;
    Vector2 lastResolution;
  public   event Action OnScreenResolutionChanged;

  private Camera mainCamera;
    public Vector3 LeftBottom;
  public Vector3 RightUp;
     
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }  
    }

    private void Start()
    {
        mainCamera = Camera.main;
        LeftBottom = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        RightUp = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));
        lastResolution = new Vector2(Screen.width, Screen.height);
    }

    
    private void Update()
    {
        var currentRes = new Vector2(Screen.width, Screen.height);
        if (currentRes != lastResolution)
        {
            LeftBottom = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
            RightUp = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));
            OnScreenResolutionChanged?.Invoke();
            lastResolution = currentRes;
        }
    }
}
