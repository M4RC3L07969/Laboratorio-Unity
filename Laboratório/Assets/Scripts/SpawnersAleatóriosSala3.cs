using UnityEngine;

public class SpawnersAleatóriosSala3 : MonoBehaviour
{
    [Header("Referência da Porta")]
    [SerializeField] private abrirPorta3 porta3;

    [Header("Pontos de Spawn")]
    public GameObject spawn1Sala3;
    public GameObject spawn2Sala3;
    public GameObject spawn3Sala3;
    public GameObject spawn4Sala3;
    public GameObject spawn5Sala3;

    [Header("Inimigos")]
    public GameObject enemyPrefeb1;
    public GameObject enemyPrefeb2;

    [Header("Objeto que muda de cor")]
    public GameObject objetoParaMudarCor;
    public Color corNova = Color.green; 
    public float duracaoTransicao = 2f; 

    [Header("Configurações de Spawn")]
    [Tooltip("Quantidade total de inimigos que serão spawnados")]
    public int quantidadeInimigosParaSpawnar = 8;

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
        if (porta3 != null && porta3.portaAberta && spawnerAtivo)
        {
            tempoAcumulado += Time.deltaTime;

            if (tempoAcumulado >= tempoEntreSpawns && inimigosRestantesParaSpawnar > 0)
            {
                tempoAcumulado = 0f;
                ActivateRandomSpawnerAndRandomEnemy();
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
                Debug.Log("Todos inimigos da Sala 3 derrotados! Quiz liberado!");
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

    void ActivateRandomSpawnerAndRandomEnemy()
    {
        int inimigoAleatorio = Random.Range(0, 2);
        GameObject enemyAtual = inimigoAleatorio == 0 ? enemyPrefeb1 : enemyPrefeb2;

        int spawnerAleatorio = Random.Range(0, 5);
        Vector3 pos = Vector3.zero;

        switch (spawnerAleatorio)
        {
            case 0: pos = spawn1Sala3.transform.position; break;
            case 1: pos = spawn2Sala3.transform.position; break;
            case 2: pos = spawn3Sala3.transform.position; break;
            case 3: pos = spawn4Sala3.transform.position; break;
            case 4: pos = spawn5Sala3.transform.position; break;
        }

        Instantiate(enemyAtual, pos, Quaternion.identity);
    }
}
