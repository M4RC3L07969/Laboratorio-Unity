using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 0;

    private bool hasCollided = false;

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
       Destroy(this.gameObject);
    }
}