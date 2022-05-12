using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class IntersceneMemory : MonoBehaviour
{
    public static IntersceneMemory instance;

    public int themeIndex;
    public int coins;
    public int totalCoins;
    public testHighscore[] testHighscores;
    public string[] themes;
    public int backgroundNumber = 0;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("MainMenu");

        themes = new string[]
        {
            "Основные понятия в области пожарной безопасности",
            "Первичные средства пожаротушения",
            "Тема 3",
            "Тема 4"
        };

        testHighscores = new testHighscore[themes.Length];
        for (int i = 0; i < testHighscores.Length; i++)
        {
            testHighscores[i] = new testHighscore();
            testHighscores[i].stars = 0;
        }

        //DeleteUserData();
        LoadUserData();
    }

    public void SaveUserData()
    {
        SaveData data = new SaveData();
        data.saveCoins = coins;
        data.saveTotalCoins = totalCoins;

        data.stars = new int[testHighscores.Length];
        for (int i = 0; i < data.stars.Length; i++)
        {
            data.stars[i] = testHighscores[i].stars;
        }
        data.saveBackgroundNumber = backgroundNumber;        

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            coins = data.saveCoins;
            totalCoins = data.saveTotalCoins;
            for (int i = 0; i < data.stars.Length; i++)
            {
                testHighscores[i].stars = data.stars[i];
            }
            backgroundNumber = data.saveBackgroundNumber;
            BackgroundManager.instance.SetBackground(backgroundNumber);
        }
    }

    public void DeleteUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}

public class testHighscore
{
    public string testName;
    public int stars;
}

[System.Serializable]
class SaveData
{
    public int saveCoins;
    public int saveTotalCoins;
    public int[] stars;
    public int saveBackgroundNumber;
}