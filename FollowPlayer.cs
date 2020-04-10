
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FollowPlayer : UdonSharpBehaviour
{
    private VRCPlayerApi playerLocal;
    void Start()
    {
        playerLocal = Networking.LocalPlayer;
    }

    private void Update()
    {
        transform.SetPositionAndRotation(playerLocal.GetPosition(), playerLocal.GetRotation());
    }
}
