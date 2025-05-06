using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newPlayer : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera camera;
    public float mouseSensitivity = 1000f;

    [Header("Player Components")]
    public CharacterController controller;
    public Transform playerBody;
    public Transform groundCheck;
    public LayerMask groundMask;

    [Header("Player Settings")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public float life = 30f;

    private float speed;
    private float x, z;
    private float xRotation = 0f;
    private float yRotation = 0f;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        speed = walkSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovementInput();
        HandleMouseLook();
    }

    private void HandleMovementInput()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        Vector3 move = transform.right * x + transform.forward * z;

        speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Morrer"))
        {
            life -= 10;
        }

        if (life <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
