using System.Collections;
using UnityEngine;

public class slimeBoss : MonoBehaviour
{
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

    void Awake()
    {
        rend = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();
        originalColor = rend.sharedMaterial.color;
    }

    void Start()
    {
        player = GameObject.Find("Player");
        fixedY = transform.position.y;
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("bala ácido"))
    //    {
    //        Flash();
    //        health--;
    //    }
    //    else
    //    {
    //        health++;
    //    }
    //}

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

    private void HandleProjectileHit(Collision collision, Material projectileMaterial, Material bossMaterial)
    {
        if (bossMaterial == projectileMaterial)
        {
            health += 10; // cura
            Debug.Log("Boss curou!");
        }
        else
        {
            health -= 10; // dano
            Flash();
            Debug.Log("Boss tomou dano!");
        }

        Destroy(collision.gameObject);
        BossStatus();
    }


    public void Flash()
    {
        StopCoroutine("FlashRoutine");
        StartCoroutine("FlashRoutine");
    }

    IEnumerator FlashRoutine()
    {
        float t = 0f;

        while (t < flashDuration)
        {
            float lerp = Mathf.Sin((t / flashDuration) * Mathf.PI);

            rend.GetPropertyBlock(mpb);
            mpb.SetColor("_Color", Color.Lerp(originalColor, hitColor, lerp));
            rend.SetPropertyBlock(mpb);

            t += Time.deltaTime;
            yield return null;
        }

        rend.GetPropertyBlock(mpb);
        mpb.SetColor("_Color", originalColor);
        rend.SetPropertyBlock(mpb);
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
}
