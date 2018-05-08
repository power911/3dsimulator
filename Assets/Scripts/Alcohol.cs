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
        if (_full) {StartCoroutine(Effect());}
        _full = false;
    }

    private IEnumerator Effect()
    {
        int randomCount = Random.Range(5, 20);
        bool negative = false;
        float multiplier = 10f;
        for (int i = 0; i <= randomCount; i++)
        {
            float rnd = Random.Range(0f, 40f);
            rnd = negative ? rnd : rnd * (-1);
            negative = negative ? false : true;
            while ((Character.Instance.CameraRotZ <= rnd && !negative) || (Character.Instance.CameraRotZ >= rnd && negative))
            {
                Character.Instance.CameraRotZ = negative ? Character.Instance.CameraRotZ -= multiplier * Time.deltaTime : Character.Instance.CameraRotZ += multiplier * Time.deltaTime;
                yield return new WaitForSeconds(0.01f);
            }
        }
        Character.Instance.CameraRotZ = 0;
    }
}
