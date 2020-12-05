using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    public float playerX;
    public float startingY;
    public float startingZ;

    private Vector3 goalPos;

    private void Start()
    {
        calcPos();
        transform.position = goalPos;

    }

    void LateUpdate()
    {
        calcPos();
        transform.position = Vector3.Lerp(transform.position, goalPos, 0.1f);
    }

    void calcPos()
    {
        playerX = player.transform.position.x;

        if (playerX >= -44)
        {
            goalPos = new Vector3(-44, startingY, startingZ);
        }
        else if (playerX <= -57)
        {
            goalPos = new Vector3(-57, startingY, startingZ);
        }
        else
        {
            goalPos = new Vector3(playerX, startingY, startingZ);
        }
    }
}
