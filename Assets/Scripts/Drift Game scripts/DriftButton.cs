using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DriftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private DriftCar car;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Player").GetComponent<DriftCar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData) { car.driftButtonDown(); }

    public void OnPointerUp(PointerEventData eventData) { car.driftButtonRelease(); }
}
