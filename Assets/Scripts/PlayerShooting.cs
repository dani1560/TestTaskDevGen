using UnityEngine;

//SDS

/// <summary>
/// This script manages the player's shooting mechanics, including targeting and firing weapons.
/// It allows the player to shoot at the nearest target and switch weapons.
/// </summary>
public class PlayerShooting : MonoBehaviour
{
    public WeaponConfigration currentWeaponConfig;
    public Transform firePoint;
    /// <summary>
    /// Initializes the firePoint to the player's transform.
    /// </summary>
    private void Start()
    {
        firePoint = transform;
    }

    /// <summary>
    /// Finds the nearest target and fires the current weapon at it.
    /// </summary>
    public void Shoot()
    {
        GameObject nearestTarget = FindNearestTarget();
        if (nearestTarget != null)
        {
            LookAt(nearestTarget.transform);
            currentWeaponConfig.Shoot(firePoint);
        }
    }

    /// <summary>
    /// Rotates the firePoint to face the target.
    /// </summary>
    /// <param name="target">The target to look at.</param>
    void LookAt(Transform target)
    {
        Vector2 direction = (target.position - firePoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Finds the nearest target within the specified radius.
    /// </summary>
    /// <returns>The nearest target game object, or null if no target is found.</returns>
    GameObject FindNearestTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, currentWeaponConfig.targetRadius);
        GameObject nearestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float distance = Vector2.Distance(transform.position, hit.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestTarget = hit.gameObject;
                }
            }
        }

        return nearestTarget;
    }

    /// <summary>
    /// Draws a gizmo representing the target detection radius in the editor.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, currentWeaponConfig.targetRadius);
    }

    /// <summary>
    /// Resets the firePoint rotation each frame.
    /// </summary>
    private void Update()
    {
        firePoint.rotation = Quaternion.identity;
    }

    /// <summary>
    /// Switches the current weapon to a new weapon configuration.
    /// </summary>
    /// <param name="newWeapon">The new weapon configuration to switch to.</param>
    public void SwitchWeapon(WeaponConfigration newWeapon)
    {
        currentWeaponConfig = newWeapon;
    }
}
