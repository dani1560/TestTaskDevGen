using UnityEngine;

//SDS

/// <summary>
/// This class makes the camera follow the player with a specified offset.
/// The camera position is updated in the `LateUpdate` method to smoothly follow the player.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }
}
