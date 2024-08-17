using TMPro;
using UnityEngine;

//SDS

/// <summary>
/// This script handles bullet behavior, including detecting collisions
/// with enemies or destructible objects and updating the score.
/// </summary>
public class Bullet : MonoBehaviour
{
    UIManager uiManager;
    int scoreIncrease;
    TextMeshProUGUI Score;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        Score = uiManager.Score;
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            Destroy(gameObject);
            scoreIncrease = int.Parse(Score.text) + 1;
            Score.text = scoreIncrease.ToString();
        }
        else if (collision.gameObject.CompareTag("Destructible"))
        {
            Debug.Log("Destructible");
        }
    }
}
