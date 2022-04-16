using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "EnnemisScriptableObject", menuName = "EnnemisScriptableObject/Ennemis")]
public class SO_Ennemis : ScriptableObject
{
    public Sprite sprite;
    public float life;
    public float speed;
    public float degats;
}
