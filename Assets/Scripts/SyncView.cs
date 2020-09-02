using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SyncView : NetworkBehaviour
{
    public override void OnStartClient()
    {
        if (!gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            GetComponent<FirstPersonController>().enabled = false;
            Destroy(transform.Find("Main Camera").gameObject);
        }

    }
}
