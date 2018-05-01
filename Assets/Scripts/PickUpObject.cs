using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    public PickUpObject PickUp;

    public virtual void Use()
    {
        Debug.Log("PickUpObject");
    }
}
