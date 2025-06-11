using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    bool isMoving;
    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    // --- Sistema de Vida ---
    public int maxHealth = 100;
    private int currentHealth;

    // --- Sistema de Invencibilidade ---
    public float invulnerabilityTime = 1f; // Tempo de invencibilidade ap�s tomar dano
    private bool isInvulnerable = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentHealth = maxHealth;
        Debug.Log("[PLAYER] Vida inicial: " + currentHealth + "/" + maxHealth);
    }

    void Update()
    {
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (lastPosition != gameObject.transform.position && isGrounded == true)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            lastPosition = gameObject.transform.position;
        }
    }
}
//}
//// --- M�todo para receber dano ---
//private void TakeDamage(int amount, string enemyType = "Desconhecido")
//{
//    // Verifica se o player est� invulner�vel
//    if (isInvulnerable)
//    {
//        Debug.Log("[DANO BLOQUEADO] Player est� invulner�vel! Dano de " + amount + " foi bloqueado.");
//        return;
//    }

//    // Debug detalhado do dano
//    Debug.Log("=== SISTEMA DE DANO ===");
//    Debug.Log("[DANO RECEBIDO] Tipo de inimigo: " + enemyType);
//    Debug.Log("[DANO RECEBIDO] Quantidade de dano: " + amount);
//    Debug.Log("[VIDA ANTES] " + currentHealth + "/" + maxHealth);

//    currentHealth -= amount;

//    Debug.Log("[VIDA DEPOIS] " + currentHealth + "/" + maxHealth);
//    Debug.Log("[DANO] Dano aplicado com sucesso!");

//    // Ativa invencibilidade tempor�ria
//    StartCoroutine(InvulnerabilityCoroutine());

//    if (currentHealth <= 0)
//    {
//        Die();
//    }
//    else
//    {
//        Debug.Log("[STATUS] Player ainda est� vivo. Vida restante: " + currentHealth);
//    }

//    Debug.Log("======================");
//}

//// Corrotina para controlar invencibilidade
//public IEnumerator InvulnerabilityCoroutine()
//{
//    isInvulnerable = true;
//    Debug.Log("[INVENCIBILIDADE] Ativada por " + invulnerabilityTime + " segundos");

//    yield return new WaitForSeconds(invulnerabilityTime);

//    isInvulnerable = false;
//    Debug.Log("[INVENCIBILIDADE] Desativada - Player pode tomar dano novamente");
//}

//void Die()
//{
//    Debug.Log("=== MORTE DO PLAYER ===");
//    Debug.Log("[MORTE] O jogador morreu!");
//    Debug.Log("[MORTE] Vida final: " + currentHealth + "/" + maxHealth);
//    Debug.Log("=====================");

//    gameObject.SetActive(false); // Desativa o jogador
//}

// --- Detec��o de colis�o com inimigos ---
//private void OnCollisionEnter(Collision collision)
//{
//    Debug.Log("[COLIS�O] Detectada colis�o com: " + collision.gameObject.name + " (Tag: " + collision.gameObject.tag + ")");

//    // Verifica tag do Inimigo �cido
//    //if (collision.gameObject.CompareTag("Inimigo ácido"))
//    //{
//    //    Debug.Log("[COLIS�O] Colidiu com Inimigo �cido!");
//    //    TakeDamage(10, "Inimigo ácido");
//    //}
//    // Verifica tag do Inimigo Base
//    else if (collision.gameObject.CompareTag("Inimigo base"))
//    {
//        Debug.Log("[COLIS�O] Colidiu com Inimigo Base!");
//        TakeDamage(10, "Inimigo Base");
//    }
//    else
//    {
//        Debug.Log("[COLIS�O] Tag n�o reconhecida como inimigo: " + collision.gameObject.tag);
//    }
//}

// --- Detec��o de trigger (caso alguns inimigos usem trigger ao inv�s de collision) ---
//private void OnTriggerEnter(Collider other)
//{
//    Debug.Log("[TRIGGER] Detectado trigger com: " + other.gameObject.name + " (Tag: " + other.gameObject.tag + ")");

// Verifica tag do Inimigo �cido
//    if (other.gameObject.CompareTag("Inimigo �cido"))
//    {
//        Debug.Log("[TRIGGER] Trigger com Inimigo �cido!");
//        TakeDamage(10, "Inimigo �cido");
//    }
//    // Verifica tag do Inimigo Base
//    else if (other.gameObject.CompareTag("Inimigo base"))
//    {
//        Debug.Log("[TRIGGER] Trigger com Inimigo Base!");
//        TakeDamage(10, "Inimigo Base");
//    }
//    else
//    {
//        Debug.Log("[TRIGGER] Tag n�o reconhecida como inimigo: " + other.gameObject.tag);
//    }
//}

// --- M�todos p�blicos para debug ---
//    public int GetCurrentHealth()
//    {
//        return currentHealth;
//    }

//    public void SetHealth(int newHealth)
//    {
//        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
//        Debug.Log("[SA�DE ALTERADA] Nova vida: " + currentHealth + "/" + maxHealth);
//    }

//    public void Heal(int amount)
//    {
//        int oldHealth = currentHealth;
//        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
//        Debug.Log("[CURA] Curado " + amount + " pontos. Vida: " + oldHealth + " -> " + currentHealth);
//    }
//}

