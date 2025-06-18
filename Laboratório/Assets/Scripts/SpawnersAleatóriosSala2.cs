using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnersAleatóriosSala2 : MonoBehaviour
{
    [SerializeField] private abrirPorta2 porta2;

    public GameObject spawn1Sala2;
    public GameObject spawn2Sala2;
    public GameObject spawn3Sala2;
    public int numAleatorio2 = 0;
    public float segundos2 = 0f;
    public GameObject enemyAcido;


    void Update()
    {
        if (porta2 != null && porta2.segundoQuiz)
        {
            segundos2 += Time.deltaTime;

            if (segundos2 >= 6)
            {
                segundos2 = 0;
                ActivateRandomSpawner();
            }
        }
    }

    void ActivateRandomSpawner()
    {
        numAleatorio2 = Random.Range(0, 3);

        switch (numAleatorio2)
        {
            case 0:
                Instantiate(enemyAcido, spawn1Sala2.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemyAcido, spawn2Sala2.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemyAcido, spawn3Sala2.transform.position, Quaternion.identity);
                break;
        }

    }
}
