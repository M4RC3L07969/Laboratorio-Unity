using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMorrer : MonoBehaviour
{
    public int vidaInimigo = 5;
    public int vidaMaxima = 10;
    public int tamanhoInicial = 5;
    public float aumentoTamanho = 1.5f;
    private int contadorAumentos = 0;
    private float tamanhoAtual;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (contadorAumentos >= 5)
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Inimigo base"))
        {
            if (collision.gameObject.CompareTag("bala ácido"))
            {
                animator.SetTrigger("hit");
                vidaInimigo -= 1;
            }
            else if (collision.gameObject.CompareTag("bala base") && vidaInimigo <= vidaMaxima)
            {
                vidaInimigo += 0;
            }
        }
        else if (gameObject.CompareTag("Inimigo ácido"))
        {
            if (collision.gameObject.CompareTag("bala base"))
            {
                animator.SetTrigger("hit");
                vidaInimigo -= 1;
            }
            else if (collision.gameObject.CompareTag("bala ácido") && vidaInimigo <= vidaMaxima)
            {
                vidaInimigo += 0;
            }
        }

        if (vidaInimigo <= 0)
        {
            enabled = false;
            StartCoroutine(Morrer());
        }
    }

    IEnumerator Morrer()
    {
        animator.SetBool("isDead", true);

        if (PowerUpManager.Instance != null)
        {
            PowerUpManager.Instance.InimigoDerrotado();
        }

        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }
}