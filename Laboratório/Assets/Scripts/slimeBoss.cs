using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeBoss : MonoBehaviour
{
    public float velocidade = 4f;
    public GameObject player;

    private float fixedY; 

    void Start()
    {
        player = GameObject.Find("Player 1");
        fixedY = transform.position.y; 
    }

    void Update()
    {
        if (player == null) return;

        Vector3 targetPosition = new Vector3(player.transform.position.x, fixedY, player.transform.position.z);

        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance < 35f)

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
}
