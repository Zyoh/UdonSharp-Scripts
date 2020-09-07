#### > InteractToggleGameObject.cs

Assign UdonBehaviour to the GameObject to be interacted with (aka used as a button) then place GameObject to toggle into the script variable.


#### > FollowPlayer.cs

Copies the local player's position and rotation onto the GameObject with the Udon Behaviour on it. Z+ of the GameObject will face where the player is facing.


#### > OnInteractAnimationPlayer.cs

Triggers the animation from assigned `animator` when interacting with the object containing the script.
