using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    static BackgroundScript instance;

    private void Start()
    {
        instance = this;

        DontDestroyOnLoad(transform.gameObject);
    }
}
