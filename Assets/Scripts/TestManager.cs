using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestManager : MonoBehaviour
{
    public static TestManager instance = null;

    public TMP_Text questionText;
    public TMP_Text answerButtonText0;
    public TMP_Text answerButtonText1;
    public TMP_Text answerButtonText2;
    public TMP_Text answerButtonText3;
    public TMP_Text answerButtonText4;
    public TMP_Text answerButtonText5;
    public GameObject answerButton0;
    public GameObject answerButton1;
    public GameObject answerButton2;
    public GameObject answerButton3;
    public GameObject answerButton4;
    public GameObject answerButton5;

    Question[] questions;
    string theme;
    Question activeQuestion;
    bool[] isAnswerChosen;

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

        isAnswerChosen = new bool[] { false, false, false, false, false, false };
    }

    void ShowQuestion()
    {
        questionText.text = activeQuestion.question;
        answerButtonText0.text = activeQuestion.answers[0].answerText;
        answerButtonText1.text = activeQuestion.answers[1].answerText;
        if (activeQuestion.answers.Length >= 3)
        {
            answerButton2.SetActive(true);
            answerButtonText2.text = activeQuestion.answers[2].answerText;
        }
        else
        {
            answerButton2.SetActive(false);
        }
        if (activeQuestion.answers.Length >= 4)
        {
            answerButton3.SetActive(true);
            answerButtonText3.text = activeQuestion.answers[3].answerText;
        }
        else
        {
            answerButton3.SetActive(false);
        }
        if (activeQuestion.answers.Length >= 5)
        {
            answerButton4.SetActive(true);
            answerButtonText4.text = activeQuestion.answers[4].answerText;
        }
        else
        {
            answerButton4.SetActive(false);
        }
        if (activeQuestion.answers.Length >= 6)
        {
            answerButton5.SetActive(true);
            answerButtonText5.text = activeQuestion.answers[5].answerText;
        }
        else
        {
            answerButton5.SetActive(false);
        }
    }

    public void PressButton(int answerNumber)
    {
        //вызывается кнопками, со стороны. сигнализирует о том, что кнопка с определенным номером была нажата. ну или в случае если 
        //она уже была нажата - стала отжата. в любом случае, это надо отметить в отдельном массиве, чтобы помнить, какие варианты 
        //ответа пользователь выбрал.

        isAnswerChosen[answerNumber] = !isAnswerChosen[answerNumber];
        Debug.Log("answer number " + answerNumber + " being chosen is " + isAnswerChosen[answerNumber] + " now");
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

            new Question("vopros3 theme1",
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
