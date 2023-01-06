using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Body", menuName = "Character Body")]
public class SO_Character_Body : ScriptableObject
{
    //public int bodyPartID;
    public SO_Body_Part[] BodyParts;  
}
