using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSController : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 1000f;
    private float rotationX = 0f;
    private float rotationY = 0f;
    public float minAngleY = -45f;
    public float maxAngleY = 45f;

    [Header("Player External")]
    public CharacterController controller;
    public Transform playerBody;
    public Transform groundCheck;
    public LayerMask groundMask;

    [Header("Player Controller")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    private float speed;
    public float life = 30f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;

    private Vector3 velocity;
    private bool isGrounded;

    [Header("Weapon Holder Settings")]
    public Transform weaponHolder;
    public Vector3 weaponPositionOffset = new Vector3(1.2f, -1f, 1.3f);
    public Vector3 weaponRotationOffset = new Vector3(-1f, 4f, 0f);

    private void Start()
    {
        speed = walkSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX += mouseX;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, minAngleY, maxAngleY);

        camera.transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
        playerBody.rotation = Quaternion.Euler(0f, rotationX, 0f);

        // Atualiza posição e rotação da arma (WeaponHolder)
        if (weaponHolder != null)
        {
            weaponHolder.localPosition = weaponPositionOffset;
            weaponHolder.localRotation = Quaternion.Euler(weaponRotationOffset);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PU"))
        {
            life += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Inimigo base"))
        {
            life -= 10;
            Debug.Log("-10 de vida");
        }
        if (life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}