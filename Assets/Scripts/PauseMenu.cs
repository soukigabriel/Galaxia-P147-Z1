using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu sharedInstance;
    public GameObject pauseMenuParent, pauseMainMenu, optionsMenu, controles, HUD;

    const string MAIN_MENU_SCENE = "Main Menu";

    public AudioClip _beep;
    public AudioSource _source;

    public GameObject ScreenTransitionImage;
    public Animator screenTransition;
    public float transitionTime = 1f;

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
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ShowHUD()
    {
        HUD.SetActive(true);
    }

    public void HideHUD()
    {
        HUD.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuParent.SetActive(true);
        pauseMainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        controles.SetActive(false);
        HideHUD();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuParent.SetActive(false);
        ShowHUD();
    }

    public void ResumeButton()
    {
        _source.PlayOneShot(_beep);
        GameManager.sharedInstance.StartGame();
    }

    public void OptionsButton()
    {
        _source.PlayOneShot(_beep);
        HideMainMenu();
        ShowOptionsMenu();
        HideControls();
    }

    public void MainMenuButton()
    {
        ScreenTransitionImage.SetActive(true);

        GameManager.sharedInstance.MainMenu();
    }

    public void ControlsButton()
    {
        _source.PlayOneShot(_beep);
        ShowControls();
        HideMainMenu();
        HideOptionsMenu();
    }

    public void ExitButton()
    {
        _source.PlayOneShot(_beep);
        StartCoroutine(ExitGame());
    }

    public void BackToMainMenu()
    {
        ResumeGame();
        StartCoroutine(LoadLevel(MAIN_MENU_SCENE));
    }

    public void RegresarControles()
    {
        _source.PlayOneShot(_beep);
        ShowMainMenu();
        HideOptionsMenu();
        HideControls();
    }

    public void RegresarOptionsButton()
    {
        _source.PlayOneShot(_beep);
        HideOptionsMenu();
        ShowMainMenu();
        HideControls();
    }


    void ShowMainMenu()
    {
        pauseMainMenu.SetActive(true);
    }

    void HideMainMenu()
    {
        pauseMainMenu.SetActive(false);
    }

    void ShowOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    void HideOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

    void ShowControls()
    {
        controles.SetActive(true);
    }

    void HideControls()
    {
        controles.SetActive(false);
    }
/*
    void ExitGame()
    {
        Application.Quit();
    }
*/
    void playBeep()
    {
        _source.PlayOneShot(_beep);
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(transitionTime);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif


    }

    IEnumerator LoadLevel(string levelName)
    {
        //musicAnim.SetTrigger("musicFadeOut");
        screenTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }

}
