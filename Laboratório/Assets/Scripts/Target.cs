using UnityEngine;

public class Target : MonoBehaviour
{
    public float velocidade = 5f;                // velocidade de movimento (em unidades/segundo)
    public Rigidbody inimigoRb;
    public GameObject player;
    private Animator animator;
    private PlayerMovement playerMovement;
    private string[] action = { "kick", "punch" };

    
    public float attackCooldown = 1f;            
    private float lastAttackTime = 0f;

    void Start()
    {
        inimigoRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        if (player != null)
            playerMovement = player.GetComponent<PlayerMovement>();

        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        
        if (distance < 5f)
        {
            inimigoRb.velocity = Vector3.zero;

            
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                string actualAction = action[Random.Range(0, action.Length)];
                animator.SetTrigger(actualAction);
                playerMovement.TakeDamage(1);

                lastAttackTime = Time.time;
            }

            
            LookAtPlayer();
        }
        
        else if (distance < 25f)
        {
            animator.SetBool("isNear", true);

            Vector3 direction = (player.transform.position - transform.position).normalized;
            Vector3 newPosition = transform.position + direction * velocidade * Time.fixedDeltaTime;
            inimigoRb.MovePosition(newPosition);

            LookAtPlayer();
        }
        
        else
        {
            inimigoRb.velocity = Vector3.zero;
        }
    }

    private void LookAtPlayer()
    {
        Vector3 lookAtPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(lookAtPosition);
    }
}
