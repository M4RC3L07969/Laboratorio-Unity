using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;

    private bool hasCollided = false;

    void Start()
    {
        // Só destrói após X segundos, se não colidir antes
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided)
        {
            hasCollided = true;
            Destroy(gameObject);
        }
    }
}