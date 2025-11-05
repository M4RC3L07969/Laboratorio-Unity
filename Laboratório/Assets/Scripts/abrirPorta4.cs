using UnityEngine;

public class abrirPorta4 : MonoBehaviour
{
    [Header("Referências")]
    public Animator portaBoss; // Animator da porta do boss
    public bool portaAberta = false; // Controla se a porta foi aberta
    public PerguntasQuiz quizManager; // Manager do quiz

    [Header("Spawner que libera o quiz")]

    public SpawnersAleatóriosSala3 spawner; // ← tipo do spawner correto

    public AudioSource somPortaSource;

    public AudioClip somPortaClip;
    public bool AudioTocou = false;

    public AudioClip quizLiberadoClip;
    public AudioSource quizLiberadoSource;

    private bool quizLiberadoTocou = false;
    void Start()
    {

        if (somPortaSource == null)
            somPortaSource = gameObject.AddComponent<AudioSource>();

        somPortaSource.clip = somPortaClip;
        somPortaSource.playOnAwake = false;
        somPortaSource.volume = 0.2f;


        if (quizLiberadoSource == null)
            quizLiberadoSource = gameObject.AddComponent<AudioSource>();



        quizLiberadoSource.clip = quizLiberadoClip;
        quizLiberadoSource.playOnAwake = false;
        quizLiberadoSource.volume = 0.2f;
    }
    private void Update()
    {
        if (spawner != null && spawner.podeAbrirQuiz && !quizLiberadoTocou)
        {
            quizLiberadoSource.Play();
            quizLiberadoTocou = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null && spawner.podeAbrirQuiz)
            {
                if (!AudioTocou)
                {
                    somPortaSource.Play();
                    AudioTocou = true;
                }
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
        // TESTE 1: Isso nos diz se o Quiz chamou esta função
        Debug.Log("### TESTE 1: A FUNÇÃO 'AbrirPortaDefinitivamente' FOI CHAMADA! ###");

        // TESTE 2: Isso verifica se você arrastou o Animator para o campo no Inspector
        if (portaBoss == null)
        {
            Debug.LogError("### ERRO: A VARIÁVEL 'portaBoss' ESTÁ VAZIA (None) NO INSPECTOR! ###");
            return; // Para de executar se estiver vazia
        }

        // TESTE 3: Se chegamos aqui, o script está enviando o comando
        Debug.Log("### TESTE 3: Enviando 'quartoQuiz' = true para o Animator: " + portaBoss.name + " ###");
        portaBoss.SetBool("quartoQuiz", true);
        portaAberta = true;
    }
}
