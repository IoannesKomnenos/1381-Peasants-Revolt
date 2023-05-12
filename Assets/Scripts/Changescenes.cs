using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescenes : MonoBehaviour
{
    public string[] sceneNames; // Array of scene names to load

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if left mouse button is pressed
        {
            int randomIndex = Random.Range(0, sceneNames.Length); // Choose a random scene index from the array
            SceneManager.LoadScene(sceneNames[randomIndex]); // Load the scene at the chosen index
        }
    }
}
