using System.Diagnostics;
using UnityEngine;

public class abrirPorta4 : MonoBehaviour
{
    public Animator portaBoss;

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
        portaBoss.SetBool("quartoQuiz", true);
    }
}