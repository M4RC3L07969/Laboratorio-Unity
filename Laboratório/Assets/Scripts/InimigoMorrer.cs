using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMorrer : MonoBehaviour
{
    public int vidaInimigo = 5;
    public int vidaMaxima = 10;
    private Animator animator;

    private PowerUpSpawner powerUpSpawner;

    private void Start()
    {
        animator = GetComponent<Animator>();
        powerUpSpawner = FindObjectOfType<PowerUpSpawner>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Inimigo base")
        {
            if (collision.gameObject.tag == "bala ácido")
            {
                animator.SetTrigger("hit");
                vidaInimigo -= 1;
            }
            else if (collision.gameObject.tag == "bala base" && vidaInimigo < vidaMaxima)
            {
                vidaInimigo += 1;
            }
        }
        else if (gameObject.tag == "Inimigo ácido")
        {
            if (collision.gameObject.tag == "bala ácido")
            {
                animator.SetTrigger("hit");
                vidaInimigo -= 1;
            }
            else if (collision.gameObject.tag == "bala base" && vidaInimigo < vidaMaxima)
            {
                vidaInimigo += 1;
            }
        }

        if (vidaInimigo <= 0)
        {
            animator.SetBool("isDead", true);

            if (powerUpSpawner != null)
            {
                powerUpSpawner.RegisterKill(transform.position);
            }

            Destroy(gameObject);
        }
    }
}
