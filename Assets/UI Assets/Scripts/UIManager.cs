using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject BriefPanel;
    public GameObject MenuPanel;
    public GameObject QuizIngenieriaInterestelar;

    public GameObject LevelLoader;

    [SerializeField] private AudioClip _beep;
    [SerializeField] private AudioSource _source;

    public Animator transition;
    public float transitionTime = 1f;

    public Animator musicAnim;
    
    private void Start()
    {
        LevelLoader.SetActive(true);
    }
    
    public void goToMenu()
    {
        _source.PlayOneShot(_beep);
        BriefPanel.SetActive(false);
        QuizIngenieriaInterestelar.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void goToIngenieriaInterestelar()
    {
        _source.PlayOneShot(_beep);
        MenuPanel.SetActive(false);
        QuizIngenieriaInterestelar.SetActive(true);

    }

    public void closeMenu()
    {
        _source.PlayOneShot(_beep);
        StartCoroutine(FadeOutScene());
        
    }

    IEnumerator FadeOutScene()
    {
        musicAnim.SetTrigger("musicFadeOut");
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Level 1");
        //EditorApplication.ExecuteMenuItem("Edit/Play");
        //Application.Quit();
    }
    
}
