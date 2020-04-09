
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerMods_Sharp : UdonSharpBehaviour
{

    private VRCPlayerApi playerLocal;
    public bool UseLegacyLocomotion = false;
    public float WalkSpeed = 3;
    public float RunSpeed = 6;
    public float JumpHeight = 3;

    void Start()
    {
        playerLocal = Networking.LocalPlayer;
        if (playerLocal == null) return;

        playerLocal.SetWalkSpeed(WalkSpeed);
        playerLocal.SetRunSpeed(RunSpeed);
        playerLocal.SetJumpImpulse(JumpHeight);
        if (UseLegacyLocomotion) playerLocal.UseLegacyLocomotion();
    }
}
