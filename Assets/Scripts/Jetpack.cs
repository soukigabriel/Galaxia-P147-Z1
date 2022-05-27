using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    //public bool[] activado = { false, false };
    public bool enUso {get; set;} = false;
    public bool isCooling;
    public float potenciaContinua = .25f, potenciaCohete = 45f;
    Rigidbody playerRB;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        //activado[0] = activado[1] = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isCooling = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*------ Jetpack ---------------------------------------------------------------------------*/
        VerificarPropulsion();


        if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Fire2")) // deteccion de uso del yetcpack para que descanse
            enUso = false;
        /*-------------------------------------------------------------------------------------------*/
    }



    private void FixedUpdate()
    {
        ActualizarJetpack(); // actualizaciones que ocupa el jetpack
    }

    void VerificarPropulsion()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            PropulsionContinua();
            PropulsionCohete();
            VerificarTemperatura();
        }
    }

    void VerificarTemperatura()
    {
        if(ResourcesManager.sharedInstance.temperatura >= ResourcesManager.sharedInstance.maxTemperatura && !isCooling)
        {
            isCooling = true;
        }
        if(ResourcesManager.sharedInstance.temperatura <= 0f && isCooling)
        {
            isCooling = false;
        }
    }

    void PropulsionContinua()
    {

            if (Input.GetButton("Fire1") && ResourcesManager.sharedInstance.temperatura < ResourcesManager.sharedInstance.maxTemperatura /*&& activado[0]*/ && ResourcesManager.sharedInstance.combustible > 0  && isCooling == false)
            {
                playerRB.AddForce(Vector3.up * potenciaContinua, ForceMode.VelocityChange);
                ResourcesManager.sharedInstance.temperatura+=1.8f;
                ResourcesManager.sharedInstance.combustible-=2.5f;
                enUso = true;
            }
    }

    void PropulsionCohete()
    {

            if (Input.GetButtonDown("Fire2") && ResourcesManager.sharedInstance.temperatura < ResourcesManager.sharedInstance.maxTemperatura /*&& activado[1]*/ && ResourcesManager.sharedInstance.combustible > 0 && isCooling == false)
            {
                //playerRB.AddForce(Vector3.up * potenciaCohete, ForceMode.Impulse);
                playerRB.velocity = new Vector3(playerRB.velocity.x,playerRB.velocity.y + potenciaCohete, playerRB.velocity.z);
                enUso = true;
                ResourcesManager.sharedInstance.temperatura += 50f;
                ResourcesManager.sharedInstance.combustible -= ResourcesManager.sharedInstance.consumoPropulsionCohete;
            }
    }

    public void ActualizarJetpack(){
        if(ResourcesManager.sharedInstance.temperatura > 0 && !enUso /*&& isCooling*/){
            ResourcesManager.sharedInstance.temperatura--;
        }
        ResourcesManager.sharedInstance.oxigeno--;
    }
}
