using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public float life = 30f;
    public float damageOnCollision = 10f;  // Quanto de dano o player toma a cada colisão

    private void OnCollisionEnter(Collision collision)
    {
        // Aplica dano em qualquer colisão
        life -= damageOnCollision;

        // Você pode adicionar exceções se quiser, por exemplo:
        // if (collision.gameObject.CompareTag("PowerUp")) { ... }

        if (life <= 0)
        {
            // Reinicia a cena atual quando o player morrer
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
