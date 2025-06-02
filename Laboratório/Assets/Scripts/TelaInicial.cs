using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaInicial : MonoBehaviour
{
    public Button button1;
    public Button button4;

    void Start()
    {
        button1.onClick.AddListener(IniciarJogo);
        button4.onClick.AddListener(SairJogo);

    }

    void IniciarJogo()
    {
        SceneManager.LoadScene("SceneQuiz");
    }

    void SairJogo()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
