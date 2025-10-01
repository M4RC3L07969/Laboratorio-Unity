using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMorrer : MonoBehaviour
{
    public int vidaInimigo = 5;
    public int vidaMaxima = 10;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
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
            else if (collision.gameObject.tag == "bala base" && vidaInimigo <= vidaMaxima)
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
            else if (collision.gameObject.tag == "bala base" && vidaInimigo <= vidaMaxima)
            {
                vidaInimigo += 1;
            }
        }

        if (vidaInimigo <= 0)
        {
            animator.SetBool("isDead", true);
            Destroy(gameObject);
            return;
        }
    }
}
