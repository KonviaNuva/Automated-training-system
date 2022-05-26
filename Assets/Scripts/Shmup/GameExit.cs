using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameExit : MonoBehaviour
{
    public AudioSource musicPlayer;
    public AudioClip okSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            CloseGame();
        }
    }

    public void CloseGame()
    {
        musicPlayer.PlayOneShot(okSound);
        Thread.Sleep(500);
        Application.Quit();
    }
}
