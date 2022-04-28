﻿/*
 * Zechariah Burrus
 * Assignment 9
 * Uses navmesh to make agent navigate to clicked position.
 * Also handles rotation for animation using ThirdPersonCharacter
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class PlayerController : MonoBehaviour {
    public Camera cam;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        //Third person character is controlling rotation for us so we don't
        //want the agent to update it as well
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                agent.destination = hit.point;
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance) {
            character.Move(agent.desiredVelocity, false, false);
        } else {
            character.Move(Vector3.zero, false, false);
        }
    }
}