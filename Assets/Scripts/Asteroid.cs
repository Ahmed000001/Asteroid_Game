using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   [RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour ,IDamagable
{
    private Rigidbody rigidbody;
    [SerializeField] private float initTorque=1;
    [SerializeField] private float initImpulse=1;
    [SerializeField] private AsteroidType asteroidType;
    [SerializeField] private int pointsPerDestruction = 10;

    public void TakeDamage(float amount)
    {
      Destroy(this.gameObject);
      PlayerData.Instance.Score += pointsPerDestruction;
      AsteroidManger.Insatnce.OnAsteriodDead(asteroidType,transform);
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddTorque(transform.up*initTorque,ForceMode.Impulse);

        

        InvokeRepeating("AddForceRepated",5,10);
      
    }

    void AddForceRepated()
    {
        var originVector = transform.position - Vector3.zero;
        rigidbody.AddForce(-originVector.normalized * initImpulse, ForceMode.Impulse);
        transform.position=new Vector3(transform.position.x,0,transform.position.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ship"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject.CompareTag("ship"))
        {
            Destroy(other.gameObject);
        }
    }
}

public enum AsteroidType
{
    Big,Medium,Small
}