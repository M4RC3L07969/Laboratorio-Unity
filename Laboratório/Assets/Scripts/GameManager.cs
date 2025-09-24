using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject gameOverUI;

    [Header("Flags de controle")]
    public bool isInUI = false; // True quando está em menu ou quiz
    public bool isGameOver = false;

    void Start()
    {
        UpdateCursor();
    }

    void Update()
    {
        // Sempre atualiza o cursor conforme o estado atual
        UpdateCursor();
    }

    private void UpdateCursor()
    {
        if (isGameOver || isInUI)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Chamado quando o jogador morre
    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // pausa o jogo
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TelaInicial");
    }

    // Chamado pelo quiz para ativar/desativar o cursor
    public void SetUIActive(bool active)
    {
        isInUI = active;
        Time.timeScale = active ? 0f : 1f; // pausa se estiver no UI
        UpdateCursor();
    }
}
