using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractNotification : MonoBehaviour
{
    [SerializeField]
    Image interactBackground;
    [SerializeField]
    TMP_Text interactText;
    public static bool show;
    Color bgColor, textColor;
    public static InteractNotification sharedInstance;

    // Start is called before the first frame update
    void Start()
    {
        bgColor = interactBackground.color;
        textColor = interactText.color;
    }

    // Update is called once per frame
    void Update()
    {
        SetElementsColor(show);
    }

    void SetElementsColor(bool show)
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            switch (show)
            {
                case true:
                    if(bgColor.a < 0.5)
                    {
                        bgColor.a += Time.deltaTime / 2f;
                        interactBackground.color = bgColor;
                    }
                    if(textColor.a < 1)
                    {
                        textColor.a += Time.deltaTime;
                        interactText.color = textColor;
                    }
                    break;

                case false:

                    if (bgColor.a > 0f)
                    {
                        bgColor.a -= Time.deltaTime / 2f;
                        interactBackground.color = bgColor;
                    }
                    if (textColor.a > 0f)
                    {
                        textColor.a -= Time.deltaTime;
                        interactText.color = textColor;
                    }

                    break;
            }
        }
    }
}
