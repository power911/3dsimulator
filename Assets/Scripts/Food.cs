using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour,IUsing
{
    [SerializeField] private float _profit;
    [SerializeField] private float _unProfit;
    public  void Using()
    {
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Food, _profit);
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Water, _profit);
        Debug.Log("Food");
        Destroy(gameObject);
    }
}
