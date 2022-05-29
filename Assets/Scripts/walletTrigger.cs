using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walletTrigger : MonoBehaviour
{
    SpriteRenderer sprite;
    CapsuleCollider itemCollider;
    //bool haSidoRecolectada;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CapsuleCollider>();
        //haSidoRecolectada = false;
    }

public ListaDeEventos eventoDeLaInstancia;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" &&
    !NarrativaManager.sharedInstance.eventosActivados[(int)eventoDeLaInstancia])
        {
            other.attachedRigidbody.velocity = new Vector3(0, 0, 0);

            NarrativaManager.sharedInstance.eventoActual = eventoDeLaInstancia;
            GameManager.sharedInstance.inEvent();
        }
        Recolecctado();
    }


    void Show()
    {
        sprite.enabled = true;
        itemCollider.enabled = true;
        // haSidoRecolectada = false;
    }

    void Hide()
    {
        sprite.enabled = false;
        itemCollider.enabled = false;
        //haSidoRecolectada = true;
    }

    public void Recolecctado()
    {
        Hide();
    }
}
