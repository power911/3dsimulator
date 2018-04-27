using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcohol : MonoBehaviour,IUsing
{
    [SerializeField] private float _profit;
    [SerializeField] private float _unProfit;
    [SerializeField] private bool _full = true;
    public void Using()
    {
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Temperature, _profit);
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Food, _unProfit);
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Water, _unProfit);
        if (_full) { Effect(); }
        _full = false;
    }
    public void Effect()
    {
        //ЕБАТЬ ЗАНЕСЛО МЕНЯ
    }
}
