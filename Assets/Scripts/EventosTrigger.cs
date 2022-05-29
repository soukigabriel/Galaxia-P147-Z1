using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosTrigger : MonoBehaviour
{
    public ListaDeEventos eventoDeLaInstancia;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" &&
        !NarrativaManager.sharedInstance.eventosActivados[(int)eventoDeLaInstancia]
            )
        {

            other.attachedRigidbody.velocity = new Vector3(0, 0, 0);

            NarrativaManager.sharedInstance.eventoActual = eventoDeLaInstancia;
            GameManager.sharedInstance.inEvent();
        }
    }
}
