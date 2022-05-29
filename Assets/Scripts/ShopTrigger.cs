using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.W)){
            other.attachedRigidbody.velocity = new Vector3(0,0,0);
            GameManager.sharedInstance.inShop();
        }
    }
}
