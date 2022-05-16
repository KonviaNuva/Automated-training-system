using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SokobanLevelsManager : MonoBehaviour
{
    static public SokobanLevelsManager instance;

    public GameObject[] levelButtons;
    public GameObject[] levelUnlockButtons;

    private void Start()
    {
        instance = this;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (IntersceneMemory.instance.areSokobanLevelsUnlocked[i])
            {
                levelButtons[i].SetActive(true);
                levelUnlockButtons[i].SetActive(false);
            }
        }
    }

    public void TryToUnlockLevel(int levelNumber)
    {
        if (IntersceneMemory.instance.coins >= 100)
        {
            IntersceneMemory.instance.coins -= 100;
            IntersceneMemory.instance.areSokobanLevelsUnlocked[levelNumber] = true;
            IntersceneMemory.instance.SaveUserData();

            SceneManager.LoadScene("SokobanLevels");
        }
    }
}
