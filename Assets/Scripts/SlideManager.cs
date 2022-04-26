using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlideManager : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    public static SlideManager instance;
    public Sprite[] osnovnie_poniatia;
    public Sprite[] pervichnie_sredstva;
    Sprite[] chosenTheme;
    public TMP_Text slideCounter;
    int slideNumber;

    private void Start()
    {
        instance = this;

        switch (IntersceneMemory.instance.themeName)
        {
            case ("основные понятия"):
                chosenTheme = osnovnie_poniatia;
                break;
            case ("первичные средства"):
                chosenTheme = pervichnie_sredstva;
                break;
        }

        slideNumber = 0;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = chosenTheme[slideNumber];

        SlideCounterUpdate();
    }

    public void MoveForward()
    {
        if (slideNumber < chosenTheme.Length - 1)
        {
            slideNumber++;
        }
        m_SpriteRenderer.sprite = chosenTheme[slideNumber];

        SlideCounterUpdate();
    }

    public void MoveBack()
    {
        if (slideNumber > 0)
        {
            slideNumber--;
        }
        m_SpriteRenderer.sprite = chosenTheme[slideNumber];

        SlideCounterUpdate();
    }

    void SlideCounterUpdate()
    {
        slideCounter.text = slideNumber + 1 + "/" + chosenTheme.Length;
    }
}
