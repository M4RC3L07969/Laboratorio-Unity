using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSController : MonoBehaviour
{


    [SerializeField] private Camera camera;

    private float sensitivityX = 1000f;
    private float sensitivityY = 1000f;

    private float mouseX;
    private float mouseY;

    private float rotationX;
    private float rotationY;

    private float minAngleY = -45;
    private float maxAngleY = 45;


    [Header("Player External")]
    public CharacterController controller;
    //public Animator anim;
    public Transform playerBody;
    //public Transform playerCamera;
    public Transform groundCheck;
    public LayerMask groundMask;

    [Header("Player Controller")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    private float speed;
    public float life = 30;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float groundDistance = 0.4f;

    Vector3 velocity;
    public bool isGrounded;

    [Header("Camera Controller")]
    public float mouseSensitivity = 1000f;
    float xRotation = 0f;


    float x;
    float z;
    //float mouseX;
    //float mouseY;

    void Start()
    {
        speed = walkSpeed;
        //   anim.SetBool("isIdle", true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Movement();

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        LookRotation();
    }

    public void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        //anim.SetBool("isJumping", false);
        //anim.SetBool("isIdle", true);

        //anim.SetBool("isIdle", false);
        //anim.SetBool("isWalking", true);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            //anim.SetBool("isRunning", true);
        }
        else
        {
            speed = walkSpeed;
            //anim.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //anim.SetBool("isWalking", false);
      



        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void LookRotation()
    {
        rotationY = Mathf.Clamp(rotationY, minAngleY, maxAngleY);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotationX += mouseX * sensitivityX * Time.deltaTime;
        rotationY -= mouseY * sensitivityY * Time.deltaTime;

        camera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        this.transform.rotation = Quaternion.Euler(0, rotationX, 0);
    }

    

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PU")
        {
            life += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Morrer")
        {
            life -= 10;
        }
        if (life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}