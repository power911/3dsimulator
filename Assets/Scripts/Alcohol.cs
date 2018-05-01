using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcohol : PickUpObject
{
    [SerializeField] private float _profit;
    [SerializeField] private float _unProfit;
    [SerializeField] private bool _full = true;

    public override void Use()
    {
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Temperature, _profit);
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Food, _unProfit);
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Water, _unProfit);
        Debug.Log("Alcohole");
        if (_full) { Effect(); }
        _full = false;
    }
    public void Effect()
    {
        //ЕБАТЬ ЗАНЕСЛО МЕНЯ
    }
}
