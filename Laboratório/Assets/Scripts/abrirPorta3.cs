using UnityEngine;

public class abrirPorta3 : MonoBehaviour
{
    public Animator portaoTresAnimaçao;
    public bool portaAberta = false;
    public PerguntasQuiz quizManager;

    [Header("Spawner que libera o quiz")]
    public SpawnersAleatóriosSala2 spawner;

    [Header("Objeto que muda de cor")]
    public GameObject objetoParaMudarCor;
    public Color corNova = Color.green;

    private bool quizLiberado = false;
    private bool corMudada = false;

    private void Update()
    {
        if (spawner != null && !quizLiberado && spawner.podeAbrirQuiz)
        {
            quizLiberado = true;
            Debug.Log("Todos inimigos da Sala 2 mortos! Quiz liberado.");

            if (!corMudada && objetoParaMudarCor != null)
            {
                Renderer rend = objetoParaMudarCor.GetComponent<Renderer>();
                if (rend != null)
                    rend.material.color = corNova;
                corMudada = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (quizLiberado)
            {
                Debug.Log("Quiz 3 iniciado.");
                quizManager.IniciarQuiz(this);
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                Debug.Log("Quiz 3 ainda não pode ser iniciado. Derrote todos inimigos primeiro!");
            }
        }
    }

    public void AbrirPortaDefinitivamente()
    {
        portaoTresAnimaçao.SetBool("terceiroQuiz", true);
        portaAberta = true;
    }
}
