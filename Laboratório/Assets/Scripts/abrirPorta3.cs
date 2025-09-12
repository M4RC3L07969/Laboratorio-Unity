using System.Diagnostics;
using UnityEngine;

public class abrirPorta3 : MonoBehaviour
{
    public Animator portaoTresAnimaçao;
    public bool portaAberta = false;
    public PerguntasQuiz quizManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            quizManager.IniciarQuiz(this);

            GetComponent<Collider>().enabled = false;
        }
    }

    public void AbrirPortaDefinitivamente()
    {
        portaoTresAnimaçao.SetBool("terceiroQuiz", true);
        portaAberta = true;
    }
}