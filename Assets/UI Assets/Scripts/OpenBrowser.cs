using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OpenBrowser : MonoBehaviour
{
    public Text target;
    public string typeOfLink;

    public Texture2D mousePointer;

    private string url;
    
    public void OpenLink()
    {        
        string user = target.text;

        switch(typeOfLink)
        {
            case "email":
                url = "mailto:" + user;
                break;
            case "twitter":
                url = "https://twitter.com/" + user;
                break;
            case "linkedin":
                url = "https://www.linkedin.com/in/" + user;
                break;
            case "github":
                url = "https://github.com/" + user;
                break;
            case "artstation":                
                url = "https://www.artstation.com/" + user;
                break;
            case "instagram":
                break;
            default:
                break;
        }

        Debug.Log(url);

        Application.OpenURL(url);
    }

    void OnMouseOver()
    {
        Cursor.SetCursor(mousePointer, Vector2.zero, CursorMode.ForceSoftware);
    }
}
