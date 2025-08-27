using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPorta2 : MonoBehaviour
{
    public Animator portaoDoisAnimaçao;
    public bool segundoQuiz;
    public QuizController quizController;

    void Start()
    {
        segundoQuiz = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DoorCollider") ;
        {
            segundoQuiz = true;
            portaoDoisAnimaçao.SetBool("segundoQuiz", segundoQuiz);
        }

        if (quizController != null)
        {
            quizController.AtualizarQuiz();
        }
    }
}