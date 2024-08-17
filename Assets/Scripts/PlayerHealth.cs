using UnityEngine;

//SDS
public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Player's health value

    [SerializeField] private UIManager _uiManager; // Reference to UI manager

    /// <summary>
    /// Initializes the `uiManager` reference by finding it in the scene.
    /// </summary>
    private void Reset()
    {
        _uiManager = FindAnyObjectByType<UIManager>();
    }

    /// <summary>
    /// Reduces health when colliding with an enemy and updates the UI. 
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            _uiManager.playerHealth.value = health;
            if (health <= 0)
            {
                Debug.Log("Player Died, the value is: " + health);
                _uiManager.gameOver.gameObject.SetActive(true);
            }
        }
    }
}