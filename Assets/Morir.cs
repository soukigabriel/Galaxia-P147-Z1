using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morir : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    const string STATE_DEAD = "isDead";
    public AudioSource asfixiaSFX;
    public float timer, maxTimer;
    public bool isDead, startCounting;

    private void Start()
    {
        isDead = false;
        startCounting = false;
        timer = maxTimer;
    }

    private void Update()
    {
        MatarPersonaje();
    }

    public void MatarPersonaje()
    {
        if(isDead)
        {
            if (!startCounting)
            {
                m_animator.SetTrigger(STATE_DEAD);
                PauseMenu.sharedInstance.HideHUD();
                asfixiaSFX.Play();
                startCounting = true;
            }
            else
            {
                timer -= Time.deltaTime;
                if(timer <= 0f)
                {
                    GameManager.sharedInstance.GameOver();
                }
            }


        }

    }





}
