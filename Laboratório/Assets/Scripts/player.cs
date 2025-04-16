using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 12;

    public float CtrlSpeed = 4;
    public float estamina = 20;
    private float estaminaAtual;
    private float segundos = 0;

    public float vida = 30;

    public float forca = 1;

    private void FixedUpdate()
    {
        TrocarArma();

        if (estamina == estaminaAtual)
        {
            segundos += Time.deltaTime;
        }
        else
        {
            segundos = 0;
        }
        if (estamina <= 0)
        {
            estamina = 0;
        }
        if (segundos >= 7 && estamina <= 20)
        {
            estamina = estamina + 2 * Time.deltaTime;
        }

        estaminaAtual = estamina;
        if (estamina > 0 && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddForce(Vector3.forward * CtrlSpeed);
            estamina = estamina - 2 * Time.deltaTime;
        }
        if (estamina > 0 && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddForce(Vector3.left * CtrlSpeed);
            estamina = estamina - 2 * Time.deltaTime;
        }
        if (estamina > 0 && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddForce(Vector3.back * CtrlSpeed);
            estamina = estamina - 2 * Time.deltaTime;
        }
        if (estamina > 0 && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddForce(Vector3.right * CtrlSpeed);
            estamina = estamina - 2 * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }
    }

    public void TrocarArma()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Trocando para a arma 1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Trocando para a arma 2");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PU")
        {
            vida += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Morrer")
        {
            vida -= 10;
        }
        if (vida <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}