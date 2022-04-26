using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntersceneMemory : MonoBehaviour
{
    public static IntersceneMemory instance;
    public string themeName;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
