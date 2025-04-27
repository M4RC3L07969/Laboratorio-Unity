using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float healthBoss;
    public float speedBoss;
    private Animator animator;

    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("animator not found.");
        }

        StartCoroutine(AttackRoutine());
    }

    void Update()
    {

    }

    IEnumerator AttackRoutine()
    {
        while (healthBoss > 0)
        {
            if (!isAttacking)
            {
                float randomTime = Random.Range(3f, 6f);
                yield return new WaitForSeconds(randomTime);

                isAttacking = true;
                animator.SetBool("isFighting", true);

                yield return new WaitForSeconds(1f);

                isAttacking = false;
                animator.SetBool("isFighting", false);
            }
            yield return null;
        }
        
    }


    public void heal(float value)
    {
        healthBoss += value;
        
    }
    void OnTriggerEnter(Collider obj)
    {
        if(obj.GetComponent<Gun>())
        {
           Gun bt = obj.GetComponent<Gun>();
           healthBoss -= bt.damage;
           Debug.Log("Health: " + healthBoss);
            Die();
        }
    }

    public void Die()
    {
        if (healthBoss <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
}

