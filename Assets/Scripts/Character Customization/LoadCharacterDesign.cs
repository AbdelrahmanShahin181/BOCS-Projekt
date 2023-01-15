using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacterDesign : MonoBehaviour
{

    [SerializeField] private SO_CharacterColors characterColor;
    [SerializeField] private SO_Character_Body bodyPart;
    [SerializeField] private SO_Position position;
    
    public string[] colors = new string[] {"_CHair", "_CSkin", "_CShirt", "_CPants"};
    public string[] parts = new string[] {"_Hair", "_Body", "_Shirt", "_Pants"};
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++) {
            transform.GetComponent<SpriteRenderer>().material.SetColor(colors[i], characterColor.Colors[i]);
            transform.GetComponent<SpriteRenderer>().material.SetTexture(parts[i], bodyPart.BodyParts[i].Texture);
            
        }
        
        transform.GetComponent<PlayerLayerControl>().ChangeLayer(position.layer);
        transform.position = new Vector3(position.x, position.y, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Public void SetBodypart( int Index, String Name) {
        player.transform.GetComponent<SpriteRenderer>().material.SetTexture(Name, bodyPart.BodyParts[Index].Texture);
    }
}
