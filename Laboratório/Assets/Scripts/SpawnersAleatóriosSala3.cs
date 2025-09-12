using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersAleatóriosSala3 : MonoBehaviour
{
    [SerializeField] private abrirPorta3 porta3;

    public GameObject spawn1Sala3;
    public GameObject spawn2Sala3;
    public GameObject spawn3Sala3;
    public int spawnerAleatorio = 0;

    public GameObject enemyPrefeb1;
    public GameObject enemyPrefeb2;

    private GameObject enemyAtual;
    private float segundos3 = 0f;

    void Update()
    {
        if (porta3.portaAberta)
        {
            segundos3 += Time.deltaTime;

            if (segundos3 >= 6)
            {
                segundos3 = 0;
                ActivateRandomSpawnerAndRandomEnemy();
            }
        }
    }

    public void ActivateRandomSpawnerAndRandomEnemy()
    {
        int inimigoAleatorio = Random.Range(0, 2);
        enemyAtual = inimigoAleatorio == 0 ? enemyPrefeb1 : enemyPrefeb2;


        spawnerAleatorio = Random.Range(0, 3);

        switch (spawnerAleatorio)
        {
            case 0:
                Instantiate(enemyAtual, spawn1Sala3.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemyAtual, spawn2Sala3.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemyAtual, spawn3Sala3.transform.position, Quaternion.identity);
                break;
        }
    }
}
