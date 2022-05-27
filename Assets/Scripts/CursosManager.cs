using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CursosManager : MonoBehaviour
{

    public static CursosManager sharedInstance;
    public Canvas MenuCursosCanvas;
    public GameObject MinijuegoQuiz;

    public Button cursocohete, cursobitcoin, cursohacker, salir;
    public Text platziCoins, platziRank;

    /*el array de cursosTomados representa si un curso ya ha sido tomado para no poder repetir, segun su posicion son: 
     0- cohetes 
     1- bitcoin
     2- hacker
     */
    public bool[] cursosTomados = {false, false, false};
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if(sharedInstance == null)
            sharedInstance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCursosMenu(){
        this.platziCoins.text = "PlatziCoins: " + GameManager.sharedInstance.platziCoins.ToString();
        this.platziRank.text = "PlatziRank: " + GameManager.sharedInstance.platziRank.ToString();
        MenuCursosCanvas.enabled = true;
        
        if(cursosTomados[0])
            cursocohete.gameObject.GetComponent<Image>().color = Color.green;
        if(cursosTomados[1])
            cursobitcoin.gameObject.GetComponent<Image>().color = Color.green;
        if(cursosTomados[2])
            cursohacker.gameObject.GetComponent<Image>().color = Color.green;
    }
    public void HideCursosMenu(){
        MenuCursosCanvas.enabled = false;
        //MenuCursosCanvas.GetComponentInChildren();
    }

    public void TomarCursoCohetes(){
        if(!cursosTomados[0] && GameManager.sharedInstance.platziRank >= 300){
            MinijuegoQuiz.SetActive(true); // activa el canvas del quiz
            QuizManager.sharedInstance.retry("cohetes"); // inicializa segun el curso
            MenuCursosCanvas.enabled = false;
            Debug.Log("hola");
        }   
    }

    public void TomarCursoBitcoin(){
        if(!cursosTomados[1] && GameManager.sharedInstance.platziRank >= 700){
            MinijuegoQuiz.SetActive(true);
            QuizManager.sharedInstance.retry("bitcoin");
            MenuCursosCanvas.enabled = false;
        }
    }

    public void TomarCursoHacker(){
        if(!cursosTomados[2] && GameManager.sharedInstance.platziRank >= 800){
            MinijuegoQuiz.SetActive(true);
            QuizManager.sharedInstance.retry("hacker");
            MenuCursosCanvas.enabled = false;
        }
    }

    public void BotonSalir(){
        HideCursosMenu();
        GameManager.sharedInstance.StartGame();
        
    }

}
