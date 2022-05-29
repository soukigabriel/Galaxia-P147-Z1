using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaTrigger : MonoBehaviour
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

   /// <summary>
   /// OnTriggerEnter is called when the Collider other enters the trigger.
   /// </summary>
   /// <param name="other">The other Collider involved in this collision.</param>
   void OnTriggerEnter(Collider other)
   {
        Debug.Log("hola");
        if(other.tag == "Player"){
            Recolecctado();
        }
    }

    void Show(){
        sprite.enabled = true;
        itemCollider.enabled = true;
       // haSidoRecolectada = false;
    }

    void Hide(){
        sprite.enabled = false;
        itemCollider.enabled = false;
        //haSidoRecolectada = true;
    }

    void Recolecctado(){
        GameManager.sharedInstance.platziCoins ++;
        Hide();
    }

}
