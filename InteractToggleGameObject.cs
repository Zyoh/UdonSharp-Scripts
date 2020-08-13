using System;
using System.Text;
using System.Text.RegularExpressions;
using UdonSharp;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class InteractToggleGameObject : UdonSharpBehaviour
{
    [Tooltip("Put objects here")]
    public GameObject[] toggledObjects;

    public bool synced = false;
	
    [UdonSynced(UdonSyncMode.None)]
    private bool toggled = false;
	private bool localToggled = false;
    
	// Variables below used only for debugging purposes
    // public Text textObject;
    // private int onDeserializationCounter = 0;
    // private int syncedCounter = 0;
    // private int nonSyncedCounter = 0;
    // private int changedStateCounter = 0;
    
    public override void OnDeserialization()
    {
		if (localToggled != toggled) 
		{
			localToggled = toggled;
			ChangeState_InteractToggleGameObject();
			// onDeserializationCounter++;
		}
    } 

    public override void Interact()
    {
        if (synced)
        {	
			if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject))
			{
				Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
			}
			
			toggled = !toggled;
			localToggled = toggled;
			ChangeState_InteractToggleGameObject();
			// syncedCounter++;
        }
        else
        {
            ChangeState_InteractToggleGameObject();
			// nonSyncedCounter++;
        }
    }

    public void ChangeState_InteractToggleGameObject()
    {
        for (int i = 0; i < toggledObjects.Length; i++)
        {
            toggledObjects[i].SetActive(!toggledObjects[i].activeSelf);
        }
		// changedStateCounter++;
    }
    
	/*
    private void Update()
    {
        textObject.text = 
            "Synced: " + synced.ToString() + "\n" +
            "Toggled: " + toggled.ToString() + "\n" +
			"Logal toggled: " + localToggled.ToString() + "\n" +
            "OnDeserialization Counter: " + onDeserializationCounter.ToString() + "\n" +
            "Synced Counter: " + syncedCounter.ToString() + "\n" +
            "NonSynced Counter: " + nonSyncedCounter.ToString() + "\n" +
            "ChangedState Counter: " + changedStateCounter.ToString() + "\n";
    }
	*/
}
