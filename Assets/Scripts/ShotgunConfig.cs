using UnityEngine;

[CreateAssetMenu(fileName = "ShotgunConfig", menuName = "ScriptableObjects/Weapons/Shotgun", order = 2)]
public class ShotgunConfig : WeaponConfigration
{
    public int shotgunPellets = 5; // Number of pellets to fire
    public float spreadAngle = 15f; // Spread angle of the pellets

    /// <summary>
    /// Fires multiple pellets in a spread pattern from the specified fire point.
    /// </summary>
    /// <param name="firePoint">The point from which pellets are fired.</param>
    public override void Shoot(Transform firePoint)
    {
        for (int i = 0; i < shotgunPellets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            float spread = Random.Range(-spreadAngle, spreadAngle);
            bullet.transform.Rotate(0, 0, spread);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
        }
    }

  
}