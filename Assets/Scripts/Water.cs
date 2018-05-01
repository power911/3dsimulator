using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : PickUpObject{

    [SerializeField] private float _profit;
    [SerializeField] private float _unProfit;

    public override void Use()
    {
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Water, _profit);
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Temperature, _unProfit);
        Debug.Log("Water");
        Destroy(gameObject);
    }
    
}
