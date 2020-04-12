# UdonSharp-Scripts

Some scripts I've written for [Merlin's UdonSharp](https://github.com/Merlin-san/UdonSharp)


#### > Boost.cs

Player within range of the `referencePoint` gameobject will be thrown into direction of `targetPoint` with an assigned speed. 


#### > PlayerMods.cs

A script for altering player settings such as speed and jump. Allows to use old VRChat locomotion behaviour.


#### > InteractToggleGameObject.cs

Assign UdonBehaviour to the GameObject to be interacted with (aka used as a button) then place GameObject to toggle into the script variable.


#### > FollowPlayer.cs

Copies the local player's position and rotation onto the GameObject with the Udon Behaviour on it. Z+ of the GameObject will face where the player is facing.


#### > TextFormatting.cs

Very messy script, check source code to see if it could be useful to you. Main features being `DateTime.Now.ToString()` formatting and `formatCustom` will replace `%playerLocal%` with the local player's display name.


#### > JumpPads.cs

Players within range of the game object will have their jump power increased. Power is reverted once the player leaves the object's range.
