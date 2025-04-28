using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPorta : MonoBehaviour
{
    public Animator portaoUmAnimaçao;
    public Animator portaoDoisAnimaçao;
    public bool primeiroQuiz;
    public bool segundoQuiz;

    // Start is called before the first frame update
    void Start()
    {
        primeiroQuiz = false;
        segundoQuiz = false;
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