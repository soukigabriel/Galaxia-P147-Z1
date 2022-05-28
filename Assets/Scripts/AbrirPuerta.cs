using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoDePuerta { puertaHackeable, puertaAbierta }

public class AbrirPuerta : MonoBehaviour
{
    Animator m_animator;
    public const string STATE_IS_OPEN = "isOpen";
    BoxCollider m_boxCollider;
    [SerializeField] TipoDePuerta m_tipoDePuerta;
    public bool haSidoAbierta;

    // Start is called before the first frame update
    void Start()
    {
        haSidoAbierta = false;
        m_animator = gameObject.GetComponent<Animator>();
        m_boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame && other.tag == "Player")
        {
            if (!haSidoAbierta)
            {
                InteractNotification.show = true;
            }
            else
            {
                m_animator.SetBool(STATE_IS_OPEN, true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame && other.tag == "Player")
        {
            if (!haSidoAbierta)
            {
                InteractNotification.show = false;
            }
            else
            {
                m_animator.SetBool(STATE_IS_OPEN, false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame && other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            switch (m_tipoDePuerta)
            {
                case TipoDePuerta.puertaAbierta:
                    haSidoAbierta = true;
                    m_animator.SetBool(STATE_IS_OPEN, true);
                    InteractNotification.show = false;

                    break;

                case TipoDePuerta.puertaHackeable:
                    if (ResourcesManager.sharedInstance.sabeHackear)
                    {
                        Debug.Log("Sabes Hackear");
                        haSidoAbierta = true;
                        m_animator.SetBool(STATE_IS_OPEN, true);
                        InteractNotification.show = false;

                    }
                    else
                    {
                        Debug.Log("NO SABES HACKEAR");
                    }
                    break;
            }
        }
    }

}
