using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : NetworkBehaviour
{

    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 150f;

    [SerializeField] private Camera playerCamera = null;

    [Client]
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        RaycastHit hit;

       if ( Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward , out hit, range))
        {
           Health health = hit.transform.GetComponent<Health>();
           if(health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
