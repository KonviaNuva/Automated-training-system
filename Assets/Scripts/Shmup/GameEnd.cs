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

    private GameManager gamemanager;
    private HeroController heroController;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        heroController = FindObjectOfType<HeroController>();
    }

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

    public void ContinueGame()
    {
        gamemanager.gameIsOver = false;
        heroController.gameObject.SetActive(true);
        heroController.health = 5;
        gameEndMenu.SetActive(false);
        //отключить геймовер, вернуть на экран персонажа и увеличить жизни до 5. и убрать меню конца игры
        //потом еще надо будет денег снимать за это
    }
}
