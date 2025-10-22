using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // A única instância estática desta classe (Singleton Pattern)
    public static PowerUpManager Instance { get; private set; }

    [Header("Configurações Globais de Power-Up")]
    [Tooltip("Prefab do Power-Up a ser instanciado")]
    public GameObject powerUpPrefab;

    [Tooltip("Número de inimigos que devem ser derrotados para spawnar um Power-Up")]
    public int contagemParaPowerUp = 5;

    [Header("Pontos de Spawn Dinâmicos (Plataformas)")]
    public Transform spawnPointPlataforma1;
    public Transform spawnPointPlataforma2;
    public Transform spawnPointPlataforma3;

    // A referência do ponto de spawn atual
    private Transform spawnPointAtual;

    // Variáveis de estado
    private int inimigosDerrotadosDesdeUltimoPowerUp = 0;
    private GameObject powerUpInstanciado = null;

    private void Awake()
    {
        // Garante que só há uma instância (Singleton)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // Define o ponto de spawn inicial para a Plataforma 1
            spawnPointAtual = spawnPointPlataforma1;
        }
    }

    /// <summary>
    /// Chamado por QUALQUER inimigo quando for destruído.
    /// </summary>
    public void InimigoDerrotado()
    {
        if (powerUpPrefab == null || spawnPointAtual == null)
        {
            Debug.LogError("Power-Up Prefab ou Ponto de Spawn atual não definidos.");
            return;
        }

        // Se já existe um Power-Up ativo, apenas conta para o próximo.
        if (powerUpInstanciado != null)
        {
            inimigosDerrotadosDesdeUltimoPowerUp++;
            return;
        }

        inimigosDerrotadosDesdeUltimoPowerUp++;
        Debug.Log("Inimigo Derrotado! Contador global para Power-Up: " + inimigosDerrotadosDesdeUltimoPowerUp);

        if (inimigosDerrotadosDesdeUltimoPowerUp >= contagemParaPowerUp)
        {
            SpawnPowerUp();
            inimigosDerrotadosDesdeUltimoPowerUp = 0;
        }
    }

    void SpawnPowerUp()
    {
        // Usa o ponto de spawn atual que foi definido pelas portas
        Vector3 spawnPos = spawnPointAtual.position;

        powerUpInstanciado = Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
        Debug.Log("Power-Up Spawnado na posição: " + spawnPointAtual.name);
    }

    /// <summary>
    /// Chamado pelo script de coleta do Power-Up quando ele for pego/destruído.
    /// </summary>
    public void PowerUpColetado()
    {
        powerUpInstanciado = null;
        Debug.Log("Power-Up Coletado!");
    }

    // =========================================================================
    // MÉTODOS PÚBLICOS PARA MUDANÇA DE SALA
    // =========================================================================

    /// <summary>
    /// Altera o ponto de spawn do Power-Up para a Plataforma 2 (Sala 2).
    /// Chamado pelo colisor/trigger da Porta 2.
    /// </summary>
    public void MudarSpawnParaSala2()
    {
        if (spawnPointPlataforma2 != null)
        {
            spawnPointAtual = spawnPointPlataforma2;
            Debug.Log("Ponto de spawn do Power-Up alterado para Sala 2.");
        }
        else
        {
            Debug.LogError("Plataforma 2 não configurada no PowerUpManager.");
        }
    }

    /// <summary>
    /// Altera o ponto de spawn do Power-Up para a Plataforma 3 (Sala 3).
    /// Chamado pelo colisor/trigger da Porta 3.
    /// </summary>
    public void MudarSpawnParaSala3()
    {
        if (spawnPointPlataforma3 != null)
        {
            spawnPointAtual = spawnPointPlataforma3;
            Debug.Log("Ponto de spawn do Power-Up alterado para Sala 3.");
        }
        else
        {
            Debug.LogError("Plataforma 3 não configurada no PowerUpManager.");
        }
    }
}