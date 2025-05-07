using UnityEngine;

public class bossFollow : MonoBehaviour
{
    public float health = 90f;
    public float velocidade = 0.5f;
    public Rigidbody inimigoRb;
    public GameObject player;
    public float attackDistance = 2.0f;

    private bool isDead = false;
    private bool canAttack = true;

    private Animator animator;

    void Start()
    {
        inimigoRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player (1)");
    }

    void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > attackDistance)
        {
            // Aproximação
            Vector3 direction = (player.transform.position - transform.position).normalized;
            inimigoRb.AddForce(direction * velocidade);

            animator.SetBool("isWalking", true);
            animator.ResetTrigger("Attack");

            Vector3 lookAtPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(lookAtPosition);

            canAttack = true; // permite novo ataque se sair da área
        }
        else
        {
            // Parar e atacar
            inimigoRb.velocity = Vector3.zero;
            animator.SetBool("isWalking", false);

            if (canAttack)
            {
                animator.SetTrigger("Attack");
                FPSController fps = player.GetComponent<FPSController>();
                if (fps != null)
                {
                    fps.life -= 10f;
                }
                canAttack = false;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        inimigoRb.isKinematic = true;
        animator.SetBool("isWalking", false);
        animator.SetBool("isDead", true);
    }
}
