using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestManager : MonoBehaviour
{
    public static TestManager instance = null;

    public TMP_Text questionText;
    public TMP_Text[] answerButtonTexts;
    public GameObject[] answerButtons;

    Question[] questions;
    string theme;
    Question activeQuestion;

    void Start()
    {
        if (instance == null)
        { 
            instance = this; 
        }
        else 
        { 
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);

        //vremennaya testovaya hren'
        ChooseTheme(IntersceneMemory.instance.themeName);
        activeQuestion = questions[3];
        ShowQuestion();
    }

    void ShowQuestion()
    {
        questionText.text = activeQuestion.question;
        answerButtonTexts[0].text = activeQuestion.answers[0].answerText;
        answerButtonTexts[1].text = activeQuestion.answers[1].answerText;

        for (int i = 2; i <= 5; i++)
        {
            if (activeQuestion.answers.Length >= i+1)
            {
                answerButtons[i].SetActive(true);
                answerButtonTexts[i].text = activeQuestion.answers[i].answerText;
            }
            else
            {
                answerButtons[i].SetActive(false);
            }
        }
    }

    //ниже идут списки тем, вопросов, ответов. лучше их не мешать с прочими методами.

    public void ChooseTheme(string inputTheme)
    {
        theme = inputTheme;

        switch (theme)
        {
            case "основные понятия":
                ChooseThemeOsnovniePoniatia();
                break;
            case "первичные средства":
                ChooseThemePervichnieSredstva();
                break;
        }
    }

    void ChooseThemeOsnovniePoniatia()
    {
        questions = new Question[]
        {
            new Question("vopros theme1",
            "right answer", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false,
            "wrong answer4", false,
            "wrong answer5", false),

            new Question("vopros2 theme1",
            "right answer", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false,
            "wrong answer4", false),

            new Question("vopros3 theme1",
            "right answer", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false),

            new Question("vopros4 theme1",
            "right answer", true,
            "right answer2", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false),
        };
    }

    void ChooseThemePervichnieSredstva()
    {
        questions = new Question[]
        {
            new Question("vopros theme2",
            "right answer", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false,
            "wrong answer4", false,
            "wrong answer5", false),

            new Question("vopros2 theme2",
            "right answer", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false,
            "wrong answer4", false,
            "wrong answer5", false),

            new Question("vopros3 theme2",
            "right answer", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false,
            "wrong answer4", false,
            "wrong answer5", false),

            new Question("vopros4 theme2",
            "right answer", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false,
            "wrong answer4", false,
            "wrong answer5", false),
        };
    }
}

public class Question
{
    public string question;
    public Answer[] answers;

    public Question(string inputQuestion, Answer[] inputAnswers)
    {
        question = inputQuestion;
        answers = inputAnswers;
    }

    public Question(string inputQuestion, string answer1, bool isCorrect1, string answer2, bool isCorrect2, 
        string answer3, bool isCorrect3, string answer4, bool isCorrect4)
    {
        question = inputQuestion;
        answers = new Answer[] { new Answer(answer1, isCorrect1), new Answer(answer2, isCorrect2),
            new Answer(answer3, isCorrect3), new Answer(answer4, isCorrect4) };
    }

    public Question(string inputQuestion, string answer1, bool isCorrect1, string answer2, bool isCorrect2,
        string answer3, bool isCorrect3, string answer4, bool isCorrect4, string answer5, bool isCorrect5)
    {
        question = inputQuestion;
        answers = new Answer[] { new Answer(answer1, isCorrect1), new Answer(answer2, isCorrect2),
            new Answer(answer3, isCorrect3), new Answer(answer4, isCorrect4), new Answer(answer5, isCorrect5) };
    }

    public Question(string inputQuestion, string answer1, bool isCorrect1, string answer2, bool isCorrect2,
        string answer3, bool isCorrect3, string answer4, bool isCorrect4, string answer5, bool isCorrect5, 
        string answer6, bool isCorrect6)
    {
        question = inputQuestion;
        answers = new Answer[] { new Answer(answer1, isCorrect1), new Answer(answer2, isCorrect2),
            new Answer(answer3, isCorrect3), new Answer(answer4, isCorrect4), new Answer(answer5, isCorrect5),
            new Answer(answer6, isCorrect6) };
    }
}

public class Answer
{
    public string answerText;
    public bool isCorrect;

    public Answer(string inputAnswerText, bool inputIsCorrect)
    {
        answerText = inputAnswerText;
        isCorrect = inputIsCorrect;
    }
}
