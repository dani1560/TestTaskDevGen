using UnityEngine;

//SDS = Syed Daniyal Shahid

/// <summary>
/// This script moves the object randomly within a specified radius.
/// The object continuously moves towards randomly set target positions.
/// </summary>
public class RandomMovement2D : MonoBehaviour
{
    public float speed = 2f;
    public float moveRadius = 10f;
    private Vector2 targetPosition;

    void Start()
    {
        SetRandomTargetPosition();  // Set initial target
    }

    void Update()
    {
        // Move towards target
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if reached
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();  // Set new target
        }
    }

    void SetRandomTargetPosition()
    {
        // Random position
        targetPosition = (Vector2)transform.position + Random.insideUnitCircle * moveRadius;
    }
}
