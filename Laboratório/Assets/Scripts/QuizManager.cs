using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].transform.GetChild(0).getComponent<Text>().text = QnA[currentQuestion].Answers[i];
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.Txt = QnA[currentQuestion].Question;

    }
}
