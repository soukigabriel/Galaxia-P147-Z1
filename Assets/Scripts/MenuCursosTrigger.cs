using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCursosTrigger : MonoBehaviour
{
    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        
        /*if (other.tag == "Player" && Input.GetButtonDown("Accionar"))*/
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E)){
            other.attachedRigidbody.velocity = new Vector3(0,0,0);
            GameManager.sharedInstance.CourseMenu();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame && other.tag == "Player")
        {
            InteractNotification.show = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame && other.tag == "Player")
        {
            InteractNotification.show = false;
        }
    }

}
