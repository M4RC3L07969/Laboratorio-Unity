using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;
    public float velocidade = 2f;
    public Rigidbody inimigoRb;
    public GameObject player;
    private Animator animator;

    void Start()
    {
        inimigoRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 direction = (player.transform.position).normalized;

        inimigoRb.AddForce(direction * velocidade);

        Vector3 lookAtPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(lookAtPosition);
        animator.SetBool("isNear",true);
       

    }

    public void TakeDamage(float amount)
    {
        animator.SetTrigger("hit");
        health -= amount;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
