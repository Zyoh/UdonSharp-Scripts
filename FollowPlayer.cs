
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class FollowPlayer : UdonSharpBehaviour
{
    private VRCPlayerApi playerLocal;
    
    private void Start()
    {
        playerLocal = Networking.LocalPlayer;
    }

    private void Update()
    {
        transform.SetPositionAndRotation(playerLocal.GetPosition(), playerLocal.GetRotation());
    }
}
