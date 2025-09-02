using System.Diagnostics;
using UnityEngine;

public class abrirPorta2 : MonoBehaviour
{
    public Animator portaoDoisAnimaçao;
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
        portaoDoisAnimaçao.SetBool("segundoQuiz", true);
        portaAberta = true;
    }
}