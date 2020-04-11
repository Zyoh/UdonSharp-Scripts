
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class JumpPads : UdonSharpBehaviour
{
    public GameObject referencePoint;
    public float threshold = 5.0f;
    private float jumpHeight;
    private bool inProx;
    public float augmentedJumpImpulse = 20;

    private void Update()
    {
        var dist = Vector3.Distance(Networking.LocalPlayer.GetPosition(), referencePoint.transform.position);
        if (dist < threshold)
        {
            if (!inProx) ProximityAction();
            inProx = true;
        }
        else
        {
            if (inProx) ExitProxAction();
            inProx = false;
        }
    }

    public void ProximityAction()
    {
        jumpHeight = Networking.LocalPlayer.GetJumpImpulse();
        Networking.LocalPlayer.SetJumpImpulse(augmentedJumpImpulse);
    }

    public void ExitProxAction()
    {
        Networking.LocalPlayer.SetJumpImpulse(jumpHeight);
    }
}
