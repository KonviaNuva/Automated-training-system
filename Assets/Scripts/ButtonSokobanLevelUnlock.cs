using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSokobanLevelUnlock : MonoBehaviour
{
    public int levelNumber;

    private void OnMouseDown()
    {
        SokobanLevelsManager.instance.TryToUnlockLevel(levelNumber);
    }
}
