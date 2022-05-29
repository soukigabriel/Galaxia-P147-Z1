using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosTrigger : MonoBehaviour
{
    SpriteRenderer sprite;
    CapsuleCollider itemCollider;
    //bool haSidoRecolectada;
    public short idBbjeto;


    public Animator m_Animator;
    public GameObject player, boton;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CapsuleCollider>();
        //haSidoRecolectada = false;
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Recolecctado();
        }
    }

    public void Show()
    {
        sprite.enabled = true;
        itemCollider.enabled = true;
        // haSidoRecolectada = false;
        NarrativaManager.sharedInstance.objetosClave[idBbjeto] = false;
    }

    void Hide()
    {
        sprite.enabled = false;
        itemCollider.enabled = false;
        //haSidoRecolectada = true;
    }

    void Recolecctado()
    {
        GameManager.sharedInstance.currentGameState = GameState.inEvent;
        NarrativaManager.sharedInstance.objetosClave[idBbjeto] = true;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        m_Animator.SetBool("isRunning", false);
        boton.SetActive(true) ;
        Hide();
    }

    public void cerrarBoton(){
        GameManager.sharedInstance.currentGameState = GameState.inGame;
        boton.SetActive(false);

    }
}
