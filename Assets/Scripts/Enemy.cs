using UnityEngine;

//SDS

/// <summary>
/// This script manages the behavior of an enemy, including health and destruction.
/// The enemy takes damage when hit by a bullet and is destroyed when health reaches zero.
/// </summary>
public class Enemy : MonoBehaviour
{
    public PlayerShooting playershooting;
    public int damage;
    public int health = 5;

    private void Start()
    {
        playershooting = FindObjectOfType<PlayerShooting>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        damage = playershooting.currentWeaponConfig.damage;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            HitByBullet();
        }
    }

    /// <summary>
    /// Reduces the enemy's health by one and logs the current health.
    /// Destroys the enemy if its health reaches zero.
    /// </summary>
    private void HitByBullet()
    {
        health -= damage;
        Debug.Log("Bullet Hit after: " + health);

        if (health == 0)
        {
            Debug.Log("Hits are 5 Destroying Enemy, the value is: " + health);
            Destroy(gameObject);
        }
    }
}
