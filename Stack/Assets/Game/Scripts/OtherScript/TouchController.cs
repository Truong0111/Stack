using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameController gc;
    [SerializeField] private StackController stc;
    public void OnPointerDown(PointerEventData ped)
    {
        stc.GetTouchIn();
    }
}
