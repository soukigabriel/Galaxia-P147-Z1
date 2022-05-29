using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager sharedInstance;
    // variables que usa el jetcpack
    public float temperatura = 0, maxTemperatura = 100, 
        oxigeno = 5000, maxOxigeno = 5000, combustible = 1300, maxCombustible = 1300, 
        velocidadDeCalentado = 1.8f, velocidadDeConsumoCombustible = 2.5f, 
        velocidadDeCalentadoCohete= 45f, consumoPropulsionCohete = 170;

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
