using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 0;

    private bool hasCollided = false;

    public GameObject hitEffectPrefab;
    public float hitEffectLifetime = 2f;

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        // Instancia o efeito no ponto de impacto, olhando para a normal da superfície
        if (hitEffectPrefab != null)
        {
            GameObject effect = Instantiate(hitEffectPrefab, contact.point, Quaternion.LookRotation(contact.normal));
            Destroy(effect, hitEffectLifetime);
            Destroy(this.gameObject);
        }
    }
}