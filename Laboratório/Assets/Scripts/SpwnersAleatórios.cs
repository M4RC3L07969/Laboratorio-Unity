using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public int numAleatorio = 0;
    public float segundos = 0f;
    public GameObject enemy_prefeb;

    void Update()
    {
        if (segundos >= 6)
        {
            segundos = 0;
            ActivateRandomSpawner();
        }


        segundos += Time.deltaTime;
    }

    void ActivateRandomSpawner()
    {
        numAleatorio = Random.Range(0, 3);

        switch (numAleatorio)
        {
            case 0:
                Instantiate(enemy_prefeb, spawn1.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemy_prefeb, spawn2.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy_prefeb, spawn3.transform.position, Quaternion.identity);
                break;
        }

    }

}
