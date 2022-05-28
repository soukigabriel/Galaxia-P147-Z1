using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager sharedInstance;
    // variables que usa el jetcpack
    public float temperatura = 0, maxTemperatura = 100, 
        oxigeno = 5000, maxOxigeno = 5000, combustible = 1300, maxCombustible = 1300, 
        consumoPropulsionCohete = 170;
    public GameObject energyObject;
    public bool sabeHackear;

    private void Start()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        sabeHackear = false;
    }

    private void Update()
    {
        ClampValues();
    }

    public void ActivatePlayerEnergy()
    {
        energyObject.SetActive(true);
    }

    void ClampValues()
    {
        temperatura = Mathf.Clamp(temperatura, 0f, maxTemperatura);
        oxigeno = Mathf.Clamp(oxigeno, 0f, maxOxigeno);
        combustible = Mathf.Clamp(combustible, 0f, maxCombustible);
    }

    public void RecolectarCombustible(float cantidad)
    {
        combustible += cantidad;
    }

    public void RecolectarOxigeno(float cantidad)
    {
        oxigeno += cantidad;
    }

    public void RestablecerRecursos()
    {
        RestablecerCombustible();
        RestablecerOxigeno();
    }

    public void RestablecerCombustible()
    {
        combustible = maxCombustible;
    }

    public void RestablecerOxigeno()
    {
        oxigeno = maxOxigeno;
    }

}
