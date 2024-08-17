using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float timeRemaining = 5f; // Time for countdown (in seconds)
    public TextMeshProUGUI timeText; // Reference to the Text component

    /// <summary>
    /// Initializes the `timeText` reference by finding it among the child components.
    /// </summary>
    private void Reset()
    {
        timeText = GetComponentsInChildren<TextMeshProUGUI>()[1];
    }

    /// <summary>
    /// Deactivates the GameOver object at the start.
    /// </summary>
    private void Start()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Updates the countdown timer and reloads the current scene when the timer reaches zero.
    /// </summary>
    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeText();
        }
        else
        {
            timeRemaining = 0;
            UpdateTimeText();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// Updates the `timeText` component to display the rounded-up time remaining.
    /// </summary>
    void UpdateTimeText()
    {
        timeText.text = Mathf.Ceil(timeRemaining).ToString();
    }
}