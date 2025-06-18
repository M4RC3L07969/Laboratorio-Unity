using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private abrirPorta porta1;

    public GameObject spawn1Sala1;
    public GameObject spawn2Sala1;
    public GameObject spawn3Sala1;
    public int numAleatorio1 = 0;
    public float segundos1 = 0f;
    public GameObject enemyBase;

    void Update()
    {
        if (porta1 != null && porta1.primeiroQuiz)
        {
            segundos1 += Time.deltaTime;

            if (segundos1 >= 6)
            {
                segundos1 = 0;
                ActivateRandomSpawner();
            }
        }
    }

    void ActivateRandomSpawner()
    {
        numAleatorio1 = Random.Range(0, 3);

        switch (numAleatorio1)
        {
            case 0:
                Instantiate(enemyBase, spawn1Sala1.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemyBase, spawn2Sala1.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemyBase, spawn3Sala1.transform.position, Quaternion.identity);
                break;
        }

    }

}
