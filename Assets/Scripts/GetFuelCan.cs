using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFuelCan : MonoBehaviour
{
    public bool fuelTaken;
    // Start is called before the first frame update
    void Start()
    {
        fuelTaken = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame && !fuelTaken && other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                fuelTaken = true;
                InteractNotification.show = false;
                //ResourcesManager.sharedInstance.ActivatePlayerEnergy();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame && !fuelTaken && other.tag == "Player")
        {
            InteractNotification.show = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame && !fuelTaken && other.tag == "Player")
        {
            InteractNotification.show = false;
        }
    }
}
