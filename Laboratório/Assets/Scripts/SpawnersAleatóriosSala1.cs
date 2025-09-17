using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Header("Referência da Porta")]
    [SerializeField] private abrirPorta porta1;

    [Header("Spawn Points")]
    public GameObject spawn1Sala1;
    public GameObject spawn2Sala1;
    public GameObject spawn3Sala1;
    public GameObject enemyBase;

    [Header("Configurações de Tempo")]
    [Tooltip("Tempo total em segundos para spawnar inimigos")]
    public float tempoTotalSpawnerInicial = 150f;

    [Tooltip("Intervalo em segundos entre um spawn e outro")]
    public float tempoEntreSpawns = 6f;

    private float tempoTotalSpawnerAtual;
    private float tempoAcumulado = 0f;

    public bool podeAbrirQuiz = false;
    private bool spawnerAtivo = true;

    void Start()
    {
        tempoTotalSpawnerAtual = tempoTotalSpawnerInicial;
    }

    void Update()
    {
        if (porta1 != null && porta1.primeiroQuiz && spawnerAtivo)
        {
            tempoTotalSpawnerAtual -= Time.deltaTime;

            if (tempoTotalSpawnerAtual <= 0f)
            {
                spawnerAtivo = false;
                tempoTotalSpawnerAtual = 0f;

                podeAbrirQuiz = true;
                Debug.Log("Tempo encerrado. Quiz liberado!");
                return;
            }

            tempoAcumulado += Time.deltaTime;

            if (tempoAcumulado >= tempoEntreSpawns)
            {
                tempoAcumulado = 0f;
                ActivateRandomSpawner();
            }
        }
    }

    void ActivateRandomSpawner()
    {
        int numAleatorio1 = Random.Range(0, 3);
        Vector3 pos;

        switch (numAleatorio1)
        {
            case 0:
                pos = spawn1Sala1.transform.position;
                break;
            case 1:
                pos = spawn2Sala1.transform.position;
                break;
            case 2:
                pos = spawn3Sala1.transform.position;
                break;
            default:
                return;
        }

        Instantiate(enemyBase, pos, Quaternion.identity);
    }
}
