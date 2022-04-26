using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChangeScript : MonoBehaviour
{
    public string sceneName;
    public string themeName;

    void OnMouseDown()
    {
        IntersceneMemory.instance.themeName = this.themeName;
        SceneManager.LoadScene(sceneName);
    }
}
