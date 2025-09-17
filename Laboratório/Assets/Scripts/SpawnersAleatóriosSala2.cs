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

    [Header("Configurações de Tempo")]
    [Tooltip("Tempo total em segundos para spawnar inimigos")]
    public float tempoTotalSpawnerInicial = 150f;

    [Tooltip("Intervalo em segundos entre um spawn e outro")]
    public float tempoEntreSpawns = 6f;

    [Header("Status do Spawner")]
    public bool podeAbrirQuiz = false;

    private float tempoTotalSpawnerAtual;
    private float tempoAcumulado = 0f;

    private bool spawnerAtivo = true;

    void Start()
    {
        tempoTotalSpawnerAtual = tempoTotalSpawnerInicial;
    }

    void Update()
    {
        if (porta2 != null && porta2.portaAberta && spawnerAtivo)
        {
            tempoTotalSpawnerAtual -= Time.deltaTime;

            if (tempoTotalSpawnerAtual <= 0f)
            {
                spawnerAtivo = false;
                tempoTotalSpawnerAtual = 0f;
                podeAbrirQuiz = true; // ← libera o quiz
                Debug.Log("Spawner da Sala 2 desativado. Quiz pode ser iniciado.");
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
        int numAleatorio2 = Random.Range(0, 4); // Corrigido para 4
        Vector3 pos;

        switch (numAleatorio2)
        {
            case 0:
                pos = spawn1Sala2.transform.position;
                break;
            case 1:
                pos = spawn2Sala2.transform.position;
                break;
            case 2:
                pos = spawn3Sala2.transform.position;
                break;
            case 3:
                pos = spawn4Sala2.transform.position;
                break;
            default:
                return;
        }

        Instantiate(enemyAcido, pos, Quaternion.identity);
    }
}
