using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingComponent : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float bulletsrate=1;
    private bool shootagain = true;
    void Start()
    {
        
    }

    public void ShootMainCannon()
    {
        if (shootagain)
        {
            StartCoroutine(ShootPulse());
        }
    }

    void shootBullet()
    {
        var bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
    }
    IEnumerator ShootPulse()
    {
        shootBullet();
        shootagain = false;
        yield return  new WaitForSecondsRealtime(bulletsrate);
        shootagain = true;
    }

}
