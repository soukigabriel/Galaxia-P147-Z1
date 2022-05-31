using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager sharedInstance;
    public Canvas MaquinaExpendedora;

/* precios actuales de cada articulo:
    0- combustible
    1- oxigeno
    2- arma
    3- enfriador
    4- herramientas
*/
    public int[] precios = {6,6,15,10,6};
    public int[] nivelArticulos = {1,1,0,1,1};

    public Text textoCombustibre, textoOxigeno, textoaArma, textoEnfriador, textoHerramientas, textoPlatziCoins;


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
        MaquinaExpendedora.enabled = (true);

        NarrativaManager.sharedInstance.eventoActual = ListaDeEventos.usarBitcoinsSinCurso;
        GameManager.sharedInstance.inEvent();
    }

    public void HideShop(){
        //if(MaquinaExpendedora.activeSelf)
            MaquinaExpendedora.enabled = (false);
    }
    
    //el id de cada articulo es el mismo que el array de los precios
    public void comprarArticulo( int idArticulo){
        if(precios[idArticulo] <= GameManager.sharedInstance.platziCoins && 
           CursosManager.sharedInstance.cursosTomados[1]){
            switch(idArticulo){
            case 0: //combustible
                // sumar al combustible y a su limite
                ResourcesManager.sharedInstance.combustible *= 1.5f;
                ResourcesManager.sharedInstance.maxCombustible *= 1.5f;

                // restando platzicoin y registrado compra
                GameManager.sharedInstance.platziCoins -= precios[idArticulo];
                textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();
                precios[idArticulo] *= 2;
                nivelArticulos[idArticulo]++;
                textoCombustibre.text = "(nvl: "+ nivelArticulos[idArticulo].ToString()
                                        +") Precio: "+ precios[idArticulo].ToString();
                break;
            case 1: //oxigeno
                // sumar al oxigeno y a su limite
                ResourcesManager.sharedInstance.oxigeno *= 1.5f;
                ResourcesManager.sharedInstance.maxOxigeno *= 1.5f;


                // restando platzicoin y registrado compra
                GameManager.sharedInstance.platziCoins-= precios[idArticulo];
                textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();
                precios[idArticulo] *= 2;
                nivelArticulos[idArticulo]++;
                textoOxigeno.text = "(nvl: "+ nivelArticulos[idArticulo].ToString()
                                        +") Precio: "+ precios[idArticulo].ToString();

                break;
            case 2: //arma

            // restando platzicoin y registrado compra, evitando una segunda compra
                if(!armaComprada){
                    armaComprada = true;
                    GameManager.sharedInstance.platziCoins-= precios[idArticulo];
                    textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();
                    textoaArma.text = "Agotado";

                }
                break;
            case 3: //enfriador
                ResourcesManager.sharedInstance.maxTemperatura *= 1.3f;
                ResourcesManager.sharedInstance.velocidadDeCalentado *= .8f;
                ResourcesManager.sharedInstance.velocidadDeCalentadoCohete *= .8f;

            // restando platzicoin y registrado compra
                GameManager.sharedInstance.platziCoins-= precios[idArticulo];
                textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();
                precios[idArticulo] *= 2;
                nivelArticulos[idArticulo]++;
                textoEnfriador.text = "(nvl: "+ nivelArticulos[idArticulo].ToString()
                                        +") Precio: "+ precios[idArticulo].ToString();
                break;
            case 4: //herramientas

            // restando platzicoin y registrado compra, evitando una segunda compra
                if(!herramientasCompradas){
                    herramientasCompradas = true;
                    NarrativaManager.sharedInstance.objetosClave[0] = true;
                    GameManager.sharedInstance.platziCoins-= precios[idArticulo];
                    textoPlatziCoins.text = "PlatiZoins: " + GameManager.sharedInstance.platziCoins.ToString();                    
                    textoHerramientas.text = "Agotado";                   
                }
                break;
        }
        }
    }

    public void BotonSalir(){
        HideShop();
        GameManager.sharedInstance.StartGame();   
    }

}
