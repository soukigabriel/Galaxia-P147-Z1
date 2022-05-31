using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public static QuizManager sharedInstance;
    public GameObject canvasMinijuegoQuiz;
    public List<QuestionsAndAnswers> QnA, cohetes, bitcoin, hacker;
    public GameObject[] options;
    public int currentQuestion;
    List<QuestionsAndAnswers> currentQnA;

    public GameObject QuizPanel;
    public GameObject GoPanel;
    public GameObject BriefPanel;
    public GameObject LevelLoader;

    public Text QuestionTxt;
    public Text PlatziCoinsTxt;
    public Text PlatziRankTxt;
    public Text FeedbackTxt;

    int totalQuestions = 0;
    int idCurso = 0;
    public int score;

    public Animator transition;

    public float transitionTime = 1f;

    [SerializeField] private AudioClip _rightAnswer, _wrongAnswer;
    [SerializeField] private AudioSource _source;

void Awake()
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

    private void Start()
    {   
      // retry("");
        //generateQuestion();
    }    

     public void ShowMinigame(string sQnA){
        canvasMinijuegoQuiz.SetActive(true);
        retry(sQnA);
    }
    public void HideMinigame(){
        canvasMinijuegoQuiz.SetActive(false);
        //MenuCursosCanvas.GetComponentInChildren();
    }

    private void SetCurrentQnA(string QnAString){
        totalQuestions = 0;
        switch(QnAString){
            case "cohetes":
                currentQnA = cohetes;
                idCurso = 0;
                break;
            case "bitcoin":
                currentQnA = bitcoin;
                idCurso = 1;
                break;
            case "hacker":
                currentQnA = hacker;
                idCurso = 2;
                break;
            default:
                currentQnA = QnA;
                break;
        }
    }

    public void retry(string sQnA)
    { 
        SetCurrentQnA(sQnA);
        LevelLoader.SetActive(true);
        BriefPanel.SetActive(true);
        totalQuestions = currentQnA.Count;
        QuizPanel.SetActive(false);
        GoPanel.SetActive(false);
        score = 12;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       // StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void exit()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        StartCoroutine(CountUpToTarget(PlatziRankTxt,  0, 600,   0.5f, 0f, "+"));
        StartCoroutine(CountUpToTarget(PlatziCoinsTxt, 0, score, 0.1f, 0f, "+"));
        //PlatziCoinsTxt.text = "+" + score;
        //PlatziRankTxt.text = "+600";
        
        FeedbackTxt.text = "¡Felicidades Platzinauta! Has aprobado exitosamente el examen, disfruta de tu nuevo conocimiento y nunca pares de aprender, hoy más que nunca";
    
    }

    public void correct()
    {
        //when you answer right
        _source.PlayOneShot(_rightAnswer);
        //score += 1;
        //Debug.Log(score);
        currentQnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        score -= 1;
        //Debug.Log(score);
        _source.PlayOneShot(_wrongAnswer);
        //currentQnA.RemoveAt(currentQuestion);
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
            options[i].transform.GetChild(0).GetComponent<Text>().text = currentQnA[currentQuestion].Answers[i];

            if(currentQnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        BriefPanel.SetActive(false);
        QuizPanel.SetActive(true);
        if(currentQnA.Count > 0)
        {
            currentQuestion = Random.Range(0, currentQnA.Count);

            QuestionTxt.text = currentQnA[currentQuestion].Question;
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
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        //SceneManager.LoadScene(levelIndex);
        /*----- codigo que se ejecuta al final ----------------------*/
        GameManager.sharedInstance.platziRank += 600;
        GameManager.sharedInstance.platziCoins += score;
        CursosManager.sharedInstance.cursosTomados[idCurso] = true;
        CursosManager.sharedInstance.ShowCursosMenu();
        HideMinigame();
        HideMinigame();
        NarrativaManager.sharedInstance.eventoActual = ListaDeEventos.usandoSalaDeControl_AcabandoCurso;
        GameManager.sharedInstance.inEvent();
        /*------------------------------------------------------------*/
    }

    IEnumerator WaitForAnswers(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SetAnswers();
    }

    IEnumerator CountUpToTarget(Text field, int currentDisplayScore, int targetScore, float duration, float delay = 0f, string prefix = "")
    {
        if (field == PlatziCoinsTxt)
        {
            //Debug.Log("PlatziCoins! score = " + targetScore);
        }
        
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
