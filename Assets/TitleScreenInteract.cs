using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TitleScreenInteract : MonoBehaviour
{
    private static string enterGameName = "EnterGame";
    private static string exitGameName = "ExitGame";

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<VRTK_InteractableObject>().InteractableObjectUnused += new InteractableObjectEventHandler(OnUse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnUse(object sender, InteractableObjectEventArgs args)
    {
        Debug.Log("AAAAAA");
        string touched = gameObject.GetComponent<VRTK_InteractableObject>().name;
        if (enterGameName.Equals(touched))
        {
            Debug.Log("CCCCC");
            //  Application.LoadLevel("name of game scene");
        }
        else if (exitGameName.Equals(touched))
        {
            Debug.Log("BBBB");
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
