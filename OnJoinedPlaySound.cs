
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnJoinedPlaySound : UdonSharpBehaviour
{
    public AudioSource audioSource;
   
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        audioSource.Play();
    }
}
