using System.Collections.Generic;
using UnityEngine;

public class SpawnersAleatóriosSala2 : MonoBehaviour
{
    [Header("Spawner points")]
    public GameObject spawn1Sala2;
    public GameObject spawn2Sala2;
    public GameObject spawn3Sala2;
    public GameObject spawn4Sala2;
    public GameObject enemyAcido;

    [Header("Configurações de Spawn")]
    public int quantidadeInimigosParaSpawnar = 6;
    public float tempoEntreSpawns = 6f;

    [Header("Status do Spawner")]
    public bool podeAbrirQuiz = false;

    private float tempoAcumulado = 0f;
    private int inimigosRestantesParaSpawnar;
    // Alterado para 'false' por padrão. O spawner só inicia após a ativação externa.
    private bool spawnerAtivo = false;

    // Lista de inimigos vivos gerados por este spawner
    public List<GameObject> inimigosVivos = new List<GameObject>();

    void Start()
    {
        inimigosRestantesParaSpawnar = quantidadeInimigosParaSpawnar;
    }

    void Update()
    {
        // Se o spawner não estiver ativo, sai do Update imediatamente
        if (!spawnerAtivo) return;

        tempoAcumulado += Time.deltaTime;

        if (tempoAcumulado >= tempoEntreSpawns && inimigosRestantesParaSpawnar > 0)
        {
            tempoAcumulado = 0f;
            SpawnInimigo();
            inimigosRestantesParaSpawnar--;
        }

        // Remove inimigos nulos da lista (os que foram destruídos/mortos)
        inimigosVivos.RemoveAll(i => i == null);

        // Libera quiz quando todos inimigos foram spawnados e mortos
        if (inimigosRestantesParaSpawnar <= 0 && inimigosVivos.Count == 0)
        {
            podeAbrirQuiz = true;
            spawnerAtivo = false; // Opcional: Desativa o Update após terminar o spawn
        }
    }

    void SpawnInimigo()
    {
        int numAleatorio = Random.Range(0, 4);
        Vector3 pos = spawn1Sala2.transform.position;

        switch (numAleatorio)
        {
            case 0: pos = spawn1Sala2.transform.position; break;
            case 1: pos = spawn2Sala2.transform.position; break;
            case 2: pos = spawn3Sala2.transform.position; break;
            case 3: pos = spawn4Sala2.transform.position; break;
        }

        GameObject inimigo = Instantiate(enemyAcido, pos, Quaternion.identity);
        inimigosVivos.Add(inimigo); // adiciona à lista
    }

    public void AtivarSpawner()
    {
        if (!spawnerAtivo)
        {
            spawnerAtivo = true;
            Debug.Log("Spawner da Sala 2 Ativado!");
        }
    }
}