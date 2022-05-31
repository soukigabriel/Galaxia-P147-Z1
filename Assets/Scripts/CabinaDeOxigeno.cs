using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoDeCabina { nave, cabina }

public class CabinaDeOxigeno : MonoBehaviour
{
    BoxCollider m_collider;
    [SerializeField]TipoDeCabina estaCabina;
    public AudioSource respiracionPersonaje;
    public AudioSource recargaOxigeno;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame && other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if(estaCabina == TipoDeCabina.nave)
            {
                ResourcesManager.sharedInstance.RestablecerOxigeno();
            }
            else if(estaCabina == TipoDeCabina.cabina)
            {
                ResourcesManager.sharedInstance.RestablecerRecursos();
            }
            recargaOxigeno.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame  && other.tag == "Player")
        {
            respiracionPersonaje.Play();
            InteractNotification.show = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame  && other.tag == "Player")
        {
            respiracionPersonaje.Stop();
            InteractNotification.show = false;
        }
    }
}
