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

    void Start()
    {
        instance = this;

        squareSideLength = floorPrefab.GetComponent<BoxCollider2D>().size.x;

        LoadLevel();
        DrawLevel();
    }

    public void TryToMove(string direction)
    {
        Debug.Log("trying to move " + direction);
        if (IsMoveValid(direction))
        {
            MoveCharacter(direction);            
        }
        ClearLevel();
        DrawLevel();
        if (IsItWin())
        {
            //отображаем победное сообщение
        }
    }

    bool IsMoveValid(string direction)
    {
        //проверка валидности хода. нельзя ходить в стенку и за пределы поля или отправлять ящик туда же или в другой ящик
        //попробуем перебрать невалидные ходы, а иначе разрешать
        //нас интересуют две клетки в направлении движения от игрока. что на них и существуют ли они вообще
        //если клетка вообще не существует - считаем, что там стенка
        //SokobanSquare targetSquare;
        //SokobanSquare squareAfterTarger;

        if (direction == "right")
        {
            if (playerPositionX + 1 > sokobanLevel.GetUpperBound(0))
            {
                return false;
            }
            if (sokobanLevel[playerPositionX + 1, playerPositionY].isWall)
            {
                return false;
            }
            if ((sokobanLevel[playerPositionX + 1, playerPositionY].isCrate) && 
                    (playerPositionX + 2 > sokobanLevel.GetUpperBound(0)))
            {
                return false;
            }
        }
        if (direction == "left")
        {
            if (playerPositionX - 1 < 0)
            {
                return false;
            }
            if (sokobanLevel[playerPositionX - 1, playerPositionY].isWall)
            {
                return false;
            }
        }
        if (direction == "up")
        {
            if (playerPositionY + 1 > sokobanLevel.GetUpperBound(1))
            {
                return false;
            }
            if (sokobanLevel[playerPositionX, playerPositionY + 1].isWall)
            {
                return false;
            }
        }
        if (direction == "down")
        {
            if (playerPositionY - 1 < 0)
            {
                return false;
            }
            if (sokobanLevel[playerPositionX, playerPositionY - 1].isWall)
            {
                return false;
            }
        }

        return true;
    }

    void MoveCharacter(string direction)
    {
        //двигаем персонажа в нужном направлении. и возможно ящик на его пути
        //это значит, что необходимо изменить состояние дел в массиве
        //ящики перемещаем путем присвоения его новому положению значения ящика, а старому - пустого места
        //игрок перемещается путем изменения координат его положения

        if (direction == "right")
        {
            playerPositionX++;
        }
        if (direction == "left")
        {
            playerPositionX--;
        }
        if (direction == "up")
        {
            playerPositionY++;
        }
        if (direction == "down")
        {
            playerPositionY--;
        }
    }

    bool IsItWin()
    {
        //проверяет то, достигнуто ли условие победы. а именно - на помеченном месте ли все ящики
        return false;
    }
    
    void ClearLevel()
    {
        //перед рисованием необходимо удалить уже нарисованный уровень. 
        foreach(GameObject oldSquare in GameObject.FindGameObjectsWithTag("square"))
        {
            Destroy(oldSquare);
        }
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
        playerPositionY = 1;

        /*sokobanLevel = new SokobanSquare[5,3];
        sokobanLevel[0, 0] = new SokobanSquare(true, false, false);
        sokobanLevel[0, 1] = new SokobanSquare(true, false, false);
        sokobanLevel[0, 2] = new SokobanSquare(true, false, false);
        sokobanLevel[1, 0] = new SokobanSquare(true, false, false);
        sokobanLevel[1, 1] = new SokobanSquare(false, false, false);
        sokobanLevel[1, 2] = new SokobanSquare(true, false, false);
        sokobanLevel[2, 0] = new SokobanSquare(true, false, false);
        sokobanLevel[2, 1] = new SokobanSquare(false, false, true);
        sokobanLevel[2, 2] = new SokobanSquare(true, false, false);
        sokobanLevel[3, 0] = new SokobanSquare(true, false, false);
        sokobanLevel[3, 1] = new SokobanSquare(false, true, false);
        sokobanLevel[3, 2] = new SokobanSquare(true, false, false);
        sokobanLevel[4, 0] = new SokobanSquare(true, false, false);
        sokobanLevel[4, 1] = new SokobanSquare(true, false, false);
        sokobanLevel[4, 2] = new SokobanSquare(true, false, false);*/

        sokobanLevel = new SokobanSquare[3, 3];
        sokobanLevel[0, 0] = new SokobanSquare(false, false, false);
        sokobanLevel[0, 1] = new SokobanSquare(false, false, false);
        sokobanLevel[0, 2] = new SokobanSquare(false, false, false);
        sokobanLevel[1, 0] = new SokobanSquare(false, false, false);
        sokobanLevel[1, 1] = new SokobanSquare(false, false, false);
        sokobanLevel[1, 2] = new SokobanSquare(false, false, false);
        sokobanLevel[2, 0] = new SokobanSquare(false, false, false);
        sokobanLevel[2, 1] = new SokobanSquare(false, false, false);
        sokobanLevel[2, 2] = new SokobanSquare(false, false, false);
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