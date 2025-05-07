using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float healthBoss;
    public float speedBoss;
    private Animator animator;

    private bool isAttacking = false;

    private enum BossType { Normal, Healing }
    private BossType currentBossType;
 

    void Start()
    {
        
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator não encontrado.");
        }


        currentBossType = BossType.Normal;
        StartCoroutine(AttackRoutine());
        StartCoroutine(ChangeBossTypeRoutine());
    }

    IEnumerator ChangeBossTypeRoutine()
    {
        while (healthBoss > 0)
        {
            yield return new WaitForSeconds(8f);

            if (currentBossType == BossType.Normal)
            {
                currentBossType = BossType.Healing;
               
            }
            else
            {
                currentBossType = BossType.Normal;
                
            }

            Debug.Log("Boss status: " + currentBossType);
        }
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

    public void TakeHit(float damageAmount, bool isHealing)
    {
        if (currentBossType == BossType.Healing && isHealing)
        {
            healthBoss += damageAmount;
            Debug.Log("Vida atual: " + healthBoss);
        }
        else if (currentBossType == BossType.Normal && !isHealing)
        {
            healthBoss -= damageAmount;
            Debug.Log("Vida atual: " + healthBoss);
            Die();
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.GetComponent<Gun>())
        {
            Gun bt = obj.GetComponent<Gun>();
            TakeHit(bt.damage, bt.isHealingGun);
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
