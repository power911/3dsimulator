using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : PickUpObject
{
    [SerializeField] private float _profit;
    [SerializeField] private float _unProfit;
    [SerializeField] private ParticleSystem _particle;

    public override void Use()
    {
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Food, _profit);
        CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Water, _profit);
        _particle.Play();
        Destroy(gameObject,0.25f);
    }
    
}
