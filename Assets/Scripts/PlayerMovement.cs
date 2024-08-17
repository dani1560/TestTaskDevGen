using UnityEngine;

//SDS

/// <summary>
/// This script handles the movement of the player object based on joystick input.
/// The player moves according to the joystick's position and speed settings.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Joystick joystick;

    private void Start()
    {
        joystick = FindAnyObjectByType<Joystick>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        Vector2 moveVelocity = moveInput.normalized * moveSpeed;
        transform.Translate(moveVelocity * Time.deltaTime);
    }
}