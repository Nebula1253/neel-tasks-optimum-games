using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelerateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject track;
    private bool isAccelerating = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isAccelerating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isAccelerating = false;
    }

    void Update()
    {
        if (isAccelerating) { track.GetComponent<Track>().OnAcceleratorButtonDown(); }
        else { track.GetComponent<Track>().OnAcceleratorButtonRelease(); }
    }
}
