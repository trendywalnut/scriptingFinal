using UnityEngine;
using UnityEngine.SceneManagement;
// Refrenced from: https://forum.unity.com/threads/how-to-change-the-players-start-location-to-where-they-left-the-scene.641518/

public class SaveAndRestorePosition : MonoBehaviour
{
    void Start() // Check if we've saved a position for this scene; if so, go there.
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
        {
            transform.position = SavedPositionManager.savedPositions[sceneIndex];
        }
    }

    void OnDestroy() // Unloading scene, so save position.
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SavedPositionManager.savedPositions[sceneIndex] = transform.position;
    }
}