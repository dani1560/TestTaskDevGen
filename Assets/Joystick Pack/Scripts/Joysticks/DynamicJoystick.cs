using UnityEngine;
using UnityEngine.EventSystems;

//SDS
public class DynamicJoystick : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1; // Movement threshold

    /// <summary>
    /// Initializes the joystick and hides the background.
    /// </summary>
    protected override void Start()
    {
        MoveThreshold = moveThreshold;
        base.Start();
        background.gameObject.SetActive(false);
    }

    /// <summary>
    /// Shows the background when the pointer is pressed.
    /// </summary>
    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    /// <summary>
    /// Hides the background when the pointer is released.
    /// </summary>
    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }

    /// <summary>
    /// Adjusts the joystick background position based on input magnitude.
    /// </summary>
    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            background.anchoredPosition += difference;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}