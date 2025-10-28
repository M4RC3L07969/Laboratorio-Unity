using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class slimeBoss : MonoBehaviour
{
    public Transform firepoint;
    public GameObject projetilBossBase;
    public GameObject projetilBossAcido;

    public float shootInterval = 20f;


    [Header("Weapon Controller")]
    public float bulletVelocity = 20f;
    public float bulletPrefabLife = 3f;

    // Flash de dano
    Renderer rend;
    MaterialPropertyBlock mpb;
    public Color hitColor = Color.red;
    public float flashDuration = 0.15f;
    private Color originalColor;

    // Movimento / status
    public float velocidade = 4f;
    public GameObject player;
    public int health = 400;
    private float fixedY;
    private int stageBoss = 0;

    public Material Material1; // arrastar o material verde da bala ácido
    public Material Material2;   // arrastar o material roxo da bala base

    public Image healthbar;
    public float healthAmount = 100f;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();
        originalColor = rend.sharedMaterial.color;
    }

    void Start()
    {
        player = GameObject.Find("Player 1");
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
    }

    private void LookAtPlayer(Vector3 targetPosition)
    {
        Vector3 lookAtPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        transform.LookAt(lookAtPosition);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Material bossMaterial = rend.sharedMaterial; // pega o material atual do boss

        if (collision.gameObject.CompareTag("bala ácido"))
        {
            HandleProjectileHit(collision, Material1, bossMaterial);
        }
        else if (collision.gameObject.CompareTag("bala base"))
        {
            HandleProjectileHit(collision, Material2, bossMaterial);
        }
    }
    public void TakeDamage(float damage)
    {
        healthAmount = damage;
        healthbar.fillAmount = healthAmount / 100;
    }

    public void Heal(float healingAmount)
    {

        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthbar.fillAmount = healthAmount / 100;
    }

    private void HandleProjectileHit(Collision collision, Material projectileMaterial, Material bossMaterial)
    {
        if (bossMaterial == projectileMaterial)
        {
            health += 10; // cura
            Heal(10);
            Debug.Log("Boss curou!");
        }
        else
        {
            health -= 10; // dano
            TakeDamage(10);
            Debug.Log("Boss tomou dano!");
        }

        Destroy(collision.gameObject);
        BossStatus();
    }
    IEnumerator AttackTimer()
    {
        // Wait for the first attack
        yield return new WaitForSeconds(shootInterval);

        // Loop indefinitely to keep attacking
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(shootInterval);
        }
    }
    public void BossStatus()
    {
        // Troca de fase/escala
        if (health < 400 && stageBoss == 0)
        {
            stageBoss = 1;
            StartCoroutine(PauseBoss());
            transform.localScale *= 3f;
        }
        else if (health <= 150 && stageBoss == 1)
        {
            stageBoss = 2;
            StartCoroutine(PauseBoss());
            transform.localScale *= 1.5f;
        }
    }

    IEnumerator PauseBoss()
    {
        // exemplo simples
        yield return new WaitForSeconds(2f);
    }

    private void Fire()
    {
        // Make sure the player object exists before trying to shoot
        if (player == null)
        {
            return;
        }

        // Determine the direction from the firepoint to the player's position
        Vector3 directionToPlayer = (player.transform.position - firepoint.position).normalized;

        GameObject projetil = Instantiate(projetilBossAcido, firepoint.position, Quaternion.identity);
        Rigidbody rb = projetil.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Use the calculated direction to shoot the projectile
            rb.AddForce(directionToPlayer * bulletVelocity, ForceMode.Impulse);
        }
        Destroy(projetil, bulletPrefabLife);
    }
}