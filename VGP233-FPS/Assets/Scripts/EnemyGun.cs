using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Transform muzzleTransform;
    public GameObject bulletPrefab;
    public float bulletVelocity = 1000.0f;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(muzzleTransform.up * bulletVelocity, ForceMode.Force);
    }
}
