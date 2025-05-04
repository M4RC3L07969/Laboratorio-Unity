using UnityEngine;

public class bossFollow : MonoBehaviour
{
    public float health = 90f;
    public float velocidade = 0.5f;
    public Rigidbody inimigoRb;
    public GameObject player;
    private bool isDead = false;
    private Animator animator;

    void Start()
    {
        inimigoRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player (1)");
    }

    void Update()
    {
        if (isDead) return; 
        Vector3 direction = (player.transform.position - transform.position).normalized;

        bool isMoving = direction.sqrMagnitude > 0.1f;
        animator.SetBool("isWalking", isMoving);

        inimigoRb.AddForce(direction * velocidade);

        Vector3 lookAtPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(lookAtPosition);

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    TakeDamage(20f);        
        //}
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
        inimigoRb.isKinematic = true;  // Para a física e o movimento
        animator.SetBool("isWalking", false);  // Para a animação de movimento
        animator.SetBool("isDead", true);  // Ativa a animação de morte
        animator.SetBool("isDead", true);
        //Destroy(gameObject);
    }
}