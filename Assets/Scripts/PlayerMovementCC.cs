using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class PlayerMovementCC : NetworkBehaviour
{
    [SerializeField] private float speed = 10.0F;
    [SerializeField] private float sprintMultiplier = 2.0F;
    [SerializeField] private float rotateSpeed = 3.0F;

    private float currentSpeed;

    public override void OnStartAuthority()
    {
        currentSpeed = speed;
    }

    [Client]
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = currentSpeed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = speed * sprintMultiplier;
        }
        else
        {
            currentSpeed = speed;
        }
    }


        
}
