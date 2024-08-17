using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//SDS

/// <summary>
/// This class manages UI elements including game over status, player health slider,
/// and score display. It initializes references to these UI components in the `Reset` method.
/// </summary>
public class UIManager : MonoBehaviour
{
    public GameOver gameOver;
    public Slider playerHealth;
    public TextMeshProUGUI Score;
    
    /// <summary>
    /// Finds and assigns references to UI components.
    /// </summary>
    private void Reset()
    {
        gameOver = FindObjectOfType<GameOver>();
        playerHealth = GameObject.Find("HealthSlider").GetComponent<Slider>();
        Score = GameObject.Find("Panel/Score").GetComponent<TextMeshProUGUI>();
    }

}
