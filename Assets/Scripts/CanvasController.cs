using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public static CanvasController Instance;
    [SerializeField] private Slider[] _sliders;

    public Image RightClick;

    public enum ESliders { Temperature, Food, Water }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeValueSlider(ESliders eSlider,float value) {
        _sliders[(int)eSlider].value += value;
    }
    
        
}
