using UnityEngine;

public class SpawnersAleatóriosSala2 : MonoBehaviour
{
    [Header("Referência da Porta")]
    [SerializeField] private abrirPorta2 porta2;

    [Header("Spawn Points")]
    public GameObject spawn1Sala2;
    public GameObject spawn2Sala2;
    public GameObject spawn3Sala2;
    public GameObject spawn4Sala2;
    public GameObject enemyAcido;

    [Header("Objeto que muda de cor")]
    public GameObject objetoParaMudarCor;
    public Color corNova = Color.green; // Cor alvo quando todos inimigos morrerem
    public float duracaoTransicao = 2f; // Duração da transição suave

    [Header("Configurações de Spawn")]
    [Tooltip("Quantidade total de inimigos que serão spawnados")]
    public int quantidadeInimigosParaSpawnar = 6;

    [Tooltip("Intervalo em segundos entre um spawn e outro")]
    public float tempoEntreSpawns = 6f;

    [Header("Status do Spawner")]
    public bool podeAbrirQuiz = false;

    private float tempoAcumulado = 0f;
    private int inimigosRestantesParaSpawnar;
    private bool spawnerAtivo = true;

    // Controle da transição de cor
    private bool iniciarTransicao = false;
    private float tempoTransicao = 0f;
    private Color corInicial;

    void Start()
    {
        inimigosRestantesParaSpawnar = quantidadeInimigosParaSpawnar;

        if (objetoParaMudarCor != null)
        {
            Renderer rend = objetoParaMudarCor.GetComponent<Renderer>();
            if (rend != null)
                corInicial = rend.material.color;
        }
    }

    void Update()
    {
        if (porta2 != null && porta2.portaAberta && spawnerAtivo)
        {
            tempoAcumulado += Time.deltaTime;

            if (tempoAcumulado >= tempoEntreSpawns && inimigosRestantesParaSpawnar > 0)
            {
                tempoAcumulado = 0f;
                ActivateRandomSpawner();
                inimigosRestantesParaSpawnar--;
            }

            // Libera quiz quando todos foram spawnados e mortos
            if (inimigosRestantesParaSpawnar <= 0 &&
                GameObject.FindGameObjectsWithTag("Inimigo base").Length == 0)
            {
                podeAbrirQuiz = true;
                spawnerAtivo = false;
                iniciarTransicao = true; // inicia a transição de cor
                tempoTransicao = 0f;
                Debug.Log("Todos inimigos da Sala 2 derrotados! Quiz liberado!");
            }
        }

        // Atualiza a transição de cor se necessário
        if (iniciarTransicao && objetoParaMudarCor != null)
        {
            Renderer rend = objetoParaMudarCor.GetComponent<Renderer>();
            if (rend != null)
            {
                tempoTransicao += Time.deltaTime;
                rend.material.color = Color.Lerp(corInicial, corNova, tempoTransicao / duracaoTransicao);

                if (tempoTransicao >= duracaoTransicao)
                    iniciarTransicao = false; // termina a transição
            }
        }
    }

    void ActivateRandomSpawner()
    {
        int numAleatorio2 = Random.Range(0, 4);
        Vector3 pos;

        switch (numAleatorio2)
        {
            case 0: pos = spawn1Sala2.transform.position; break;
            case 1: pos = spawn2Sala2.transform.position; break;
            case 2: pos = spawn3Sala2.transform.position; break;
            case 3: pos = spawn4Sala2.transform.position; break;
            default: return;
        }

        Instantiate(enemyAcido, pos, Quaternion.identity);
    }
}
