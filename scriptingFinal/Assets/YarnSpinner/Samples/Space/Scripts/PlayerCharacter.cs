﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Yarn.Unity.Example {
    public class PlayerCharacter : MonoBehaviour {

        public float minPosition = -5.3f;
        public float maxPosition = 5.3f;

        public float moveSpeed = 1.0f;

        public float interactionRadius = 2.0f;

        public float movementFromButtons {get;set;}

        /// Draw the range at which we'll start talking to people.
        void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;

            // Flatten the sphere into a disk, which looks nicer in 2D games
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1,1,1));

            // Need to draw at position zero because we set position in the line above
            Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
        }

        /// Update is called once per frame
        void Update () {

            // Remove all player control when we're in dialogue
            if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true) {
                return;
            }

            // Move the player, clamping them to within the boundaries 
            // of the level.
            var movement = Input.GetAxis("Horizontal");
            movement += movementFromButtons;
            movement *= (moveSpeed * Time.deltaTime);

            var newPosition = transform.position;
            newPosition.x += movement;
            newPosition.x = Mathf.Clamp(newPosition.x, minPosition, maxPosition);

            transform.position = newPosition;

            // Detect if we want to start a conversation
            if (Input.GetKeyDown(KeyCode.Space)) {
                CheckForNearbyNPC ();
            }
        }

        /// Find all DialogueParticipants
        /** Filter them to those that have a Yarn start node and are in range; 
         * then start a conversation with the first one
         */
        public void CheckForNearbyNPC ()
        {
            var allParticipants = new List<NPC> (FindObjectsOfType<NPC> ());
            var target = allParticipants.Find (delegate (NPC p) {
                return string.IsNullOrEmpty (p.talkToNode) == false && // has a conversation node?
                (p.transform.position - this.transform.position)// is in range?
                .magnitude <= interactionRadius;
            });
            if (target != null) {
                // Kick off the dialogue at this node.
                DialogueRunner.StartDialogue (target.talkToNode);
            }
        }
    }
}
