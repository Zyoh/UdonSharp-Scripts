
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class TextFormatting : UdonSharpBehaviour
{
    public Text textObject;
    [Tooltip("Strings of length less than or equal to this value will be at maximum font size.")]
    public int maxLineLength = 9;
    [Tooltip("Font size will be adjusted dynamically based on string length up to this value.")]
    public int maxFontSize = 300;

    public string userString = "";
    [Tooltip("My string formatting.")]
    public bool formatCustom = false;
    [Tooltip("C# DateTime.Now.ToString formatting.")]
    public bool formatDateTime = false;
    [Tooltip("Replace Unicode characters with similar ASCII if available.")]
    public bool forceAscii = false;
    [Tooltip("Reverts to default text if non-ASCII characters are detected. Enabling forceAscii will attempt to fix before this check.")]
    private bool skipBrokenNames = false; // Private until it actually works.

    private VRCPlayerApi playerLocal;
    private bool isEditor;
    
    
    private void Start()
    {
        playerLocal = Networking.LocalPlayer;
        isEditor = playerLocal == null;
    }

    private void Update()
    {
        var newString = userString;
        
        if (formatDateTime) newString = DateTime.Now.ToString(newString);
        if (formatCustom)
        {
            newString = newString.Replace("\\n", "\n");
            if (!isEditor)
            {
                newString = newString.Replace("%playerLocal%", $"{playerLocal.displayName}");
                newString = newString.Replace("%instanceDuration%", $"{Networking.GetServerTimeInSeconds()}");
            }
        }
        if (forceAscii)
        {
            // TODO: Actually make this be useful instead of only fixing my name lol.
            newString = newString.Replace('ë', 'e');
        }
        if (skipBrokenNames)
        {
            // TODO: Add more in-depth checking somehow.
            // TODO: Make it actually revert to default text.
            foreach (var letter in newString)
            {
                if ("eéêëèiïaâäàåcç".IndexOf(letter) != -1) return;
            }
        }

        textObject.text = newString;

        // Get length of first line to adjust size.
        // TODO: Get length of longest line instead of first one.
        var firstLineLength = 0;
        foreach (var letter in newString)
        {
            if (letter == '\n')
            {
                break;
            }
            firstLineLength++;
        }

        var newFontSize = maxLineLength/((float)firstLineLength + 1) * (float)maxFontSize;
        if (newFontSize > maxFontSize) newFontSize = maxFontSize;
        textObject.fontSize = (int)newFontSize;
    }
}
