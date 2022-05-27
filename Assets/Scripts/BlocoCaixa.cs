using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class BlocoCaixa : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Bloco bloco;
    public bool dragging, used;

    public void OnDrag(PointerEventData data)
    {
        dragging = true;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData data)
    {
        dragging = false;
    }
}