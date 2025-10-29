using UnityEngine;

public class abrirPorta2 : MonoBehaviour
{
    public Animator portaoDoisAnimaçao;
    public bool portaAberta = false;
    public PerguntasQuiz quizManager;

    public RandomSpawner spawner;

    public AudioSource somPortaSource;

    public AudioClip somPortaClip;
    public bool AudioTocou = false;

    void Start()
    {

        if (somPortaSource == null)
            somPortaSource = gameObject.AddComponent<AudioSource>();

        somPortaSource.clip = somPortaClip;
        somPortaSource.playOnAwake = false;
        somPortaSource.volume = 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null && spawner.podeAbrirQuiz)
            {
                quizManager.IniciarQuiz(this);
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                Debug.Log("O quiz ainda não pode ser iniciado. Aguarde o tempo acabar.");
            }
        }
    }

    public void AbrirPortaDefinitivamente()
    {
        portaoDoisAnimaçao.SetBool("segundoQuiz", true);
        portaAberta = true;
    }
}
