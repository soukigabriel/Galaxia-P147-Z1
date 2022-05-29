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
    public GameObject Cortina;
    public Slider barraProgreso;
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
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

    public void ShowCursosMenu(){
        MenuCursosCanvas.enabled = (true);
        this.platziCoins.text = "PlatziCoins: " + GameManager.sharedInstance.platziCoins.ToString();
        this.platziRank.text = "PlatziRank: " + GameManager.sharedInstance.platziRank.ToString();
        
        
        if(cursosTomados[0])
            cursocohete.gameObject.GetComponent<Image>().color = Color.green;
        if(cursosTomados[1])
            cursobitcoin.gameObject.GetComponent<Image>().color = Color.green;
        if(cursosTomados[2])
            cursohacker.gameObject.GetComponent<Image>().color = Color.green;
        
        Cortina.SetActive(false);
    }
    public void HideCursosMenu(){
        //if(MenuCursosCanvas.activeSelf)
            MenuCursosCanvas.enabled = (false);
        //MinijuegoQuiz.SetActive(false);
        //MenuCursosCanvas.GetComponentInChildren();
    }

    public void TomarCursoCohetes(){
        if(!cursosTomados[0] && GameManager.sharedInstance.platziRank >= 300
        && GameManager.sharedInstance.currentGameState == GameState.courseMenu){
            Cortina.SetActive(true);
            BarraDeCargaManager.sharedInstance.activar("cohetes");
            /*MinijuegoQuiz.SetActive(true); // activa el canvas del quiz
            QuizManager.sharedInstance.ShowMinigame("cohetes"); // inicializa segun el curso
            MenuCursosCanvas.enabled = (false);*/
        }   
    }

    public void TomarCursoBitcoin(){
        if(!cursosTomados[1] && GameManager.sharedInstance.platziRank >= 700
            && GameManager.sharedInstance.currentGameState == GameState.courseMenu){
            Cortina.SetActive(true);
            BarraDeCargaManager.sharedInstance.activar("bitcoin");
            /*MinijuegoQuiz.SetActive(true);
            QuizManager.sharedInstance.ShowMinigame("bitcoin");
            MenuCursosCanvas.enabled = (false);*/
        }
    }

    public void TomarCursoHacker(){
        if(!cursosTomados[2] && GameManager.sharedInstance.platziRank >= 800 
            && GameManager.sharedInstance.currentGameState == GameState.courseMenu){
            Cortina.SetActive(true);
            BarraDeCargaManager.sharedInstance.activar("hacker");
            
            /*MinijuegoQuiz.SetActive(true);
            QuizManager.sharedInstance.ShowMinigame("hacker");
            MenuCursosCanvas.enabled = (false);*/
        }
    }

    public void BotonSalir(){
        HideCursosMenu();
        GameManager.sharedInstance.StartGame();   
    }

}
