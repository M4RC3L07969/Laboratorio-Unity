using UnityEngine;

public class QuizController : MonoBehaviour
{
    public GameObject quizPainel;
    public abrirPorta2 scriptDaPorta2;
    public abrirPorta3 scriptDaPorta3;
    public abrirPorta scriptDaPortaBoss;

    void Start()
    {
        AtualizarQuiz();
    }

    void Update()
    {
        AtualizarQuiz();
    }

    public void AtualizarQuiz()
    {

        if (scriptDaPorta2.segundoQuiz || scriptDaPorta3.terceiroQuiz || scriptDaPortaBoss.primeiroQuiz)
        {
            quizPainel.SetActive(true);
            Debug.Log("Quiz ATIVO - segundoQuiz: " + scriptDaPorta2.segundoQuiz);

            // Verifique se o Canvas e CanvasGroup estão corretos
            Canvas canvas = quizPainel.GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                Debug.Log("Canvas está ativo: " + canvas.isActiveAndEnabled);
            }

            CanvasGroup canvasGroup = quizPainel.GetComponentInParent<CanvasGroup>();
            if (canvasGroup != null)
            {
                Debug.Log("Alpha do CanvasGroup: " + canvasGroup.alpha);
            }
        }
        else
        {
            quizPainel.SetActive(false);
            Debug.Log("Quiz INATIVO - segundoQuiz: " + scriptDaPorta2.segundoQuiz);
        }
    }
}
