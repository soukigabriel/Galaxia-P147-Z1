using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu sharedInstance;
    public GameObject optionsMenu;
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        StartMainMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartMainMenu()
    {
        ShowMainMenu();
        HideOptionsMenu();
    }

    public void StartButton()
    {
        StartGame();
    }

    public void OptionsButton()
    {
        HideMainMenu();
        ShowOptionsMenu();
    }

    public void AtrasButton()
    {
        HideOptionsMenu();
        ShowMainMenu();
    }

    public void ExitButton()
    {
        ExitGame();
    }

    void StartGame()
    {
        EditorSceneManager.LoadScene("Level 1");
    }

    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
    }

    void HideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    void ShowOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    void HideOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

    void ExitGame()
    {
        Application.Quit();
    }


}
