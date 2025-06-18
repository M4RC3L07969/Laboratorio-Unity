using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPorta : MonoBehaviour
{
    public Animator portaoUmAnimaçao;
    public bool primeiroQuiz;

    void Start()
    {
        primeiroQuiz = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DoorCollider");
        {
            primeiroQuiz = true;
            portaoUmAnimaçao.SetBool("primeiroQuiz", primeiroQuiz);
        }
    }
}