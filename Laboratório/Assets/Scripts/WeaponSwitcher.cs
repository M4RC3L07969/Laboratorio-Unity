using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponSwitcher : MonoBehaviour
{
    public float fireRate;       // Tempo entre os tiros
    public float nextFireTime = 4f;    // Pr�ximo momento em que pode atirar

    public GameObject weapon;  // A arma que voc� est� usando
    public GameObject bullet1Prefab;  // Bala associada � arma 1
    public GameObject bullet2Prefab;  // Bala associada � arma 2
    private bool isSwitching = false;
    private bool isTextureChanged = false;

    private Vector3 originalPosition;
    public Vector3 loweredPosition = new Vector3(1.2f, -2.0f, 1.3f);
    private Quaternion originalRotation;
    public Quaternion loweredRotation = Quaternion.Euler(-45f, 4f, 0f);

    // Refer�ncias para as texturas diretamente no Inspector
    public Texture weapon1Texture;  // Textura da arma 1
    public Texture weapon2Texture;  // Textura da arma 2

    [Header("Weapon External")]
    public GameObject balaAtual;
    public Transform firePoint;

    [Header("Weapon Controller")]
    public float bulletVelocity = 300f;
    public float bulletPrefabLife = 3f;

    [Header("Recoil Settings")]
    public Vector3 recoilRotation = new Vector3(-10f, 0f, 0f); // quanto gira quando atira
    public float recoilTime = 0.1f; // tempo até a posição máxima do recoil
    public float returnTime = 0.15f; // tempo de retorno ao original



    private bool usandoBalaBase = false; // Agora usado como alternador fixo

    private Animation anim;

    void Start()
    {
        originalPosition = weapon.transform.localPosition;
        originalRotation = weapon.transform.localRotation;

        // Come�a com a bala �cida
        usandoBalaBase = false;
        balaAtual = bullet1Prefab;
        anim = gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        // Ao clicar com o bot�o direito, troca entre as balas
        if (Input.GetMouseButtonDown(1) && !isSwitching)
        {
            usandoBalaBase = !usandoBalaBase; // Alterna o estado
            balaAtual = usandoBalaBase ? bullet2Prefab : bullet1Prefab;
            StartCoroutine(SwitchWeapon());
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            //Debug.Log("atirou");

            Fire();

        }
    }

    private void Fire()
    {
        if (balaAtual == null)
        {
            Debug.LogWarning("Bala atual n�o foi atribu�da!");
            return;
        }

        GameObject bullet = Instantiate(balaAtual, firePoint.position, Quaternion.identity);
        StartCoroutine(Recoil());
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward.normalized * bulletVelocity, ForceMode.Impulse);
        }
        Destroy(bullet, bulletPrefabLife);
    }

    private IEnumerator SwitchWeapon()
    {
        isSwitching = true;

        yield return MoveWeapon(weapon, weapon.transform.localPosition, loweredPosition, weapon.transform.localRotation, loweredRotation);

        // Troca a textura conforme o tipo de bala atual
        if (usandoBalaBase)
        {
            ChangeWeaponTexture(weapon2Texture); // Textura da bala base
        }
        else
        {
            ChangeWeaponTexture(weapon1Texture); // Textura da bala �cida
        }

        yield return new WaitForSeconds(0.25f);

        yield return MoveWeapon(weapon, weapon.transform.localPosition, originalPosition, weapon.transform.localRotation, originalRotation);

        isSwitching = false;
    }

    private IEnumerator MoveWeapon(GameObject weapon, Vector3 startPosition, Vector3 targetPosition, Quaternion startRotation, Quaternion targetRotation)
    {
        float elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            weapon.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / 0.5f);
            weapon.transform.localRotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / 0.5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        weapon.transform.localPosition = targetPosition;
        weapon.transform.localRotation = targetRotation;
    }

    void ChangeWeaponTexture(Texture texture)
    {
        Renderer renderer = weapon.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.mainTexture = texture;
        }
    }

    private IEnumerator Recoil()
    {
        Quaternion startRotation = weapon.transform.localRotation;
        Quaternion recoilRot = startRotation * Quaternion.Euler(recoilRotation);

        // Movimento até a rotação de recoil
        float elapsed = 0f;
        while (elapsed < recoilTime)
        {
            weapon.transform.localRotation = Quaternion.Slerp(startRotation, recoilRot, elapsed / recoilTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        weapon.transform.localRotation = recoilRot;

        // Movimento de volta ao original
        elapsed = 0f;
        while (elapsed < returnTime)
        {
            weapon.transform.localRotation = Quaternion.Slerp(recoilRot, originalRotation, elapsed / returnTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        weapon.transform.localRotation = originalRotation;
    }
}