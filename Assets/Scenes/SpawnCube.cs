using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{

    private bool spam = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            spam = !spam;

        if (spam)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(0, 5, 0);
            cube.AddComponent<Rigidbody>();
            cube.AddComponent<BoxCollider>();

            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            cubeRenderer.material.shader = Shader.Find("Legacy Shaders/VertexLit");
            cubeRenderer.material.SetColor("_Emission", Color.red);

            Light cubeLight = cube.AddComponent<Light>();
            cubeLight.color = Color.red;
            cubeLight.type = LightType.Point;
            cubeLight.range = 20;
        }
    }
}
