using UnityEngine;



public class bossFollow : MonoBehaviour
{
    public int health = 400;
    public float velocidade = 0.5f;
    public Rigidbody inimigoRb;
    public GameObject player;
    public float attackDistance = 2.0f;

    private bool isDead = false;
    private bool canAttack = true;

    //private Animator animator;

    void Start()
    {
        inimigoRb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > attackDistance)
        {

            Vector3 direction = (player.transform.position - transform.position).normalized;
            direction.y = 0;

            //animator.SetBool("isWalking", true);
            //animator.ResetTrigger("Attack");

            Vector3 newPosition = transform.position + direction * velocidade * Time.fixedDeltaTime;
            inimigoRb.MovePosition(newPosition);

            Vector3 lookAtPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(lookAtPosition);

            canAttack = true;

        }
        else
        {
            inimigoRb.velocity = Vector3.zero;

            if (canAttack)
            {
                FPSController fps = player.GetComponent<FPSController>();
                if (fps != null)
                {
                    fps.life -= 5f;
                }
                canAttack = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;
        if (other.CompareTag("bala ácido"))
        {
            health -= 10;
            bossStatus();
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
           // animator.SetBool("isWalking", false);
           // animator.SetBool("isDead", true);
        }
    }

    void bossStatus()
    {
        //Aqui vai vir o esquema pra trocar de cor / tipo do boss.
        // 1 - Parar animação de andar || 2 - Fazer animação de troca de cor || 3 - Fazer a troca de cor. 
        switch (health)
        {
            case 300:
                Debug.Log("state 1");
                break;
            case 200:
                Debug.Log("state 2");
                break;
            case 100:
                Debug.Log("state 3");
                break;

            default: break;

        }
 
    }
}



