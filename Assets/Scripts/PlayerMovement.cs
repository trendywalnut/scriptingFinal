using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgent;

    public GameObject dialogue;
    private bool textShowing = false;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        dialogue = GameObject.FindGameObjectWithTag("Dialogue");
        //Debug.Log(dialogue);
        //Debug.Log(textShowing);

        //textCheck();

        if (!textShowing)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
                {
                    myAgent.SetDestination(hitInfo.point);
                }

            }
        }

    }

    public void textCheck()
    {
        if (dialogue.active)
        {
            textShowing = true;
        }
        else
        {
            textShowing = false;
        }
    }
}
