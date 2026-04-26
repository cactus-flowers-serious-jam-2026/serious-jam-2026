using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioLibrary", menuName = "Scriptable Objects/Audio Library")]
public class AudioLibrary : ScriptableObject
{
    public AudioEntry[] audioEntries;

    public AudioEntry Get(string id) => Array.Find(audioEntries, entry => entry.id == id);
    
    
    
}
