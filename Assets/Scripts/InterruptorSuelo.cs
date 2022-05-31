using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoDeInterruptor { plataforma }

public class InterruptorSuelo : MonoBehaviour
{
    bool haveTriggered;
    [SerializeField]Animator m_animator, platformAnimator;
    public const string STATE_TRIGGERED = "triggered";
    [SerializeField] BoxCollider m_boxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame && !haveTriggered)
        {
            m_animator.SetBool(STATE_TRIGGERED, true);
            platformAnimator.SetBool(STATE_TRIGGERED, true);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        haveTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
