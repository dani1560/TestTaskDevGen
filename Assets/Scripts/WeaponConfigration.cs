using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SDS

/// <summary>
/// This abstract class defines the configuration for weapons, including bullet speed,
/// fire rate, target radius, and bullet prefab. It provides an abstract method for shooting
/// and a default implementation for normal shooting.
/// </summary>
public abstract class WeaponConfigration : ScriptableObject
{
    public float bulletSpeed = 10;
    public float fireRate = 1;
    public float targetRadius = 10;
    public int damage = 1;
    public GameObject bulletPrefab;

    /// <summary>
    /// Abstract method to be implemented for specific shooting behavior.
    /// </summary>
    public abstract void Shoot(Transform firePoint);

    /// <summary>
    /// Instantiates a bullet prefab and sets its velocity based on the firePoint's direction.
    /// </summary>

    public GameObject NormalShoot(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        return bullet;
    }
  
}
