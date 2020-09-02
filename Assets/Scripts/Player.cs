using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();


    [Client]
    // Update is called once per frame
    void Update()
    {
        if (hasAuthority)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(movement);
            }

        }
    }
}
