using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

using UnityEngine;

public class InimigoMorrer : MonoBehaviour
{
    public int vidaInimigo = 5;
    public int vidaMaxima = 10;
    public int tamanhoInicial = 5;
    public float aumentoTamanho = 1.5f;
    private int contadorAumentos = 0;
    private float tamanhoAtual;

    private void Start()
    {
        //tamanhoAtual = tamanhoInicial;
        //transform.localScale = new Vector3(tamanhoInicial, tamanhoInicial, tamanhoInicial);
    }

    void Update()
    {
        if (contadorAumentos >= 5)
        {
            return;
        }

        //transform.localScale = new Vector3(tamanhoAtual, tamanhoAtual, tamanhoAtual);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Inimigo base")
        {
            if (collision.gameObject.tag == "bala ácido")
            {
                vidaInimigo -= 1;
                
                
            }
            else if (collision.gameObject.tag == "bala base" && vidaInimigo <= vidaMaxima)
            {
                vidaInimigo += 1;
                AumentarTamanhoInimigo();
            }
        }
        else if (gameObject.tag == "Inimigo ácido")
        {
            if (collision.gameObject.tag == "bala ácido")
            {
                vidaInimigo -= 1;
                
            }
            else if (collision.gameObject.tag == "bala base" && vidaInimigo <= vidaMaxima)
            {
                vidaInimigo += 1;
                AumentarTamanhoInimigo();
            }
        }

        if (vidaInimigo <= 0)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void AumentarTamanhoInimigo()
    {
        if (contadorAumentos < 5)
        {
            tamanhoAtual *= aumentoTamanho;
            contadorAumentos++;
        }
    }
}