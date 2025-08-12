using UnityEngine;

public class TiroExplosivo : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 60f;
    public bool tiroExplosivo;

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

        if (tiroExplosivo == true)
        {
            Debug.Log("Ativo Tiro Explosivo");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tiroExplosivo = true;
            Destroy(gameObject);
        }

        }
    }
