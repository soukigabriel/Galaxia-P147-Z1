using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    // variables que usa el jetcpack
    public float potenciaContinua = 750f;
    public float potenciaCohete = 750f;
    public short temperaturaJetpack = 0;
    public short limiteCarga = 200;
    public bool[] activado = { false, false };
    public bool enUso {get; set;} = false;
    public float oxigeno = 1000, combustible = 1000;
    public float maxOxigeno = 1000, maxCombustible = 1000;

    //private PlayerMovement player;
    Rigidbody playerRB;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        activado[0] = activado[1] = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*------ Jetpack ---------------------------------------------------------------------------*/        
        if (Input.GetButton("Fire1")) // boton para la propulcion continua
            PropulsionContinua();


        if (Input.GetButton("Fire2")) // boton para la propulcion cohete
            PropulsionCohete();


        if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Fire2")) // deteccion de uso del yetcpack para que descanse
            enUso = false;
/*-------------------------------------------------------------------------------------------*/
    }

    private void FixedUpdate()
    {
        ActualizarJetpack(); // actualizaciones que ocupa el jetpack
    }

    void PropulsionContinua()
    {
        if ( this.temperaturaJetpack < limiteCarga && activado[0] && combustible > 0){
                playerRB.AddForce(Vector3.up * potenciaContinua, ForceMode.Force);
                temperaturaJetpack++;
                combustible--;
                enUso = true;
            }
    }

    void PropulsionCohete()
    {
        //Input.getButto
        if (this.temperaturaJetpack > limiteCarga && activado[1] && combustible > 0)
        {
            playerRB.AddForce(Vector3.up * potenciaCohete, ForceMode.Impulse);
            temperaturaJetpack = 0;
            enUso = false;
        }
        else{
            enUso = true;
            temperaturaJetpack++;
        }
    }

    public void ActualizarJetpack(){
        if(temperaturaJetpack > 0 && !enUso){
            temperaturaJetpack--;
        }
        //Aplicar aqui un Math.Clamp
        oxigeno--;
    }
}
