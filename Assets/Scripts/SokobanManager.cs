using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SokobanManager : MonoBehaviour
{
    public static SokobanManager instance;

    float squareSideLength;

    public GameObject wallPrefab;
    public GameObject cratePrefab;
    public GameObject playerPrefab;
    public GameObject floorPrefab;
    public GameObject markPrefab;

    int playerPositionX;
    int playerPositionY;
    SokobanSquare[,] sokobanLevel;
    List<GameObject> boxes;

    void Start()
    {
        instance = this;

        squareSideLength = floorPrefab.GetComponent<BoxCollider2D>().size.x;

        DrawLevel();
    }

    void DrawLevel()
    {
        Instantiate(floorPrefab, new Vector3(0, 0), floorPrefab.transform.rotation);
        Instantiate(playerPrefab, new Vector3(0, 0), floorPrefab.transform.rotation);
    }
}

public class SokobanSquare
{
    bool isWall; // стенка ли это? Если да - клетка непроходима, рисуется стена. Если нет - проходима, рисуем пол.
    bool isMarked; // стоит ли тут метка, что нужно поставить сюда ящик. Если да - рисуем метку, ящик тут - условие победы.
    bool isCrate; //  есть ли тут ящик?
}