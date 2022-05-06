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

    public int questionNumber = 4;
    public Question[] questions;
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

        questions = GetQuestions(IntersceneMemory.instance.themeIndex);

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

        for (int i = 0; i < questions[questionCounter].answers.Length; i++)
        {
            if (questions[questionCounter].answers[i].isCorrect && answerButtons[i].GetComponent<ButtonTestAnswerScript>().isPressed)
            {
                correctAnswersChosen++;
            }
            if (questions[questionCounter].answers[i].isCorrect && !answerButtons[i].GetComponent<ButtonTestAnswerScript>().isPressed)
            {
                correctAnswersNotChosen++;
            }
            if (!questions[questionCounter].answers[i].isCorrect && answerButtons[i].GetComponent<ButtonTestAnswerScript>().isPressed)
            {
                incorrectAnswersChosen++;
            }
            if (!questions[questionCounter].answers[i].isCorrect && !answerButtons[i].GetComponent<ButtonTestAnswerScript>().isPressed)
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
            ShowQuestion(questions[questionCounter]);
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

    static Answer[] AnswerShuffle(Answer[] inputAnswerArray)
    //принимает массив ответов. Выдает его же перетасованным
    {
        int[] indexes = NumberShuffle(inputAnswerArray.Length, inputAnswerArray.Length);
        Answer[] shuffledAnswerArray = new Answer[inputAnswerArray.Length];

        for (int i = 0; i < inputAnswerArray.Length; i++)
        {
            shuffledAnswerArray[i] = inputAnswerArray[indexes[i]];
        }

        return shuffledAnswerArray;
    }

    //ниже идут списки тем, вопросов, ответов. лучше их не мешать с прочими методами.

    public Question[] GetQuestions(int themeIndex)
    {
        int[] indexes = NumberShuffle(questionNumber, allQuestions[themeIndex].Length);

        Question[] shuffledQuestions = new Question[questionNumber];

        for (int i = 0; i < shuffledQuestions.Length; i++)
        {
            shuffledQuestions[i] = allQuestions[themeIndex][indexes[i]];
        }

        //нужно сгенерировать массив массивов, содержащий перетасованные индексы для каждого ответа на каждый вопрос, 
        //одновременно. а после этого уже в соответствии с индексами переставить все ответы в нужно порядке.

        for (int i = 0; i < shuffledQuestions.Length; i++)
        {
            shuffledQuestions[i].answers = AnswerShuffle(shuffledQuestions[i].answers);
        }

        return shuffledQuestions;
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