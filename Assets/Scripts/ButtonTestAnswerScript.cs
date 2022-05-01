using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTestAnswerScript : MonoBehaviour
{
    public int answerNumber;

    SpriteRenderer m_SpriteRenderer;

    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Debug.Log("button " + answerNumber + " is pressed");
        TestManager.instance.PressButton(answerNumber);
        MarkAsChosen();
    }

    public void MarkAsChosen()
    {
        m_SpriteRenderer.color = new Color(0, 0, 128, (float)0.2);
    }

    public void MarkAsUnchosen()
    {
        m_SpriteRenderer.color = new Color(0, 0, 0);
    }
}
