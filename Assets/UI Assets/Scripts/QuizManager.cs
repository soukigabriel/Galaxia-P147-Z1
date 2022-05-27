using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;
    public GameObject BriefPanel;
    public GameObject LevelLoader;

    public Text QuestionTxt;
    public Text PlatziCoinsTxt;
    public Text PlatziRankTxt;
    public Text FeedbackTxt;

    int totalQuestions = 0;
    public int score;

    public Animator transition;
    public Animator musicAnim;

    public float transitionTime = 1f;

    [SerializeField] private AudioClip _rightAnswer, _wrongAnswer, _beep, _pointCount;
    [SerializeField] private AudioSource _source;

    private void Start()
    {        
        LevelLoader.SetActive(true);
        totalQuestions = QnA.Count;
        QuizPanel.SetActive(false);
        GoPanel.SetActive(false);
        score = 12;
        //generateQuestion();
    }

    public void startGame()
    {
        _source.PlayOneShot(_beep);
        generateQuestion();
    }    

    public void retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void exitScene()
    {
        _source.PlayOneShot(_beep);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        _source.PlayOneShot(_pointCount, 0.5f);
        StartCoroutine(CountUpToTarget(PlatziRankTxt,  0, 600,   0.5f, 0f, "+"));
        //StartCoroutine(CountUpToTarget(PlatziCoinsTxt, 0, score, 0.1f, 0f, "+"));
        PlatziCoinsTxt.text = "+" + score;
        //PlatziRankTxt.text = "+600";
        
        FeedbackTxt.text = "¡Felicidades Usuario! Has aprobado exitosamente mi evaluación, ahora veo que comprendes a la perfección la anatomía de las Naves Interestelares de Clase Dragon01-YZ";
    
    }

    public void correct()
    {
        //when you answer right
        _source.PlayOneShot(_rightAnswer);
        //score += 1;
        Debug.Log(score);
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        score -= 1;
        Debug.Log(score);
        _source.PlayOneShot(_wrongAnswer);
        //QnA.RemoveAt(currentQuestion);
        //StartCoroutine(WaitForNext());
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            //Debug.Log("i = " + i + " | " + options[i].GetComponent<AnswerScript>().startColor);
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    private void generateQuestion()
    {
        
        BriefPanel.SetActive(false);
        QuizPanel.SetActive(true);
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            StartCoroutine(WaitForAnswers(0.01f));
            //SetAnswers();
        }
        else
        {
            //Debug.Log("Out of Questions");
            GameOver();
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        musicAnim.SetTrigger("musicFadeOut");
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


    IEnumerator WaitForAnswers(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SetAnswers();
    }

    IEnumerator CountUpToTarget(Text field, int currentDisplayScore, int targetScore, float duration, float delay = 0f, string prefix = "")
    {                
        if (delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }

        while (currentDisplayScore < targetScore)
        {
            
            currentDisplayScore += (int)(targetScore / (duration/Time.deltaTime)); 
            currentDisplayScore = Mathf.Clamp(currentDisplayScore, 0, targetScore);
            field.text = prefix + currentDisplayScore + "";
            yield return null;
        }
    }
}
