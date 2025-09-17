using UnityEngine;

public class abrirPorta3 : MonoBehaviour
{
    public Animator portaoTresAnimaçao;
    public bool portaAberta = false;
    public PerguntasQuiz quizManager;

    [Header("Spawner que libera o quiz")]
    public SpawnersAleatóriosSala2 spawner; // ← referência do script do spawner

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null && spawner.podeAbrirQuiz)
            {
                Debug.Log("Quiz 3 iniciado.");
                quizManager.IniciarQuiz(this);
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                Debug.Log("Quiz 3 ainda não pode ser iniciado. Aguarde o tempo acabar.");
            }
        }
    }

    public void AbrirPortaDefinitivamente()
    {
        portaoTresAnimaçao.SetBool("terceiroQuiz", true);
        portaAberta = true;
    }
}
