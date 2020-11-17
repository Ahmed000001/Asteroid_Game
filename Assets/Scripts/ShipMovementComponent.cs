using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class ShipMovementComponent : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float angluarSpeed=60;
    private Rigidbody rigidbody;
   
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    public void MoveForward(float drive)
    {
        if (drive == 0)
        {
            StopShip();
            return;
        }
       rigidbody.AddForce(transform.forward * speed*drive, ForceMode.Impulse);
    }

     void StopShip()
    {
        
        rigidbody.velocity = Vector3.zero;
    }
   public void Rotate(float angle)
   {
            
      transform.Rotate(Vector3.up,angle*angluarSpeed*Time.deltaTime);


   }
}
