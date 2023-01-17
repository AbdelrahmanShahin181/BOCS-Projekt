using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Body Part Options", menuName = "Character Body Part Options")]
public class SO_Body_Part_Options : ScriptableObject
{
    // Full Character Body
    //public SO_Character_Body characterBody;
    // Body Part Selections
    public BodyPartSelection[] bodyPartSelections;
}