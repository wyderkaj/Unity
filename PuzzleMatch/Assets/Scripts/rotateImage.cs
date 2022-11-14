using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateImage : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameController.youWin)
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }
}
