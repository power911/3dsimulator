using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mathce : PickUpObject {

    [SerializeField] private ParticleSystem _particle;
    public bool Active;
    public override void Use()
    {
        Active = true;
        _particle.gameObject.SetActive(true);
        Destroy(gameObject, 2.5f);
    }

    
}
