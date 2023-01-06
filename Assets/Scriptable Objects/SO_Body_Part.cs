using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Body Part", menuName = "Character Body Part")]
public class SO_Body_Part : ScriptableObject
{
    public int bodyPartID;
    public Texture2D Texture;  
}