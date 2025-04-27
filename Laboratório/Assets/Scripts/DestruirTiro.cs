using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f; // Tempo para destruir automaticamente (caso não acerte nada)

    void Start()
    {
        Destroy(gameObject, lifetime); // Se não bater em nada, some depois de X segundos
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Quando encostar em qualquer coisa, destrói a bala
    }
}