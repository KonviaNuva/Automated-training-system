using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSokobanLevelUnlock : MonoBehaviour
{
    public int backgroundNumber;

    private void OnMouseDown()
    {
        ShopManager.instance.TryToUnlockBackground(backgroundNumber);
    }
}
