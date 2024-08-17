using UnityEngine;
using System.Collections;

//SDS = Syed Daniyal Shahid
public class InstantiateObjects : MonoBehaviour
{
    public GameObject randomObjects;
    bool randomValue; 
    SpriteRenderer spriteColor;

    /// <summary>
    /// This script is used to instantiate objects with random properties
    /// and continuously respawn them at regular intervals.
    /// </summary>
    private void Start()
    {
        StartCoroutine(SpownCouroutine());
    }

    /// <summary>
    /// Coroutine to instantiate objects, set their properties based on a random value,
    /// and handle their destruction if needed. The coroutine restarts after a delay.
    /// </summary>
    IEnumerator SpownCouroutine()
    {
        // Instantiate a new object
        GameObject randomObj = Instantiate(randomObjects, transform.position, transform.rotation, transform); 

        // Get the sprite renderer component
        spriteColor = randomObj.GetComponent<SpriteRenderer>(); 

        // Decide randomly if the object is an enemy or destructible
        randomValue = Random.value > 0.5f; 

        if (randomValue)
        {
            // Configure object as an enemy
            randomObj.tag = "Enemy"; 
            randomObj.name = "Enemy"; 
            spriteColor.color = Color.red; 
        }
        else
        {
            // Configure object as destructible
            randomObj.tag = randomObj.name = "Destructible"; 
            spriteColor.color = Color.blue; 
            Destroy(randomObj, 50f); 
        }

        // Wait for 2 seconds before restarting the coroutine
        yield return new WaitForSeconds(2f); 

        // Restart the coroutine
        StopCoroutine(SpownCouroutine());
        StartCoroutine(SpownCouroutine()); 
    }
}
