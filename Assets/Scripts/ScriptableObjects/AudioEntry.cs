using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioLibrary", menuName = "Scriptable Objects/Audio Entry")]
public class AudioEntry : ScriptableObject
{
    public string id;
    public AudioClip audioClip;
    
}
