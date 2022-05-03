using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntersceneMemory : MonoBehaviour
{
    public static IntersceneMemory instance;

    public string themeName;
    public int coins;
    testRecord[] testRecords;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}

public class testRecord
{
    public string testName;
    public int stars;
}
