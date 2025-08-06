using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public Vector3 rotationAxis = Vector3.up;
    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ActivateShield();
                Destroy(gameObject);
            }
        }
    }
}