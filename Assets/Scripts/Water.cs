using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour,IUsing {

    [SerializeField] private float _profit;
    [SerializeField] private float _unProfit;

    public void Using()
    {
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Water, _profit);
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Temperature, _unProfit);
        Destroy(gameObject);
    }
    
}
