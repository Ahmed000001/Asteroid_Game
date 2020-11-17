using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;

    [SerializeField] private float damageAmount=1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBulletafteSeconds(lifeTime));
    }

    private void OnTriggerEnter(Collider other)
    {
       var damagable= other.gameObject.GetComponent<IDamagable>();
       if (damagable != null)
       {
           damagable.TakeDamage(damageAmount);
           Destroy(gameObject);
       }
        
    }

    IEnumerator DestroyBulletafteSeconds(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }
}
