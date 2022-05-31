using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverSceneManager : MonoBehaviour
{
    public AudioClip _beep;
    public AudioSource _source;

    public GameObject ScreenTransitionImage;
    public Animator screenTransition;
    public float transitionTime = 1f;

    public Animator musicAnim;


    void Start()
    {
        ScreenTransitionImage.SetActive(true);
    }

    public void Retry()
    {
        _source.PlayOneShot(_beep);
        StartCoroutine(LoadLevel("Level 1"));
        //EditorSceneManager.LoadScene("Level 1");
    }

    public void StartScreen()
    {
        _source.PlayOneShot(_beep);
        StartCoroutine(LoadLevel("Main Menu"));
        //EditorSceneManager.LoadScene("Main Menu");
    }
    
    public void ExitButton()
    {        
        _source.PlayOneShot(_beep);
        StartCoroutine(ExitGame());
        //Application.Quit();
    }

    IEnumerator ExitGame()
    {
        musicAnim.SetTrigger("musicFadeOut");
        screenTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator LoadLevel(string levelName)
    {
        musicAnim.SetTrigger("musicFadeOut");
        screenTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);

    }
}
