using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boundary: MonoBehaviour
{
    [SerializeField] private BoundaryTpe boundaryTpe;
  
    [SerializeField] private float Reflectiondelta;
    [SerializeField] private float deltBoundry;

    void Start()
    {
        PopulateBoundary();
        BoundariesManger.Instance.OnScreenResolutionChanged += PopulateBoundary;
    }

    


    private void PopulateBoundary()
    {
        var leftBottom = BoundariesManger.Instance.LeftBottom;
        var rightUp = BoundariesManger.Instance.RightUp;
        switch (boundaryTpe)
        {
            case BoundaryTpe.Up:
                    
                transform.position = new Vector3(0, 0, rightUp.z+deltBoundry);
                transform.localScale = new Vector3(rightUp.x * 3, 20, 0.5f);
                break;
            case BoundaryTpe.Down:

                transform.position = new Vector3(0, 0, leftBottom.z-deltBoundry);
                transform.localScale = new Vector3(rightUp.x * 3, 20, 0.5f);
                break;
            case BoundaryTpe.Left:
                transform.position = new Vector3(leftBottom.x-deltBoundry, 0, 0);
                transform.localScale = new Vector3(0.5f, 20, rightUp.z * 3);
                break;
            case BoundaryTpe.Right:
                transform.position = new Vector3(rightUp.x+deltBoundry, 0, 0);
                transform.localScale = new Vector3(0.5f, 20, rightUp.z *3);
                break;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        var objectpos = other.gameObject.transform.position;
        switch (boundaryTpe)
        {
            case BoundaryTpe.Up:
                if(objectpos.z<transform.position.z)
                    return;
                other.gameObject.transform.position=new Vector3(objectpos.x,0,-transform.position.z+Reflectiondelta);
                break;
            case BoundaryTpe.Down:
                if (objectpos.z > transform.position.z)
                    return;
                other.gameObject.transform.position = new Vector3(objectpos.x, 0, -transform.position.z-Reflectiondelta);
                break;
            case BoundaryTpe.Left:
                if (objectpos.x > transform.position.x)
                    return;
                other.gameObject.transform.position = new Vector3(-transform.position.x-Reflectiondelta, 0, objectpos.z);
                break;
            case BoundaryTpe.Right:
                if (objectpos.x < transform.position.x)
                    return;
                other.gameObject.transform.position = new Vector3(-transform.position.x+Reflectiondelta, 0, objectpos.z);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        
    }

    
}
  
public enum BoundaryTpe
{
    Up,Down,Left,Right
}
