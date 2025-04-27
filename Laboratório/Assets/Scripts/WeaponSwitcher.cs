using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject weapon;  // A arma que você está usando
    public GameObject bullet1Prefab;  // Bala associada à arma 1
    public GameObject bullet2Prefab;  // Bala associada à arma 2
    private bool isSwitching = false;
    private bool isTextureChanged = false;  // Controle de alternância da textura

    // Posições e rotações de troca da arma
    private Vector3 originalPosition;
    public Vector3 loweredPosition = new Vector3(1.2f, -2.0f, 1.3f); // Posição de abaixar a arma

    private Quaternion originalRotation;
    public Quaternion loweredRotation = Quaternion.Euler(-45f, 4f, 0f); // Rotação ao abaixar

    // Referência ao script de disparo da arma (WeaponShooter)
    private WeaponShooter weaponShooter;

    // Referências para as texturas diretamente no Inspector
    public Texture weapon1Texture;  // Textura da arma 1
    public Texture weapon2Texture;  // Textura da arma 2

    void Start()
    {
        // Inicializa a posição e rotação original da arma
        originalPosition = weapon.transform.localPosition;
        originalRotation = weapon.transform.localRotation;

        // Obtém a referência ao script WeaponShooter
        weaponShooter = weapon.GetComponent<WeaponShooter>();

        // Se o script de disparo não estiver encontrado, lança um erro
        if (weaponShooter == null)
        {
            Debug.LogError("WeaponShooter não encontrado na arma!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isSwitching) // Botão direito do mouse (1)
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

        // Troca a textura e a bala associada à nova arma
        if (!isTextureChanged)
        {
            ChangeWeaponTexture(weapon2Texture); // Troca a textura para a arma 2
            weaponShooter.UpdateBulletPrefab(bullet2Prefab); // Troca a bala para a arma 2
        }
        else
        {
            ChangeWeaponTexture(weapon1Texture); // Retorna à textura da arma 1
            weaponShooter.UpdateBulletPrefab(bullet1Prefab); // Troca a bala para a arma 1
        }

        isTextureChanged = !isTextureChanged; // Alterna o estado da textura

        yield return new WaitForSeconds(0.25f);

        // Simula "subir" a arma de volta
        startPosition = weapon.transform.localPosition;
        targetPosition = originalPosition;
        startRotation = weapon.transform.localRotation;
        targetRotation = originalRotation;

        // Movimento suave de volta para a posição original
        yield return MoveWeapon(weapon, startPosition, targetPosition, startRotation, targetRotation);

        isSwitching = false;
    }

    // Função para mover a arma suavemente
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

    // Função para alterar a textura da arma
    void ChangeWeaponTexture(Texture texture)
    {
        Renderer weaponRenderer = weapon.GetComponent<Renderer>();
        if (weaponRenderer != null)
        {
            weaponRenderer.material.mainTexture = texture;
        }
    }
}
