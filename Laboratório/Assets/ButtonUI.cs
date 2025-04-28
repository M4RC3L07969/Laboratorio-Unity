using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string gameLevel = "Level1";


    public void AnswerButton()
    {
        SceneManager.LoadScene(gameLevel);
    }
}
