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
    private BoxCollider colisor;

    public AudioClip inimigoMorrendoClip;
    public AudioSource inimigoMorrendoSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        colisor = GetComponent<BoxCollider>();

        if (inimigoMorrendoSource == null)
            inimigoMorrendoSource = gameObject.AddComponent<AudioSource>();



        inimigoMorrendoSource.clip = inimigoMorrendoClip;
        inimigoMorrendoSource.playOnAwake = false;
        inimigoMorrendoSource.volume = 0.6f;
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
        inimigoMorrendoSource.Play();
        animator.SetBool("isDead", true);

        if (PowerUpManager.Instance != null)
        {
            PowerUpManager.Instance.InimigoDerrotado();
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 1. Zera a velocidade e o momento
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // 2. Torna o Rigidbody Kinematic. Isso congela o objeto no lugar e ignora a gravidade.
            rb.isKinematic = true;
        }

        // 3. Agora que o Rigidbody está Kinematic e não será afetado pela gravidade, 
        // desativamos o colisor para que o player e os tiros o atravessem.
        if (colisor != null)
        {
            colisor.enabled = false;
            Debug.Log(gameObject.name + " Collider desativado para permitir passagem.");
        }

        yield return new WaitForSeconds(5f);

        // Destrói o objeto
        Destroy(gameObject);
    }
}