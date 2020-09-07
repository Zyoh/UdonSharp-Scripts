
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class stayOnPlatform : UdonSharpBehaviour
{
    private VRCPlayerApi playerLocal;
    private Vector3 platformPosBuffer;
    private Collider platformCollider;
    private float playerRelativeHeight;
    private bool isAlignedToPlatform;
    private float lockedPlayerY = -10001;
    private Vector3 newPos;
    
    public GameObject platform;
    public Vector2 grabHeight = new Vector2(0.1f, 0);
    public bool lockPlayerY = false; 
    
    void Start()
    {
        playerLocal = Networking.LocalPlayer;
        if (platform == null)
        {
            platform = this.gameObject;
        }

        platformCollider = platform.GetComponent<Collider>();
    }

    private void Update()
    {
        Vector3 playerPosition = playerLocal.GetPosition();
        Quaternion playerRotation = playerLocal.GetRotation();
        Vector3 closestPoint = platformCollider.ClosestPoint(playerPosition);

        playerRelativeHeight = playerPosition.y - closestPoint.y;
        isAlignedToPlatform = (playerPosition.x == closestPoint.x) && (playerPosition.z == closestPoint.z);
        if (grabHeight.y <= playerRelativeHeight && playerRelativeHeight <= grabHeight.x && isAlignedToPlatform)
        {
            if (lockedPlayerY <= -10000)
            {
                lockedPlayerY = playerPosition.y;
            }
            
            // How much has platform moved since last frame?
            Vector3 platformPosDelta = platform.transform.position - platformPosBuffer;
            
            // Move player the same distance the platform moved
            newPos = playerPosition + platformPosDelta;

            if (lockPlayerY)
            {
                newPos.y = lockedPlayerY;
            }

            playerLocal.TeleportTo(newPos, playerRotation);
            
        }
        else
        {
            lockedPlayerY = -10001;
        }
        
        // Set remember pre-move position of platform for next frame
        platformPosBuffer = platform.transform.position;
    }
}
