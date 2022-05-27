using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CursosManager : MonoBehaviour
{

    public static CursosManager sharedInstance;
    public Canvas MenuCursosCanvas;

    public Button cursocohete, cursobitcoin, cursohacker, salir;
    public Text platziCoins, platziRank;

    /*el array de cursosTomados representa si un curso ya ha sido tomado para no poder repetir, segun su posicion son: 
     1- cohetes 
     2- bitcoin
     3- hacker
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

    public void ShowCursosMenu(int platziCoins, int platziRank){
        this.platziCoins.text = "PlatziCoins: " + platziCoins.ToString();
        this.platziRank.text = "PlatziRank: " + platziRank.ToString();
        MenuCursosCanvas.enabled = true;
    }
    public void HideCursosMenu(){
        MenuCursosCanvas.enabled = false;
        //MenuCursosCanvas.GetComponentInChildren();
    }

    public void TomarCursoCohetes(){
        if(!cursosTomados[0])
            Debug.Log("curso de cohetes se curso");

        SceneManager.LoadScene("Quiz");
    }

    public void TomarCursoBitcoin(){

    }

    public void TomarCursoHacker(){

    }

    public void BotonSalir(){
        Debug.Log("salida");
        HideCursosMenu();
        GameManager.sharedInstance.StartGame();
        
    }

}
