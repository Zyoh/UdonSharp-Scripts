
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnInteractUseStation : UdonSharpBehaviour
{
    private VRCPlayerApi localPlayer;
	private Collider collider;

    private void Start()
    {
        localPlayer = Networking.LocalPlayer;
		collider = (Collider) GetComponent(typeof(Collider));
    }
    
    public override void Interact()
    {
        localPlayer.UseAttachedStation();
    }
	
	public override void OnStationEntered()
    {
        collider.enabled = false;
    }

    public override void OnStationExited()
    {
        collider.enabled = true;
    }
}
