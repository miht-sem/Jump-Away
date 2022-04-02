using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.62f, 0.62f, 0.62f);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }
    private void OnMouseOver()
    {
        transform.localScale = new Vector3(0.62f, 0.62f, 0.62f);
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }
    private void OnMouseUpAsButton () 
    {
        switch (gameObject.name)
        {
            case "Restart":
                SceneManager.LoadScene ("start");
                break;
            case "Contact":
                Application.OpenURL("https://miht-sem.space");
                break;
            default:
                break;
        }
    }
}
