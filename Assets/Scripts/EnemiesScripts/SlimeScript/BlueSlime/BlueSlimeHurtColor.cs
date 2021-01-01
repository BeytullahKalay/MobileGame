using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BlueSlimeHurtColor : MonoBehaviour
{
    public SpriteRenderer sr; //Blue slime sprite renderer
    public Material mat; //current sprite renderer material

    [ColorUsage(true, false)] public Color hdrColorWithoutAlpha = Color.white;

    Color originalHDRColor;

    private void Start()
    {
        originalHDRColor = mat.GetColor("_EmissionColor"); // Changing the color
    }

    private void Update()
    {

        mat.SetColor("_EmissionColor", hdrColorWithoutAlpha);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hdrColorWithoutAlpha = originalHDRColor;
        }

    }
}
