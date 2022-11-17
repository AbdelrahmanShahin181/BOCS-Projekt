using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public enum MaskType {OFF, ON, GONE};

//[ExecuteInEditMode]
public class VisibilityShaderScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private TilemapRenderer tileRenderer;
    public MaskType type = MaskType.OFF;
    public float distance = 9;
    public static GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) tileRenderer = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) target = GameObject.FindGameObjectWithTag("Player");
        updateShader();
        toggleShader();
    }

    private int typeToInt()
    {
        if (distance <= 0 || type == MaskType.OFF) return 0;
        switch(type)
        {
            case MaskType.ON: return 1;
            case MaskType.GONE: return 2;
        }
        return 0;
    }

    private void toggleShader() 
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)) type = MaskType.OFF;
        if (Input.GetKeyDown(KeyCode.Keypad1)) type = MaskType.ON;
        //distance = Mathf.Clamp(distance + Input.GetAxis("Vertical"), -0.1f, 12);
    }

    private void updateShader()
    {
        if (spriteRenderer == null && tileRenderer == null || target == null) return;
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        if (spriteRenderer != null) spriteRenderer.GetPropertyBlock(mpb);
        if (tileRenderer != null) tileRenderer.GetPropertyBlock(mpb);

        mpb.SetFloat("_RenderDistance", distance);
        mpb.SetFloat("_MaskTargetX", target.transform.position.x);
        mpb.SetFloat("_MaskTargetY", target.transform.position.y);
        mpb.SetFloat("_MaskType", typeToInt());

        if (spriteRenderer != null) spriteRenderer.SetPropertyBlock(mpb);
        if (tileRenderer != null) tileRenderer.SetPropertyBlock(mpb);
    }
}
