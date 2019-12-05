using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnCube : MonoBehaviour
{
    private static Random rng = new Random();
    private static Material glowMaterial;
    private static Texture glowSprite;
    private static Color[] colorSets =
    {
        new Color(0, 0, 1),
        new Color(0, 1, 0),
        new Color(0, 1, 1),
        new Color(1, 0, 0),
        new Color(1, 0, 1),
        new Color(1, 1, 0),
        new Color(1, 1, 1)
    };

    private bool spam;

    // Start is called before the first frame update
    void Start()
    {
        if(glowMaterial == null)
        {
            glowMaterial = (Material)Resources.Load<Material>("CrossWire/GlowEffect");
        }
        if(glowSprite == null)
        {
            glowSprite = (Texture)Resources.Load<Texture>("CrossWire/GlowSprite");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            spam = !spam;
        }

        if (spam)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(0, 5, 0);
                cube.AddComponent<Rigidbody>();

                Renderer renderer = cube.GetComponent<Renderer>();

                Color color = GetRandomColor();
                Material tmp = renderer.sharedMaterial = new Material(Shader.Find("MK/Glow/Selective/Sprites/Default"));
                tmp.SetColor("_Color", color);
                tmp.SetColor("_MKGlowColor", GetInverseColor(color));
                tmp.SetFloat("_MKGlowPower", GetRandomNumber(0.75f, 2.5f));
                tmp.SetTexture("_MKGlowTex", glowSprite);
            }
        }
    }

    private static Color GetInverseColor(Color color)
    {
        Color toRet = new Color(1 - color.r, 1 - color.g, 1 - color.b);
        if (toRet.r == 0 && toRet.g == 0 && toRet.b == 0)
            return new Color(1, 1, 1);
        return toRet;
    }

    private static Color GetRandomColor()
    {
        return colorSets[rng.Next(colorSets.Length)];
    }

    private static float GetRandomNumber(float low, float high)
    {
        return (float)(rng.NextDouble() * (high - low) + low);
    }

}
