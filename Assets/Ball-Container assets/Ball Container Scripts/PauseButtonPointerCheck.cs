using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButtonPointerCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool pointerEntered = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerEntered = true;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        pointerEntered = false;
    }
}
