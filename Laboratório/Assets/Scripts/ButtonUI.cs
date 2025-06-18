/**using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string[] gameLevels = { "SceneQuiz1", "SceneQuiz2", "SceneQuiz3", "SceneQuiz4", "SceneQuiz5" };
    [SerializeField] private int levelIndex = 0;

    public void AnswerButton()
    {
        if (levelIndex >= 0 && levelIndex < gameLevels.Length)
        {
            SceneManager.LoadScene(gameLevels[levelIndex]);
        }
        else
        {
            Debug.LogError("Índice de cena inválido!");
        }
    }
}
**/