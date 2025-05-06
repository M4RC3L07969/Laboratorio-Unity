using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // A bala associada à arma
    public Transform shootPoint;     // O ponto de onde a bala será disparada (geralmente na boca da arma)

    public float shootForce = 10f;  // A força de disparo da bala

    void Update()
    {
        // Disparo ao clicar com o botão esquerdo do mouse
        if (Input.GetMouseButtonDown(0)) // Verifica se o botão esquerdo do mouse foi pressionado
        {
            Shoot();
        }
    }

    // Função para disparar a bala
    void Shoot()
    {
        // Verifica se o shootPoint e a bulletPrefab estão configurados corretamente
        if (bulletPrefab != null && shootPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
            }
        }
    }

    // Função para atualizar o prefab da bala quando a arma muda
    public void UpdateBulletPrefab(GameObject newBulletPrefab)
    {
        bulletPrefab = newBulletPrefab;
    }
}
