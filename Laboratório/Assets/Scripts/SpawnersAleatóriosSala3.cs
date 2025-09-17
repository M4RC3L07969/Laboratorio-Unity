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

    [Header("Configurações de Tempo")]
    [Tooltip("Tempo total em segundos para spawnar inimigos")]
    public float tempoTotalSpawnerInicial = 150f;

    [Tooltip("Intervalo em segundos entre um spawn e outro")]
    public float tempoEntreSpawns = 6f;

    private float tempoTotalSpawnerAtual;
    private float tempoAcumulado = 0f;

    private GameObject enemyAtual;
    private bool spawnerAtivo = true;

    void Start()
    {
        tempoTotalSpawnerAtual = tempoTotalSpawnerInicial;
    }

    void Update()
    {
        if (porta3 != null && porta3.portaAberta && spawnerAtivo)
        {
            tempoTotalSpawnerAtual -= Time.deltaTime;

            // Verifica se o tempo total de spawn acabou
            if (tempoTotalSpawnerAtual <= 0f)
            {
                spawnerAtivo = false;
                tempoTotalSpawnerAtual = 0f;
                Debug.Log("Tempo de spawn encerrado.");
                return;
            }

            tempoAcumulado += Time.deltaTime;

            // Ativa o spawn de inimigos após o intervalo de tempo
            if (tempoAcumulado >= tempoEntreSpawns)
            {
                tempoAcumulado = 0f;
                ActivateRandomSpawnerAndRandomEnemy();
            }
        }
    }

    void ActivateRandomSpawnerAndRandomEnemy()
    {
        // Escolhe o inimigo aleatoriamente
        int inimigoAleatorio = Random.Range(0, 2);
        enemyAtual = inimigoAleatorio == 0 ? enemyPrefeb1 : enemyPrefeb2;

        // Escolhe o spawner aleatoriamente
        int spawnerAleatorio = Random.Range(0, 5);
        Vector3 pos = Vector3.zero;

        switch (spawnerAleatorio)
        {
            case 0:
                pos = spawn1Sala3.transform.position;
                break;
            case 1:
                pos = spawn2Sala3.transform.position;
                break;
            case 2:
                pos = spawn3Sala3.transform.position;
                break;
            case 3:
                pos = spawn4Sala3.transform.position;
                break;
            case 4:
                pos = spawn5Sala3.transform.position;
                break;
        }

        // Instancia o inimigo no spawn escolhido
        Instantiate(enemyAtual, pos, Quaternion.identity);
    }
}
