using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // <- Importante para mexer na UI

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
    public GameManager gameManager;
    private bool isDead;

    // --- Sistema de Vida ---
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI de Vida")]
    public Image healthBar; // Arrasta a imagem da barra no Canvas aqui

    // --- Sistema de Invencibilidade ---
    public float invulnerabilityTime = 1f;
    private bool isInvulnerable = false;

    // --- Power-Up de Velocidade ---
    public float speedBoostAmount = 8f;
    public float speedBoostDuration = 5f;
    private bool isSpeedBoosted = false;

    // --- Power-Up de Escudo ---
    public GameObject shieldVisual;
    public float shieldDuration = 5f;
    private bool isShieldActive = false;

    // --- Power-Up de Cura ---
    public int healAmount = 30;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentHealth = maxHealth;
        if (shieldVisual != null) shieldVisual.SetActive(false);
        UpdateHealthUI(); // Inicia a UI correta
        Debug.Log("[PLAYER] Vida inicial: " + currentHealth + "/" + maxHealth);
    }

    void Update()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PU"))
        {
            ApplySpeedBoost();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ShieldPU"))
        {
            ActivateShield();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("HealPU"))
        {
            HealPlayer(healAmount);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Inimigo base") || other.CompareTag("Inimigo ácido"))
        {
            if (!isShieldActive)
            {
                TakeDamage(10);
            }
            else
            {
                Debug.Log("[ESCUDO] Dano bloqueado pelo escudo!");
            }
        }
        if (other.CompareTag("balaSlime"))
        {
            if (!isShieldActive)
            {

                TakeDamage(15);
                Debug.Log("[BOSS] Dano de projétil recebido!");
            }
            else
            {
                Debug.Log("[ESCUDO] Projétil do Boss bloqueado!");
            }


            Destroy(other.gameObject);
        }
    }

    public void ApplySpeedBoost()
    {
        if (!isSpeedBoosted)
        {
            StartCoroutine(SpeedBoostCoroutine());
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        Debug.Log("[PLAYER] Vida:" + currentHealth + "/" + maxHealth);

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;

            // Desativa o movimento do player
            GetComponent<CharacterController>().enabled = false;
            this.enabled = false; // desativa PlayerMovement

            // Desativa MouseMovement
            MouseMovement mouseScript = GetComponentInChildren<MouseMovement>();
            if (mouseScript != null)
            {
                mouseScript.enabled = false;
            }

            // Desativa WeaponSwitcher
            WeaponSwitcher weaponScript = GetComponentInChildren<WeaponSwitcher>();
            if (weaponScript != null)
            {
                weaponScript.enabled = false;
            }

            // Chama tela de Game Over
            if (gameManager != null)
            {
                gameManager.GameOver();
            }

            Debug.Log("[PLAYER] morreu");
        }
    }




    private IEnumerator SpeedBoostCoroutine()
    {
        isSpeedBoosted = true;
        float originalSpeed = speed;
        speed += speedBoostAmount;

        Debug.Log("[POWER-UP] Velocidade aumentada para " + speed);

        yield return new WaitForSeconds(speedBoostDuration);

        speed = originalSpeed;
        isSpeedBoosted = false;

        Debug.Log("[POWER-UP] Velocidade retornou ao normal: " + speed);
    }

    public void ActivateShield()
    {
        if (!isShieldActive)
        {
            StartCoroutine(ShieldCoroutine());
        }
    }

    private IEnumerator ShieldCoroutine()
    {
        isShieldActive = true;
        if (shieldVisual != null) shieldVisual.SetActive(true);

        Debug.Log("[ESCUDO] Escudo ativado!");

        yield return new WaitForSeconds(shieldDuration);

        isShieldActive = false;
        if (shieldVisual != null) shieldVisual.SetActive(false);

        Debug.Log("[ESCUDO] Escudo desativado!");
    }


    // --- Função de Cura ---
    public void HealPlayer(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        Debug.Log("[HEAL] Vida curada! Atual: " + currentHealth + "/" + maxHealth);
    }

    // --- Atualiza a barra de vida no Canvas ---
    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
