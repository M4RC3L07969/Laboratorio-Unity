using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPorta4 : MonoBehaviour
{
    
    public Animator portaBoss;
    public bool quartoQuiz;

    // Start is called before the first frame update
    void Start()
    {
        quartoQuiz = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DoorCollider");
        {
            quartoQuiz = true;
            portaBoss.SetBool("quartoQuiz", quartoQuiz);
        }
    }
}