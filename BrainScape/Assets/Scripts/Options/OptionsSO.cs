using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "OptionManagerScriptableObject", menuName = "OptionManagerScriptableObject/OptionManager")]
public class OptionsSO : ScriptableObject
{
    public float volumeMusique;
    public float volumeSonore;
}
