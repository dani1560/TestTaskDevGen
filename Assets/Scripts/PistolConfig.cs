using UnityEngine;

//SDS

[CreateAssetMenu(fileName = "PistolConfig", menuName = "ScriptableObjects/Weapons/Pistol", order = 1)]
public class PistolConfig : WeaponConfigration
{
     /// <summary>
    /// Implements the shooting behavior for the pistol, creating and firing a bullet.
    /// </summary>
    public override void Shoot(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
    }
}
