using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipShootingComponent))]
[RequireComponent(typeof(ShipMovementComponent))]
public class PlayerShipPossion : MonoBehaviour ,IDamagable
{
    private ShipMovementComponent shipMovementComponent;
    private ShipShootingComponent shipShootingComponent;
    private Camera mainCamera;

    void Start()
    {
        shipMovementComponent= GetComponent<ShipMovementComponent>();
        shipShootingComponent = GetComponent<ShipShootingComponent>();
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
#if  UNITY_STANDALONE
        float HorizontalAxis = Input.GetAxis("Horizontal");
     
        float VerticalAxix = Input.GetAxis("Vertical");
        shipMovementComponent.Rotate(HorizontalAxis);
           shipMovementComponent.MoveForward(VerticalAxix);


        if (Input.GetKey(KeyCode.Space))
        {

            shipShootingComponent.ShootMainCannon();
        }
 #elif UNITY_ANDROID || UNITY_IOS ||UNITY_EDITOR
  
        Vector2 axies = MobileController.Instance.GetjoyStickAxies();


        shipMovementComponent.Rotate(axies.x);
        shipMovementComponent.MoveForward(axies.y);


        if (MobileController.Instance.GetFireButton())
        {

            shipShootingComponent.ShootMainCannon();
        }



#endif




    }

    public void TakeDamage(float amount)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManger.Instance.StartNewRoundA();
    }
}
