using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameEnd : MonoBehaviour
{
    public GameObject gameEndMenu;

    public AudioSource musicPlayer;
    public AudioClip okSound;

    public void ShowEndMenu()
    {
        gameEndMenu.SetActive(true);
    }

    public void RestartGame()
    {
        musicPlayer.PlayOneShot(okSound);
        Thread.Sleep(500);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
