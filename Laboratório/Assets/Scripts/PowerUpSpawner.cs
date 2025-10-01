using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;
    public int mortesParaSpawn = 5;

    private int mortesContador = 0;

    public void RegisterKill(Vector3 ignoredPos)
    {
        mortesContador++;

        if (mortesContador >= mortesParaSpawn)
        {
            SpawnPowerUp();
            mortesContador = 0;
        }
    }

    private void SpawnPowerUp()
    {
        if (powerUps.Length == 0)
        {
            Debug.LogWarning("Nenhum power-up definido para spawnar!");
            return;
        }

        int index = Random.Range(0, powerUps.Length);

        // Spawn no topo do objeto que tem esse script
        Vector3 spawnPosition = transform.position + Vector3.up * 1.0f; // 1 unidade acima, ajuste se quiser

        Instantiate(powerUps[index], spawnPosition, Quaternion.identity);
    }
}
