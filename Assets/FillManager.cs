using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillManager : MonoBehaviour
{
    public Jetpack jetpack;
    public Image oxigenBar, energyBar;
    float porcentajeDeOxigeno, porcentajeDeCombustible;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AjustarPorcentajeOxigeno(ConseguirPorcentajeOxigeno());
        AjustarPorcentajeCombustible(ConseguirPorcentajeCombustible());
    }

    float ConseguirPorcentajeOxigeno()
    {
        porcentajeDeOxigeno = (jetpack.oxigeno) / jetpack.maxOxigeno;
        return porcentajeDeOxigeno;
    }

    void AjustarPorcentajeOxigeno(float porcentajeDeOxigeno)
    {
        oxigenBar.fillAmount = porcentajeDeOxigeno;
    }

    float ConseguirPorcentajeCombustible()
    {
        porcentajeDeCombustible = jetpack.combustible / jetpack.maxCombustible;
        return porcentajeDeCombustible;
    }

    void AjustarPorcentajeCombustible(float porcentajeDeCombustible)
    {
        energyBar.fillAmount = porcentajeDeCombustible;
    }
}
