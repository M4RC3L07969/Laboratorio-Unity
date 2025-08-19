using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;
    public float velocidade = 10f;
    public Rigidbody inimigoRb;
    public GameObject player;
    private Animator animator;
    private PlayerMovement playerMovement;
    private string[] action = { "kick", "punch" };

    void Start()
    {
        inimigoRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        if (player != null)
            playerMovement = player.GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
   
    }

    void Update()
    {
        if (player == null) return;
        float distance = Vector3.Distance(transform.position, player.transform.position);

        
        if (distance < 4f)
        {
            string actualAction = action[UnityEngine.Random.Range(0, action.Length)];
            animator.SetTrigger(actualAction);
            playerMovement.TakeDamage(1);
        }

        else
        {
            
            animator.SetBool("isNear", true);

            Vector3 direction = (player.transform.position - transform.position).normalized;
            
            Debug.Log($"Direção: {direction}, Posição Player: {player.transform.position}, Posição Inimigo: {transform.position}");
            
            transform.position += direction * velocidade * Time.deltaTime;
        }

   
        Vector3 lookAtPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(lookAtPosition);
    }


}