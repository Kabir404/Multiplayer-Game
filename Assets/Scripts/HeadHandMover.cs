using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class HeadHandMover : NetworkBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform handContoller;

    [SerializeField] private Camera fpsCam;

    private Quaternion rotation;

    [Client]
    void LateUpdate()
    {
        if (hasAuthority)
        {
            head.transform.rotation = fpsCam.transform.rotation;

            rotation.eulerAngles = new Vector3(fpsCam.transform.position.x, -fpsCam.transform.position.y, fpsCam.transform.position.z); ;

            handContoller.transform.rotation = rotation;


        }
    }
}
