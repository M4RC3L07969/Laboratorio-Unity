using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool hasCollided = false;
    public GameObject hitEffectPrefab;
    public GameObject hitEffectPrefabBoss;
    public float hitEffectLifetime = 2f;

    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        // Garante que a colisão seja processada apenas uma vez.
        if (hasCollided) return;
        hasCollided = true;

        ContactPoint contact = collision.contacts[0];
        GameObject collidedObject = collision.gameObject;

        // Variável para escolher qual prefab de efeito usar
        GameObject prefabToInstantiate = null;

        // --- LÓGICA DE CHECAGEM DO BOSS ---

        // 1. Checa se o objeto colidido tem a tag "Boss"
        if (collidedObject.CompareTag("Boss"))
        {
            prefabToInstantiate = hitEffectPrefabBoss;
        }
        // 2. Se não for Boss, usa o efeito padrão
        else
        {
            prefabToInstantiate = hitEffectPrefab;
        }

        // --- INSTANCIAÇÃO DO EFEITO E DESTRUIÇÃO ---

        // Instancia o efeito se tivermos um prefab válido
        if (prefabToInstantiate != null)
        {
            // Instancia o efeito no ponto de impacto, olhando para a normal da superfície
            GameObject effect = Instantiate(
                prefabToInstantiate,
                contact.point,
                Quaternion.LookRotation(contact.normal)
            );

            Destroy(effect, hitEffectLifetime);
        }

        Destroy(this.gameObject);
    }
}