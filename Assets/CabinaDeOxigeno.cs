using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinaDeOxigeno : MonoBehaviour
{
    BoxCollider m_collider;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ResourcesManager.sharedInstance.RestablecerRecursos();
        }
    }
}
