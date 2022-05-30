using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventofinalTriggrt : MonoBehaviour
{
    public ListaDeEventos eventoDeLaInstancia;


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"  && Input.GetKey(KeyCode.E) && NarrativaManager.sharedInstance.eventosActivados[10])
        {

            other.attachedRigidbody.velocity = new Vector3(0, 0, 0);

            NarrativaManager.sharedInstance.eventoActual = eventoDeLaInstancia;
            GameManager.sharedInstance.inEvent();
        }
    }
}
