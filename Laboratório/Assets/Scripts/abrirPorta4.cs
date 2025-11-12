using UnityEngine;

public class abrirPorta4 : MonoBehaviour
{
    [Header("Referências")]
    public Animator portaBoss;
    public bool portaAberta = false;
    public PerguntasQuiz quizManager;

    [Header("Spawner que libera o quiz")]

    public SpawnersAleatóriosSala3 spawner;

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
                GetComponent<Collider>().enabled = false;
   
            }
            else
            {
                Debug.Log("Quiz 4 ainda não pode ser iniciado. Aguarde o tempo acabar.");
            }
        }
    }
    public void AbrirPortaDefinitivamente()
    {
        if (portaBoss == null)
        {
            return;
        }
        portaBoss.SetBool("quartoQuiz", true);
        portaAberta = true;
    }
}
