using UnityEngine;

public class abrirPorta4 : MonoBehaviour
{
    [Header("Referências")]
    public Animator portaBoss; // Referência para o Animator da porta do boss
    public bool portaAberta = false; // Controla se a porta foi aberta ou não
    public PerguntasQuiz quizManager; // Referência para o manager do quiz
    public RandomSpawner spawner; // Referência para o spawner, caso precise verificar se o quiz pode ser aberto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null && spawner.podeAbrirQuiz)
            {
                quizManager.IniciarQuiz(this);
                GetComponent<Collider>().enabled = false; // Desabilita o collider para evitar múltiplas interações
            }
            else
            {
                Debug.Log("O quiz ainda não pode ser iniciado. Aguarde o tempo acabar.");
            }
        }
    }

    public void AbrirPortaDefinitivamente()
    {
        portaBoss.SetBool("quartoQuiz", true); // Aciona a animação para abrir a porta do boss
        portaAberta = true; // Marca que a porta foi aberta
    }
}
