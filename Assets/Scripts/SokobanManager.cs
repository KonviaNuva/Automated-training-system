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

        LoadLevel();
        DrawLevel();
    }

    void DrawLevel()
    {
        Vector3 levelCenter = new Vector3(squareSideLength * sokobanLevel.GetUpperBound(0) / 2, 
            squareSideLength * sokobanLevel.GetUpperBound(1) / 2);

        for (int i = 0; i <= sokobanLevel.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= sokobanLevel.GetUpperBound(1); j++)
            {
                Instantiate(floorPrefab, new Vector3(-levelCenter.x + i * squareSideLength, 
                    -levelCenter.y + j * squareSideLength), floorPrefab.transform.rotation);
            }
            for (int j = 0; j <= sokobanLevel.GetUpperBound(1); j++)
            {
                if (sokobanLevel[i, j].isCrate)
                {
                    Instantiate(cratePrefab, new Vector3(-levelCenter.x + i * squareSideLength, 
                        -levelCenter.y + j * squareSideLength), cratePrefab.transform.rotation);
                }
            }
            for (int j = 0; j <= sokobanLevel.GetUpperBound(1); j++)
            {
                if (sokobanLevel[i, j].isMarked)
                {
                    Instantiate(markPrefab, new Vector3(-levelCenter.x + i * squareSideLength, 
                        -levelCenter.y + j * squareSideLength), markPrefab.transform.rotation);
                }
            }
            for (int j = 0; j <= sokobanLevel.GetUpperBound(1); j++)
            {
                if (sokobanLevel[i, j].isWall)
                {
                    Instantiate(wallPrefab, new Vector3(-levelCenter.x + i * squareSideLength, 
                        -levelCenter.y + j * squareSideLength), wallPrefab.transform.rotation);
                }
            }
        }

        Instantiate(playerPrefab, new Vector3(-levelCenter.x + playerPositionX * squareSideLength,
            -levelCenter.y + playerPositionY * squareSideLength), playerPrefab.transform.rotation);
    }

    void LoadLevel()
    {
        playerPositionX = 1;
        playerPositionY = 0;

        sokobanLevel = new SokobanSquare[2,3];
        sokobanLevel[0, 0] = new SokobanSquare(true, false, false);
        sokobanLevel[0, 1] = new SokobanSquare(true, false, false);
        sokobanLevel[0, 2] = new SokobanSquare(true, false, false);
        sokobanLevel[1, 0] = new SokobanSquare(false, false, false);
        sokobanLevel[1, 1] = new SokobanSquare(false, false, true);
        sokobanLevel[1, 2] = new SokobanSquare(false, true, false);
    }
}

public class SokobanSquare
{
    public bool isWall; // стенка ли это? Если да - клетка непроходима, рисуется стена. Если нет - проходима, рисуем пол.
    public bool isMarked; // стоит ли тут метка, что нужно поставить сюда ящик. Если да - рисуем метку, ящик тут - условие победы.
    public bool isCrate; //  есть ли тут ящик?

    public SokobanSquare(bool inputIsWall, bool inputIsMarked, bool inputIsCrate)
    {
        isWall = inputIsWall;
        isMarked = inputIsMarked;
        isCrate = inputIsCrate;
    }
}