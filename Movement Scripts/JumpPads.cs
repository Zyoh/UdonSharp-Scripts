
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class JumpPads : UdonSharpBehaviour
{
    public GameObject referencePoint;
    [Tooltip("Range measured from referencePoint.")]
    public float range = 5.0f;
    [Tooltip("Jump power while in range.")]
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
    }

    private void Update()
    {
        var dist = Vector3.Distance(localPlayer.GetPosition(), referencePoint.transform.position);
        if (dist < range)
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
        jumpHeight = localPlayer.GetJumpImpulse();
        localPlayer.SetJumpImpulse(augmentedJumpImpulse);
    }

    private void ExitProxAction()
    {
        localPlayer.SetJumpImpulse(jumpHeight);
    }
}
