
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ToggleObject : UdonSharpBehaviour
{
    [Tooltip("This object will switch on/off when interacting with the object this script is attached to.")]
    public GameObject toggledObject;

    public override void Interact()
    {
        toggledObject.SetActive(!toggledObject.activeSelf);
    }
}
