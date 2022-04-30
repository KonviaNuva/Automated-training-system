using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    Question[] questions;
    string theme;

    int[] intarray;

    void Start()
    {
        Question question1 = new Question("vopros", 
            "right answer", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false,
            "wrong answer4", false,
            "wrong answer5", false);

        intarray = new int[] { 1, 2, 3};
    }

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
            "wrong answer4", false,
            "wrong answer5", false),

            new Question("vopros3 theme1",
            "right answer", true,
            "wrong answer", false,
            "wrong answer2", false,
            "wrong answer3", false,
            "wrong answer4", false,
            "wrong answer5", false),
        };
    }

    void ChooseThemePervichnieSredstva()
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
            "wrong answer4", false,
            "wrong answer5", false),

            new Question("vopros3 theme1",
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
    string question;
    Answer[] answers;

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
    string answerText;
    bool isCorrect;

    public Answer(string inputAnswerText, bool inputIsCorrect)
    {
        answerText = inputAnswerText;
        isCorrect = inputIsCorrect;
    }
}
