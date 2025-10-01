using UnityEngine;

public class abrirPorta4 : MonoBehaviour
{
    [Header("Referências")]
    public Animator portaBoss; // Animator da porta do boss
    public bool portaAberta = false; // Controla se a porta foi aberta
    public PerguntasQuiz quizManager; // Manager do quiz

    [Header("Spawner que libera o quiz")]
    public SpawnersAleatóriosSala3 spawner; // ← tipo do spawner correto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null && spawner.podeAbrirQuiz)
            {
                Debug.Log("Quiz 4 iniciado.");
                quizManager.IniciarQuiz(this);
                GetComponent<Collider>().enabled = false; // Desabilita para não reativar
            }
            else
            {
                Debug.Log("Quiz 4 ainda não pode ser iniciado. Aguarde o tempo acabar.");
            }
        }
    }

    public void AbrirPortaDefinitivamente()
    {
        portaBoss.SetBool("quartoQuiz", true);
        portaAberta = true;

    }
}
