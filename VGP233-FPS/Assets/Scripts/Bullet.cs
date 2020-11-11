using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletDamage = 9.0f;
    private float random = 0.0f;

    private void Awake()
    {
        random = Random.Range(1.0f, 10.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(bulletDamage + random);
        }
    }
}
