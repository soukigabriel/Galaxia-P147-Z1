using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCursosTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        
        /*if (other.tag == "Player" && Input.GetButtonDown("Accionar"))*/
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.W)){
            other.attachedRigidbody.velocity = new Vector3(0,0,0);
            GameManager.sharedInstance.CourseMenu();
        }
    }


}
