using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BarraDeCargaManager : MonoBehaviour
{
    public Canvas MenuCursosCanvas;
    public GameObject Cortina;
    public GameObject MinijuegoQuiz;
    public Slider barraProgreso;
    public TMP_Text texto;

    public Image img1,img2, img3;
    public AudioSource reproductorMusica;
    public AudioClip[] songs;

    public float cuenta = 0;
    string nombreCurso;

public static BarraDeCargaManager sharedInstance;
 void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void activar(string nombreCurso){
        barraProgreso.gameObject.SetActive(true);
        cuenta=0;
        this.nombreCurso = nombreCurso;
        Cortina.SetActive( true);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(cuenta<150){
            cuenta+=1f;
            ActualizarValor(150f,cuenta);
            if(cuenta == 10)
                reproductorMusica.PlayOneShot(songs[0],.8f);

            if(cuenta == 25){
                img2.enabled =true;
                img1.enabled = img3.enabled = false;
            }
            if(cuenta == 50){
                img3.enabled =true;
                img1.enabled = img2.enabled = false;
            }
            if(cuenta == 75){
                img1.enabled =true;
                img2.enabled = img3.enabled = false;
            }

            
        }else{
            MinijuegoQuiz.SetActive(true);
            QuizManager.sharedInstance.ShowMinigame(nombreCurso);
            Cortina.SetActive(false);
            MenuCursosCanvas.enabled = (false);
            barraProgreso.gameObject.SetActive(false);
        }
    }

    public void ActualizarValor(float max, float actual){
        float porcentaje;
        porcentaje = actual/max;
        barraProgreso.value = cuenta;
        texto.text = "aprendiendo... %" +porcentaje*100;
    }
}
