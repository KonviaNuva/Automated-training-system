using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestThemesManager : MonoBehaviour
{
    public TMP_Text[] starTexts;

    void Start()
    {
        for (int i = 0; i < starTexts.Length; i++)
        {
            starTexts[i].text = IntersceneMemory.instance.testHighscores[i].stars.ToString() + "/5";
        }
    }
}
