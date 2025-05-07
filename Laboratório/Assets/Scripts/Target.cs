using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;
    public float velocidade = 2f;
    public Rigidbody inimigoRb;
    public GameObject player;

    void Start()
    {
        inimigoRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

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
            Destroy(gameObject);
        }
    }
}
