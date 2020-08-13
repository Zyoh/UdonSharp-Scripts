
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnInteractTeleportPlayer : UdonSharpBehaviour
{
    public GameObject target;
    private VRCPlayerApi localPlayer;

    private void Start()
    {
        localPlayer = Networking.LocalPlayer;
    }
    
    public override void Interact()
    {
        if (target != null)
        {
            localPlayer.TeleportTo(target.transform.position, target.transform.rotation);
        }
    }
}
