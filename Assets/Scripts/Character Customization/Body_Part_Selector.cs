using UnityEngine;
using UnityEngine.UI;

public class Body_Part_Selector : MonoBehaviour
{
    // ~~ 1. Handles Body Part Selection Updates

    // Full Character Body
    [SerializeField] private SO_Character_Body characterBody;
    // Body Part Selections
    [SerializeField] private BodyPartSelection[] bodyPartSelections;
    [SerializeField] public GameObject player;
    public string[] parts = new string[] {"_Hair", "_Body", "_Shirt", "_Pants"};
    public string[] partIndexes = new string[] {"_HairIndex", "_SkinIndex", "_ShirtIndex", "_PantsIndex"};

    private void Start()
    {
        // Get All Current Body Parts
        for (int i = 0; i < bodyPartSelections.Length; i++)
        {
            GetCurrentBodyParts(i);
        }
    }

    public void NextBodyPart(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex < bodyPartSelections[partIndex].bodyPartOptions.Length - 1)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex++;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = 0;
            }
            //Debug.Log(bodyPartSelections[partIndex].bodyPartCurrentIndex);
            UpdateCurrentPart(partIndex);
        }
    }

    public void PreviousBody(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex > 0)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex--;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = bodyPartSelections[partIndex].bodyPartOptions.Length - 1;
            }

            UpdateCurrentPart(partIndex);
        }    
    }

    private bool ValidateIndexValue(int partIndex)
    {
        if (partIndex > bodyPartSelections.Length || partIndex < 0)
        {
            Debug.Log("Index value does not match any body parts!");
            return false;
        }
        else
        {
            return true;
        }
    }

    private void GetCurrentBodyParts(int partIndex)
    {
        // Get Current Body Part Name
        //bodyPartSelections[partIndex].bodyPartNameTextComponent.text = characterBuild.characterBodyParts[partIndex].bodyPart.bodyPartName;
        // Get Current Body Part Animation ID
        bodyPartSelections[partIndex].bodyPartCurrentIndex = characterBody.BodyParts[partIndex].bodyPartID;
        //Debug.Log(partIndex + " " + characterBuild.characterBodyParts[partIndex].bodyPart.bodyPartName);
    }

    private void UpdateCurrentPart(int partIndex)
    {
        // Update Selection Name Text
        //bodyPartSelections[partIndex].bodyPartNameTextComponent.text = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex].bodyPartName;
        // Update Character Body Part
        characterBody.BodyParts[partIndex] = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex];
        characterBody.indexes[partIndex] = bodyPartSelections[partIndex].bodyPartCurrentIndex;
        player.transform.GetComponent<SpriteRenderer>().material.SetTexture(parts[partIndex], characterBody.BodyParts[partIndex].Texture);
        player.transform.GetComponent<SpriteRenderer>().material.SetFloat(partIndexes[partIndex], bodyPartSelections[partIndex].bodyPartCurrentIndex);
        //Debug.Log(partIndex + " " + characterBuild.characterBodyParts[partIndex].bodyPart.bodyPartName);
    }
}

[System.Serializable]
public class BodyPartSelection
{
    public string bodyPartName;
    public SO_Body_Part[] bodyPartOptions;
    //public Text bodyPartNameTextComponent;
    [HideInInspector] public int bodyPartCurrentIndex;
}
