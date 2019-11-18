using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackEntry : MonoBehaviour
{
    private List<Collider> lastObjects = new List<Collider>();
    private int maxSize = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(lastObjects.Count == maxSize)
        {
            Collider last = lastObjects[0];
            if(last != null)
                Colorize(last, true);
            lastObjects.RemoveAt(0);
        }

        lastObjects.Add(other);
        Colorize(other, false);
    }

    public void OnTriggerExit(Collider other)
    {
        lastObjects.Remove(other);
        SetMatColor(other, Color.gray);
    }

    public void Colorize(Collider collider, bool red)
    {
        SetMatColor(collider, red ? Color.red : Color.green);
    }

    public void SetMatColor(Collider collider, Color color)
    {
        Renderer renderer = collider.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", color);
    }
}
