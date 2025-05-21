using UnityEngine;



public class testBoss : MonoBehaviour
{
    public int health = 90;
    public float velocidade = 0.5f;
    public Rigidbody inimigoRb;
    public GameObject player;
    public float attackDistance = 1.0f;
    public float distanceToStop = 1.0f;
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
        if (isDead || player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > distanceToStop)
        {
            velocidade = 2f;
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * velocidade * Time.deltaTime;
            animator.SetBool("isWalking", true);


            Vector3 lookatposition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(lookatposition);
        }
        else
        {
            velocidade = 0f;
            animator.SetBool("isWalking", false);
            animator.SetTrigger("Attack");

            FPSController fps = player.GetComponent<FPSController>();
            if (fps != null)
            {
                fps.life -= 5f;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
        {
            if (isDead) return;
            if (other.CompareTag("bala ácido"))
            {
                health -= 10;
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("bala base"))
            {
                health += 10;
                Destroy(other.gameObject);
            }

            if (health <= 0)
            {
                isDead = true;
                inimigoRb.isKinematic = true;
                animator.SetBool("isWalking", false);
                animator.SetBool("isDead", true);
            }
        }

    }


