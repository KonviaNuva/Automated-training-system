using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntersceneMemory : MonoBehaviour
{
    public static IntersceneMemory instance;

    public int themeIndex;
    public int coins;
    public testHighscore[] testHighscores;
    string[] themes;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("MainMenu");

        themes = new string[]
        {
            "основные понятия",
            "первичные средства"
        };

        coins = 80;
        testHighscores = new testHighscore[themes.Length];
        for (int i = 0; i < testHighscores.Length; i++)
        {
            testHighscores[i] = new testHighscore();
            testHighscores[i].stars = 1;
        }
    }
}

public class testHighscore
{
    public string testName;
    public int stars;
}
