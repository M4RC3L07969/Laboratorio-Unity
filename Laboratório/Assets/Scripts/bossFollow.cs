using UnityEngine;
using System.Collections;

public class bossFollow : MonoBehaviour
{
    public int health = 400;
    public float velocidade = 0.5f;
    public Rigidbody inimigoRb;
    public GameObject player;
    public float attackDistance = 2.0f;
    private bool isDead = false;
    private bool canAttack = true;

    private bool invulnerable = false;
    private bool isPaused = false;
    private Renderer[] renderers;


    private int stageBoss = 0;
   

    void Start()
    {
        inimigoRb = GetComponent<Rigidbody>();
        renderers = GetComponentsInChildren<Renderer>();
        player = GameObject.Find("Player");
   
    }

    void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        Vector3 lookAtPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(lookAtPosition);

        if (!isPaused)
        {
            if (distance > attackDistance)
            {

                Vector3 direction = (player.transform.position - transform.position).normalized;
                direction.y = 0;


                //animator.SetBool("isWalking", true);
                //animator.ResetTrigger("Attack");

                Vector3 newPosition = transform.position + direction * velocidade * Time.fixedDeltaTime;
                inimigoRb.MovePosition(newPosition);



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
        

    }

    void ChangeBossColor(Color color)
    {
        foreach (Renderer r in renderers)
        {
            r.material.color = color;
        }
    }

    IEnumerator PauseBoss()
    {
        isPaused = true;
        invulnerable = true;

        inimigoRb.velocity = Vector3.zero;
        inimigoRb.isKinematic = true;
        yield return new WaitForSeconds(4f);
       
        inimigoRb.isKinematic = false;

        invulnerable = false;
        isPaused = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isDead || invulnerable) return;
        if (other.CompareTag("bala ácido"))
        {
            if (stageBoss == 1)
            {
                health += 10;
                return;
            }
            health -= 10;
            bossStatus();
            Destroy(other.gameObject);
            checkDeath();
        }
        else if (other.CompareTag("bala base"))
        {
            if (stageBoss == 1)
            {
                health -= 10;
                bossStatus();
                Destroy(other.gameObject);
                checkDeath();
                return;
            }
            health += 10;
            Destroy(other.gameObject);
        }
    }
    void checkDeath()
    {
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
        // 1 - Parar animação de andar e de andar tambem. || 2 - Fazer animação de troca de cor. || 3 - Fazer a troca de cor. 
        switch (health)
        {
            
            case 300:
                if (stageBoss == 1) break;
                Debug.Log("stage 1");
                stageBoss = 1;
                ChangeBossColor(Color.red);
                StartCoroutine(PauseBoss());
                break;
            case 200:
                if (stageBoss == 0) break;
                Debug.Log("stage 2");
                stageBoss = 0;
                ChangeBossColor(Color.yellow);
                StartCoroutine(PauseBoss());
                break;
            case 100:
                if (stageBoss == 1) break;
                Debug.Log("stage 3");
                stageBoss = 1;
                ChangeBossColor(Color.gray);
                StartCoroutine(PauseBoss());
                break;

            default: break;

        }
 
    }
}



