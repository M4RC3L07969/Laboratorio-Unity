using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // A bala associada � arma
    public Transform shootPoint;     // O ponto de onde a bala ser� disparada (geralmente na boca da arma)

    public float shootForce = 10f;  // A for�a de disparo da bala

    void Update()
    {
        // Disparo ao clicar com o bot�o esquerdo do mouse
        if (Input.GetMouseButtonDown(0)) // Verifica se o bot�o esquerdo do mouse foi pressionado
        {
            Shoot();
        }
    }

    // Fun��o para disparar a bala
    void Shoot()
    {
        // Verifica se o shootPoint e a bulletPrefab est�o configurados corretamente
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

    // Fun��o para atualizar o prefab da bala quando a arma muda
    public void UpdateBulletPrefab(GameObject newBulletPrefab)
    {
        bulletPrefab = newBulletPrefab;
    }
}
