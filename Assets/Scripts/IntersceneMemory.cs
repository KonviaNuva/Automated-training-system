using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntersceneMemory : MonoBehaviour
{
    public static IntersceneMemory instance;

    public int themeIndex;
    public int coins;
    testRecord[] testRecords;
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
    }
}

public class testRecord
{
    public string testName;
    public int stars;
}
