using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager sharedInstance;
    public GameObject MaquinaExpendedora;

/* precios actuales de cada articulo:
    0- combustible
    1- oxigeno
    2- arma
    3- enfriador
    4- herramientas
*/
    public int[] precios = {6,6,15,10,6};

    public TextMeshPro textoCombustibre;
    public TextMeshPro textoOxigeno;
    public TextMeshPro textoaArma;
    public TextMeshPro textoEnfriador;
    public TextMeshPro textoHerramientas;
    public TextMeshPro textoPlatziCoins;
    public bool armaComprada = false, herramientasCompradas = false;



    private void Awake()
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


    public void ShowShop(){
        textoPlatziCoins.text = "PlatziCoins: " + GameManager.sharedInstance.platziCoins.ToString();
        MaquinaExpendedora.SetActive(true);
    }

    public void HideShop(){
        
    }
    
    //el id de cada articulo es el mismo que el array de los precios
    public void comprarArticulo( int idArticulo){
        switch(idArticulo){
            case 0: //combustible
                // sumar al combustible y a su limite
                GameManager.sharedInstance.platziCoins-= precios[idArticulo];
                textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();
                precios[idArticulo] *= 2;
                textoCombustibre.text = "Tanque de combustible\nPrecio: "+ precios[idArticulo].ToString();
                break;
            case 1: //oxigeno
                // sumar al oxigeno y a su limite
                GameManager.sharedInstance.platziCoins-= precios[idArticulo];
                textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();
                precios[idArticulo] *= 2;
                textoOxigeno.text = "Tanque de oxigeno\nPrecio: "+ precios[idArticulo].ToString();

                break;
            case 2: //arma
                if(!armaComprada){
                    armaComprada = true;
                    GameManager.sharedInstance.platziCoins-= precios[idArticulo];
                    textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();
                    textoaArma.text = "Arma anti-robots\nAgotado";

                }
                break;
            case 3: //enfriador
                GameManager.sharedInstance.platziCoins-= precios[idArticulo];
                textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();
                precios[idArticulo] *= 2;
                textoEnfriador.text = "Enfriador mejorado\nPrecio: "+ precios[idArticulo].ToString();
                break;
            case 4: //herramientas
                if(!herramientasCompradas){
                    herramientasCompradas = true;
                    GameManager.sharedInstance.platziCoins-= precios[idArticulo];
                    textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();                    textoHerramientas.text = "Herramientas para naves\nAgotado";                    
                }
                break;
        }
    }

    public void BotonSalir(){
        HideShop();
        GameManager.sharedInstance.StartGame();   
    }

}
