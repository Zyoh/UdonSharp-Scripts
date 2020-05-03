
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ToggleObject : UdonSharpBehaviour
{
    [Tooltip("Put object here")]
    public GameObject toggledObject;
    
    private void Start()
    {
        if (toggledObject == null)
        {
            toggledObject = this.gameObject;
        }
    }
    
    public override void Interact()
    {
        toggledObject.SetActive(!toggledObject.activeSelf);
    }
}
