using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Garante que o Image seja reconhecido
// using static UnityEditor.FilePathAttribute; // Removido
// using UnityEngine.UIElements; // Removido

public class slimeBoss : MonoBehaviour
{
    // --- Prefabs e Efeitos ---
    public Transform firepoint;
    public GameObject projetilBossBase;
    public GameObject projetilBossAcido;
    public GameObject efeitoPrefab; // Deve aparecer no Inspector agora que os 'using' problemáticos foram removidos.
    public float effectLifetime = 2f;

    public float shootInterval = 20f;


    [Header("Weapon Controller")]
    public float bulletVelocity = 20f;
    public float bulletPrefabLife = 3f;

    // // Flash de dano - REMOVIDO
    // Renderer rend;
    // MaterialPropertyBlock mpb;
    // public Color hitColor = Color.red;
    // public float flashDuration = 0.15f;
    // private Color originalColor;

    // Movimento / status
    public float velocidade = 4f;
    public GameObject player;
    public int health = 400; // Vida principal
    private readonly int maxHealth = 400; // Adicionado para cálculo de barra de vida
    private float fixedY;
    private int stageBoss = 0;
    private bool morto = false;

    public Material Material1; // arrastar o material verde da bala ácido
    public Material Material2; // arrastar o material roxo da bala base

    public Image healthbar;
    // public float healthAmount = 100f; // Removido, usando 'health' principal

    void Awake()
    {
        // Rendere e Flash de Dano removidos do Awake
        // rend = GetComponent<Renderer>();
        // mpb = new MaterialPropertyBlock();
        // originalColor = rend.material.color; 
    }

    void Start()
    {
        player = GameObject.Find("Player (1)");
        fixedY = transform.position.y;
        StartCoroutine(AttackTimer());
    }

    void Update()
    {
        if (player == null) return;

        Vector3 targetPosition = new Vector3(player.transform.position.x, fixedY, player.transform.position.z);
        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance < 50f)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * velocidade * Time.deltaTime;
            LookAtPlayer(targetPosition);
        }

        // Unificado a verificação de morte no Update
        if (health <= 0 || morto == true)
        { 
                if (efeitoPrefab != null)
                {
                    GameObject effect = Instantiate(
                        efeitoPrefab,
                        transform.position,
                        Quaternion.identity
                    );
                    Destroy(effect, effectLifetime);
                }
                Destroy(gameObject);
                morto = false;
            
        }
    }

    private void LookAtPlayer(Vector3 targetPosition)
    {
        Vector3 lookAtPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        transform.LookAt(lookAtPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // NOTA: Para este método funcionar corretamente, o Boss precisa ter um Renderer
        // e o material que você deseja comparar deve ser obtido de forma segura (e ser o material de "cor" do slime).
        Renderer rend = GetComponent<Renderer>(); // Pega o Renderer na colisão, se necessário
        if (rend == null) return;

        Material bossMaterial = rend.sharedMaterial;

        if (collision.gameObject.CompareTag("bala ácido"))
        {
            HandleProjectileHit(collision, Material1, bossMaterial);
        }
        else if (collision.gameObject.CompareTag("bala base"))
        {
            HandleProjectileHit(collision, Material2, bossMaterial);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (healthbar != null)
        {
            healthbar.fillAmount = (float)health / (float)maxHealth;
        }

        // Flash de Dano REMOVIDO daqui
    }

    public void Heal(int healingAmount)
    {
        health += healingAmount;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (healthbar != null)
        {
            healthbar.fillAmount = (float)health / (float)maxHealth;
        }
    }

    private void HandleProjectileHit(Collision collision, Material projectileMaterial, Material bossMaterial)
    {
        if (bossMaterial == projectileMaterial)
        {
            Heal(10); // cura
            Debug.Log("Boss curou!");
        }
        else
        {
            TakeDamage(10); // dano
            Debug.Log("Boss tomou dano!");
        }

        Destroy(collision.gameObject);
        BossStatus();
    }

    // Corrotina de Flash de Dano REMOVIDA

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(shootInterval);

        while (true)
        {
            if (!morto)
            {
                Fire();
            }
            yield return new WaitForSeconds(shootInterval);
        }
    }

    public void BossStatus()
    {
        // Troca de fase/escala
        if (health < maxHealth && stageBoss == 0)
        {
            stageBoss = 1;
            StartCoroutine(PauseBoss());
            transform.localScale *= 3f;
        }
        else if (health <= (maxHealth / 2) && stageBoss == 1)
        {
            stageBoss = 2;
            StartCoroutine(PauseBoss());
            transform.localScale *= 1.5f;
        }
        else if (health <= 0)
        {
            morto = true;
        }
    }

    IEnumerator PauseBoss()
    {
        yield return new WaitForSeconds(2f);
    }

    private void Fire()
    {
        if (player == null || firepoint == null)
        {
            return;
        }

        Vector3 directionToPlayer = (player.transform.position - firepoint.position).normalized;

        GameObject projetil = Instantiate(projetilBossAcido, firepoint.position, Quaternion.identity);
        Rigidbody rb = projetil.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(directionToPlayer * bulletVelocity, ForceMode.Impulse);
        }
        Destroy(projetil, bulletPrefabLife);
    }
}