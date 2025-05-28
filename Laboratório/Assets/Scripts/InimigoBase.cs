using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class InimigoMorrer : MonoBehaviour
{
    // bala base
    // bala ácido
    // Inimigo base
    // Inimigo ácido

    public int vidaInimigo = 5;
    public int vidaMaxima = 10;
    public int tamanhoMaximo = 10;
    public int tamanhoInicial = 5;
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Inimigo base"){
            if (collision.gameObject.tag == "bala ácido")
            {
                vidaInimigo -= 1;
            }
            else
            {
                if (collision.gameObject.tag == "bala base")
                {
                    vidaInimigo += 1;
                }

            }
        }else if (gameObject.tag == "Inimigo ácido")
        {
            if (collision.gameObject.tag == "bala ácido")
            {
                vidaInimigo += 1;
            }
            else
            {
                if (collision.gameObject.tag == "bala base")
                {
                    vidaInimigo -= 1;
                }

            }
        }


        if (vidaInimigo <= 0)
        {
            /*isDead = true;
            inimigoRb.isKinematic = true;
            animator.SetBool("isWalking", false);
            animator.SetBool("isDead", true);*/
        }
    }
}
