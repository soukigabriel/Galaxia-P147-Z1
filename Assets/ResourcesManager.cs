using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager sharedInstance;
    // variables que usa el jetcpack
    public float temperatura = 200, maxTemperatura = 200, 
        oxigeno = 1000, maxOxigeno = 1000, combustible = 1000, maxCombustible = 1000, 
        consumoPropulsionCohete = 250;

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
    }

    private void Update()
    {
        ClampValues();
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
