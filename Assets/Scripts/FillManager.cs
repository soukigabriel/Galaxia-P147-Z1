using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillManager : MonoBehaviour
{
    public Jetpack jetpack;
    public Image oxigenBar, energyBar, temperatureBar, circuloRecalentamiento;
    float porcentajeDeOxigeno, porcentajeDeCombustible, porcentajeDeTemperatura;
    Color nuevoColor;

    // Start is called before the first frame update
    void Start()
    {
        nuevoColor = circuloRecalentamiento.color;
    }

    // Update is called once per frame
    void Update()
    {
        AjustarPorcentajeOxigeno(ConseguirPorcentajeOxigeno());
        AjustarPorcentajeCombustible(ConseguirPorcentajeCombustible());
        AjustarPorcentajeTemperatura(ConseguirPorcentajeTemperatura());
        AjustarCirculoRecalentamiento(ConseguirPorcentajeTemperatura());
    }

    float ConseguirPorcentajeOxigeno()
    {
        porcentajeDeOxigeno = (ResourcesManager.sharedInstance.oxigeno) / ResourcesManager.sharedInstance.maxOxigeno;
        return porcentajeDeOxigeno;
    }

    void AjustarPorcentajeOxigeno(float porcentajeDeOxigeno)
    {
        oxigenBar.fillAmount = porcentajeDeOxigeno;
    }

    float ConseguirPorcentajeCombustible()
    {
        porcentajeDeCombustible = ResourcesManager.sharedInstance.combustible / ResourcesManager.sharedInstance.maxCombustible;
        return porcentajeDeCombustible;
    }

    void AjustarPorcentajeCombustible(float porcentajeDeCombustible)
    {
        energyBar.fillAmount = porcentajeDeCombustible;
    }

    float ConseguirPorcentajeTemperatura()
    {
        porcentajeDeTemperatura = (ResourcesManager.sharedInstance.temperatura) / ResourcesManager.sharedInstance.maxTemperatura;
        return porcentajeDeTemperatura;
    }

    void AjustarPorcentajeTemperatura(float porcentajeDeTemperatura)
    {
        temperatureBar.fillAmount = porcentajeDeTemperatura;
    }

    void AjustarCirculoRecalentamiento(float porcentajeDeTemperatura)
    {
        nuevoColor.a = porcentajeDeTemperatura;
        circuloRecalentamiento.color = nuevoColor;
    }
}
