using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaInicial : MonoBehaviour
{
    public Button button1;

    void Start()
    {
        button1.onClick.AddListener(IniciarJogo);
    }

    void IniciarJogo()
    {
        SceneManager.LoadScene("SceneQuiz");
    }
}
