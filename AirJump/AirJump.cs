
using System;
using ICSharpCode.SharpZipLib.Encryption;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AirJump : UdonSharpBehaviour
{
    private VRCPlayerApi playerLocal;
    private int executedJumps = 0;
    private Vector3 currentVelocity;
    private float newJumpVelocity;
    
    public int airJumps = 1;
    [Tooltip("Jump impulse is multiplied by this value for air jumps.")]
    public float airJumpPowerRatio = 1.5f;
    
    void Start()
    {
        playerLocal = Networking.LocalPlayer;
    }

    private void Update()
    {
        if (playerLocal.IsPlayerGrounded() == false)
        {
            if ((Input.GetButtonDown("Oculus_CrossPlatform_SecondaryThumbstick") || Input.GetButtonDown("Jump")) && executedJumps < airJumps)
            {
                executedJumps++;
                currentVelocity = playerLocal.GetVelocity();
                newJumpVelocity = playerLocal.GetJumpImpulse() * airJumpPowerRatio;
                playerLocal.SetVelocity(new Vector3(
                        currentVelocity.x,
                        newJumpVelocity,
                        currentVelocity.z
                    )
                );
            }
        }
        else
        {
            executedJumps = 0;
        }
    }
}
