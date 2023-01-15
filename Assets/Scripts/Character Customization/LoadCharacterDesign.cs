using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacterDesign : MonoBehaviour
{

    [SerializeField] private SO_CharacterColors characterColor;
    [SerializeField] private SO_Character_Body bodyPart;
    [SerializeField] private SO_Position position;
    [SerializeField] private SO_Body_Part_Options Options;

    
    public string[] colors = new string[] {"_CHair", "_CSkin", "_CShirt", "_CPants"};
    public string[] parts = new string[] {"_Hair", "_Body", "_Shirt", "_Pants"};
    public string[] partIndexes = new string[] {"_HairIndex", "_SkinIndex", "_ShirtIndex", "_PantsIndex"};
    // Start is called before the first frame update
    public void Start()
    {
        for(int i = 0; i < 4; i++) {
            transform.GetComponent<SpriteRenderer>().material.SetColor(colors[i], characterColor.Colors[i]);
            transform.GetComponent<SpriteRenderer>().material.SetTexture(parts[i], bodyPart.BodyParts[i].Texture);
            transform.GetComponent<SpriteRenderer>().material.SetFloat(partIndexes[i], bodyPart.indexes[i]);
            
        }
        
        transform.GetComponent<PlayerLayerControl>().ChangeLayer(position.layer);
        transform.position = new Vector3(position.x, position.y, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBodypart(string Name, int partIndex, int Index) {
        Debug.Log("Name: " + Name + " PartID: " + partIndex + " Index: " + Index);
        bodyPart.BodyParts[partIndex] = Options.bodyPartSelections[partIndex].bodyPartOptions[Options.bodyPartSelections[partIndex].bodyPartCurrentIndex];
        transform.GetComponent<SpriteRenderer>().material.SetTexture(Name, bodyPart.BodyParts[partIndex].Texture);
    }
}
