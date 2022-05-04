using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TestManager : MonoBehaviour
{
    public static TestManager instance = null;

    public TMP_Text questionText;
    public TMP_Text[] answerButtonTexts;
    public GameObject[] answerButtons;

    public Question[] questions;
    public int[] indexes;
    string theme;
    int questionCounter = 0;
    public int correctAnswerCounter = 0;
    public double score;

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


        GetQuestions(IntersceneMemory.instance.themeIndex);

        indexes = NumberShuffle(4, questions.Length);

        ShowQuestion(questions[questionCounter]);
    }

    void ShowQuestion(Question activeQuestion)
    {
        questionText.text = activeQuestion.question;
        answerButtonTexts[0].text = activeQuestion.answers[0].answerText;
        answerButtonTexts[1].text = activeQuestion.answers[1].answerText;

        for (int i = 2; i <= 5; i++)
        {
            if (activeQuestion.answers.Length >= i + 1)
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

    public void FinishQuestion()
    {
        double addToScore = 0;

        double correctAnswersChosen = 0;
        double correctAnswersNotChosen = 0;
        double incorrectAnswersChosen = 0;
        double incorrectAnswersNotChosen = 0;

        for (int i = 0; i < questions[indexes[questionCounter]].answers.Length; i++)
        {
            if (questions[indexes[questionCounter]].answers[i].isCorrect && answerButtons[i].GetComponent<ButtonTestAnswerScript>().isPressed)
            {
                correctAnswersChosen++;
            }
            if (questions[indexes[questionCounter]].answers[i].isCorrect && !answerButtons[i].GetComponent<ButtonTestAnswerScript>().isPressed)
            {
                correctAnswersNotChosen++;
            }
            if (!questions[indexes[questionCounter]].answers[i].isCorrect && answerButtons[i].GetComponent<ButtonTestAnswerScript>().isPressed)
            {
                incorrectAnswersChosen++;
            }
            if (!questions[indexes[questionCounter]].answers[i].isCorrect && !answerButtons[i].GetComponent<ButtonTestAnswerScript>().isPressed)
            {
                incorrectAnswersNotChosen++;
            }
        }

        addToScore += (correctAnswersChosen - incorrectAnswersChosen) /
            (correctAnswersChosen + correctAnswersNotChosen);
        if (addToScore < 0)
        {
            addToScore = 0;
        }
        score += addToScore;

        if (addToScore == 1)
        {
            correctAnswerCounter++;
        }

        NextQuestion();
    }

    void NextQuestion()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<ButtonTestAnswerScript>().UnpressButton();
        }

        if (questionCounter + 1 < questions.Length)
        {
            questionCounter++;
            ShowQuestion(questions[indexes[questionCounter]]);
        }
        else
        {
            SceneManager.LoadScene("TestResults");
        }
    }


    static int[] NumberShuffle(int shuffledLength, int originalLength)
    //принимает длину нужного массива и длину оригинального массива. Выдает индексы в случайном порядке, перетасованные
    {
        int[] originalArray = new int[originalLength];
        int[] shuffledArray = new int[shuffledLength];

        for (int i = 0; i < originalArray.Length; i++)
        {
            originalArray[i] = i;
        }

        int index = 0;
        for (int i = 0; i < shuffledArray.Length; i++)
        {
            index += Random.Range(0, originalArray.Length - 1);
            if (index >= originalArray.Length)
            {
                index -= originalArray.Length;
            }

            while (originalArray[index] == -1)
            {
                index++;
                if (index >= originalArray.Length)
                {
                    index -= originalArray.Length;
                }
            }

            shuffledArray[i] = originalArray[index];
            originalArray[index] = -1;
        }

        return shuffledArray;
    }

    //ниже идут списки тем, вопросов, ответов. лучше их не мешать с прочими методами.

    public void GetQuestions(int themeIndex)
    {
        questions = allQuestions[themeIndex];
    }

    Question[][] allQuestions = new Question[][]
    {
        new Question[]
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
        },
        new Question[]
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
        }
    };
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