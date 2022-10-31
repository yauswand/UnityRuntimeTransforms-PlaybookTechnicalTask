using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleButton : MonoBehaviour
{
    public DragandDrop draganddrop;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            draganddrop.SpawnDragCapsule();
        }

    }
}
