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


    [Header("Objeto que muda de cor")]
    public GameObject objetoParaMudarCor;
    public Color corNova = Color.green; // Cor que vai mudar quando todos inimigos morrerem

    [Header("Configurações de Spawn")]
    [Tooltip("Quantidade total de inimigos que serão spawnados")]
    public int quantidadeInimigosParaSpawnar = 5;

    [Tooltip("Intervalo em segundos entre um spawn e outro")]
    public float tempoEntreSpawns = 6f;

    private float tempoAcumulado = 0f;
    private int inimigosRestantesParaSpawnar;
    private bool spawnerAtivo = true;

    [Header("Controle do Quiz")]
    public bool podeAbrirQuiz = false;

    public GameObject particleSystemObject;

    void Start()
    {
        inimigosRestantesParaSpawnar = quantidadeInimigosParaSpawnar;
    }

    void Update()
    {
        if (spawnerAtivo)
        {
            tempoAcumulado += Time.deltaTime;

            // Spawn enquanto ainda houver inimigos a spawnar
            if (tempoAcumulado >= tempoEntreSpawns && inimigosRestantesParaSpawnar > 0)
            {
                tempoAcumulado = 0f;
                SpawnInimigo();
                inimigosRestantesParaSpawnar--;
                Debug.Log("Inimigo spawnado. Restam: " + inimigosRestantesParaSpawnar);
            }

            // Libera quiz e muda cor quando todos foram spawnados e mortos
            if (inimigosRestantesParaSpawnar <= 0 &&
                GameObject.FindGameObjectsWithTag("Inimigo base").Length == 0) // Atenção: Todos os seus inimigos precisam ter a tag correta
            {
                podeAbrirQuiz = true;
                spawnerAtivo = false;
                Debug.Log("Todos inimigos derrotados! Quiz liberado!");

                // Muda a cor do objeto
                if (objetoParaMudarCor != null)
                {
                    Renderer rend = objetoParaMudarCor.GetComponent<Renderer>();
                    if (rend != null)
                        rend.material.color = corNova;

                    if (particleSystemObject != null)
                        particleSystemObject.SetActive(true);
                }
            }
        }
    }

    void SpawnInimigo()
    {
        int numAleatorio = Random.Range(0, 3);
        Vector3 pos;

        switch (numAleatorio)
        {
            case 0: pos = spawn1Sala1.transform.position; break;
            case 1: pos = spawn2Sala1.transform.position; break;
            case 2: pos = spawn3Sala1.transform.position; break;
            default: return;
        }

        Instantiate(enemyBase, pos, Quaternion.identity);
    }

    // NOTA: Os outros scripts de Spawner (Sala 2 e Sala 3) não precisam de alterações, 
    // pois eles já não continham a lógica do Power-Up.
}