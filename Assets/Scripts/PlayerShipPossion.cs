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
        float HorizontalAxis = Input.GetAxis("Horizontal");
        print(HorizontalAxis);
        float VerticalAxix = Input.GetAxis("Vertical");
        shipMovementComponent.Rotate(HorizontalAxis);
           shipMovementComponent.MoveForward(VerticalAxix);

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKey(KeyCode.Space))
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
