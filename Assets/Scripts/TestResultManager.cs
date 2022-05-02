using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestResultManager : MonoBehaviour
{
    public TMP_Text resultTitleText;
    public TMP_Text correctAnswersCountText;
    public TMP_Text pointsCountText;
    public TMP_Text starsCountText;
    public TMP_Text coinsCountText;

    private void Start()
    {
        resultTitleText.text = "Ваш результат:";
        correctAnswersCountText.text = "Правильно дан ответ на вопросы: " + TestManager.instance.correctAnswerCounter + "/" 
            + TestManager.instance.questions.Length;
        pointsCountText.text = "Набрано баллов: " + TestManager.instance.score + "/"
            + TestManager.instance.questions.Length;
        starsCountText.text = "Получено звезд: " + (int)((TestManager.instance.score/TestManager.instance.questions.Length) * 5);
        coinsCountText.text = "Заработано монет: " + TestManager.instance.score * 10;
    }
}
