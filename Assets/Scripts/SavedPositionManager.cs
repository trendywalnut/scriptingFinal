using UnityEngine;
using System.Collections.Generic;
// Refrenced from: https://forum.unity.com/threads/how-to-change-the-players-start-location-to-where-they-left-the-scene.641518/
public static class SavedPositionManager // Static class to remember player positions per scene.
{
    public static Dictionary<int, Vector3> savedPositions = new Dictionary<int, Vector3>();
}