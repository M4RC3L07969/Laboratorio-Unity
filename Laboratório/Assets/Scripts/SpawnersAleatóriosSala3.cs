using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersAleatóriosSala3 : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public int numAleatorio = 0;
    public float segundos = 0f;
    public GameObject enemyPrefeb1;
    public GameObject enemyPrefeb2;
    public GameObject enemyAtual;

    void Update()
    {
        if (segundos >= 6)
        {
            segundos = 0;
            ActivateRandomSpawnerAndRandomEnemy();
        }


        segundos += Time.deltaTime;
    }

    void ActivateRandomSpawnerAndRandomEnemy()
    {
        numAleatorio = Random.Range(0, 2);

        switch (numAleatorio)
        {
            case 0:
                enemyAtual = enemyPrefeb1;
                break;
            case 1:
                enemyAtual = enemyPrefeb2;
                break;
        }
        numAleatorio = Random.Range(0, 3);

        switch (numAleatorio)
        {
            case 0:
                Instantiate(enemyAtual, spawn1.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemyAtual, spawn2.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemyAtual, spawn3.transform.position, Quaternion.identity);
                break;
        }
    }
}
