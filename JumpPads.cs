
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class JumpPads : UdonSharpBehaviour
{
    public GameObject referencePoint;
    public float threshold = 5.0f;
    public float augmentedJumpImpulse = 20;
    
    private float jumpHeight;
    private bool inProx = false;
    private VRCPlayerApi localPlayer;
    
    private void Start()
    {
        if (referencePoint == null)
        {
            referencePoint = this.gameObject;
        }
        localPlayer = Networking.LocalPlayer;
        jumpHeight = localPlayer.GetJumpImpulse();
    }

    private void Update()
    {
        var dist = Vector3.Distance(localPlayer.GetPosition(), referencePoint.transform.position);
        if (dist < threshold)
        {
            if (!inProx)
            {
                inProx = true;
                ProximityAction();
            }
        }
        else if (inProx)
        {
            inProx = false;
            ExitProxAction();
        }
    }

    private void ProximityAction()
    {
        localPlayer.SetJumpImpulse(augmentedJumpImpulse);
    }

    private void ExitProxAction()
    {
        localPlayer.SetJumpImpulse(jumpHeight);
    }
}
