using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu sharedInstance;
    public GameObject optionsMenu, mainMenu, creditsPanel, mainLogo, copyright, controles;

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

        StartMainMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartMainMenu()
    {        
        ScreenTransitionImage.SetActive(true);
        ShowMainLogo();
        ShowCopyright();
        ShowMainMenu();
        HideOptionsMenu();
        HideCreditsPanel();
        HideControls();
    }

    public void StartButton()
    {
        _source.PlayOneShot(_beep);
        StartCoroutine(LoadLevel("Level 1"));
        //StartGame();
    }

    public void OptionsButton()
    {
        _source.PlayOneShot(_beep);
        HideMainMenu();
        ShowOptionsMenu();
        HideControls();
        ShowMainLogo();
        ShowCopyright();
    }

    public void CreditsButton()
    {
        _source.PlayOneShot(_beep);
        HideMainMenu();
        HideMainLogo();
        HideCopyright();
        ShowCreditsPanel();
    }    

    public void AtrasCreditsButton()
    {
        _source.PlayOneShot(_beep);
        HideCreditsPanel();
        ShowMainLogo();
        ShowCopyright();
        ShowMainMenu();
    }

    public void AtrasButton()
    {
        _source.PlayOneShot(_beep);
        HideOptionsMenu();
        ShowMainMenu();
    }

    public void ControlsButton()
    {
        _source.PlayOneShot(_beep);
        ShowControls();
        HideMainMenu();
        HideOptionsMenu();
        HideMainLogo();
        HideCreditsPanel();
        HideCopyright();
    }

    public void ExitButton()
    {
        _source.PlayOneShot(_beep);
        StartCoroutine(ExitGame());
        //ExitGame();
    }
/*
    void StartGame()
    {
        EditorSceneManager.LoadScene("Level 1");
    }
*/
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

    void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
    }

    void ShowMainLogo()
    {
        mainLogo.SetActive(true);
    }

    void HideMainLogo()
    {
        mainLogo.SetActive(false);
    }

    void ShowCopyright()
    {
        copyright.SetActive(true);
    }

    void HideCopyright()
    {
        copyright.SetActive(false);
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
        //musicAnim.SetTrigger("musicFadeOut");
        screenTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Application.Quit();
    }    

    IEnumerator LoadLevel(string levelName)
    {
        //musicAnim.SetTrigger("musicFadeOut");
        screenTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }

}
