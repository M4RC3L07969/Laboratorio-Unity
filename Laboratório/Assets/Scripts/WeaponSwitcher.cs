using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject weapon;  // A arma que voc� est� usando
    public GameObject bullet1Prefab;  // Bala associada � arma 1
    public GameObject bullet2Prefab;  // Bala associada � arma 2
    private bool isSwitching = false;
    private bool isTextureChanged = false;  // Controle de altern�ncia da textura

    // Posi��es e rota��es de troca da arma
    private Vector3 originalPosition;
    public Vector3 loweredPosition = new Vector3(1.2f, -2.0f, 1.3f); // Posi��o de abaixar a arma

    private Quaternion originalRotation;
    public Quaternion loweredRotation = Quaternion.Euler(-45f, 4f, 0f); // Rota��o ao abaixar

    // Refer�ncia ao script de disparo da arma (WeaponShooter)
    private WeaponShooter weaponShooter;

    // Refer�ncias para as texturas diretamente no Inspector
    public Texture weapon1Texture;  // Textura da arma 1
    public Texture weapon2Texture;  // Textura da arma 2

    void Start()
    {
        // Inicializa a posi��o e rota��o original da arma
        originalPosition = weapon.transform.localPosition;
        originalRotation = weapon.transform.localRotation;

        // Obt�m a refer�ncia ao script WeaponShooter
        weaponShooter = weapon.GetComponent<WeaponShooter>();

        // Se o script de disparo n�o estiver encontrado, lan�a um erro
        if (weaponShooter == null)
        {
            Debug.LogError("WeaponShooter n�o encontrado na arma!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isSwitching) // Bot�o direito do mouse (1)
        {
            StartCoroutine(SwitchWeapon());
        }
    }

    private System.Collections.IEnumerator SwitchWeapon()
    {
        isSwitching = true;

        // Simula "abaixar" a arma
        Vector3 startPosition = weapon.transform.localPosition;
        Vector3 targetPosition = loweredPosition;
        Quaternion startRotation = weapon.transform.localRotation;
        Quaternion targetRotation = loweredRotation;

        // Movimento suave da arma
        yield return MoveWeapon(weapon, startPosition, targetPosition, startRotation, targetRotation);

        // Troca a textura e a bala associada � nova arma
        if (!isTextureChanged)
        {
            ChangeWeaponTexture(weapon2Texture); // Troca a textura para a arma 2
            weaponShooter.UpdateBulletPrefab(bullet2Prefab); // Troca a bala para a arma 2
        }
        else
        {
            ChangeWeaponTexture(weapon1Texture); // Retorna � textura da arma 1
            weaponShooter.UpdateBulletPrefab(bullet1Prefab); // Troca a bala para a arma 1
        }

        isTextureChanged = !isTextureChanged; // Alterna o estado da textura

        yield return new WaitForSeconds(0.25f);

        // Simula "subir" a arma de volta
        startPosition = weapon.transform.localPosition;
        targetPosition = originalPosition;
        startRotation = weapon.transform.localRotation;
        targetRotation = originalRotation;

        // Movimento suave de volta para a posi��o original
        yield return MoveWeapon(weapon, startPosition, targetPosition, startRotation, targetRotation);

        isSwitching = false;
    }

    // Fun��o para mover a arma suavemente
    private System.Collections.IEnumerator MoveWeapon(GameObject weapon, Vector3 startPosition, Vector3 targetPosition, Quaternion startRotation, Quaternion targetRotation)
    {
        float elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            weapon.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / 0.5f));
            weapon.transform.localRotation = Quaternion.Lerp(startRotation, targetRotation, (elapsedTime / 0.5f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        weapon.transform.localPosition = targetPosition;
        weapon.transform.localRotation = targetRotation;
    }

    // Fun��o para alterar a textura da arma
    void ChangeWeaponTexture(Texture texture)
    {
        Renderer weaponRenderer = weapon.GetComponent<Renderer>();
        if (weaponRenderer != null)
        {
            weaponRenderer.material.mainTexture = texture;
        }
    }
}
