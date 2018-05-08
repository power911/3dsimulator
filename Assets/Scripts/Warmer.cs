using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warmer : PickUpObject {

    [SerializeField] private SphereCollider _sphere;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _character;
   
    private Coroutine _tempCor;
    public bool Active = false;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Mathce>() != null && collision.gameObject.GetComponent<Mathce>().Active && !Active)
        {
            Active = true;
            _sphere.enabled = true;
            Destroy(collision.gameObject, 1f);
            _particle.gameObject.SetActive(true);
            _light.SetActive(true);
            _tempCor = StartCoroutine(WarmsUp());
            StartCoroutine(FireLifeTime());
        }
        if(collision.gameObject.GetComponent<Warmer>() != null && collision.gameObject.GetComponent<Warmer>().Active)
        {
            Active = true;
            _sphere.enabled = true;
            _particle.gameObject.SetActive(true);
            _light.SetActive(true);
            _tempCor = StartCoroutine(WarmsUp());
            StartCoroutine(FireLifeTime());
        }
    }
    
    private void OnTriggerEnter(Collider  other)
    {
        if (other.GetComponent<Character>() != null)
        {
            _character = other.gameObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Character>() != null)
        {
            _sphere.enabled = false;
            _character = null;
            if (_tempCor != null)
            {
               StopCoroutine(_tempCor);
            }
        }
    }

    private IEnumerator FireLifeTime()
    {
        yield return new WaitForSeconds(5 * 1.5f);
        _particle.gameObject.SetActive(false);
        _character = null;
        Destroy(gameObject);
    }

    private IEnumerator WarmsUp()
    { 
        do
        {
            CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Temperature, 7.5f);
            yield return new WaitForSeconds(1f);
        } while (_character != null);
    }

}
