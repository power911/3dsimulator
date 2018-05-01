using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _goField;
    [SerializeField] private float _goDistance;
    [SerializeField] private CharacterController _character;
    [SerializeField] private PickUpObject _goPick;

    private float _cameraRotY;
    private float _cameraRotX;
    private bool _moving;

    Vector3 _moveDirection = Vector3.zero;

    private void Start()
    {
        StartCoroutine(Food());
        StartCoroutine(Water());
        StartCoroutine(Temperature());
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Hit();
        Keys();
    }

    private void Move()
    {
        _cameraRotY -= Input.GetAxis("Mouse Y");
        _cameraRotX += Input.GetAxis("Mouse X");
        _cameraRotY = Mathf.Clamp(_cameraRotY, -90, 90);
        transform.Rotate(0, Input.GetAxis("Mouse X") * _rotSpeed, 0);
        Camera.main.transform.rotation = Quaternion.Euler(_cameraRotY, _cameraRotX * _rotSpeed, 0);
        _moveDirection = new Vector3(Input.GetAxis("Horizontal") * _speed, 0, Input.GetAxis("Vertical") * _speed);
        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection.y -= 20f * Time.deltaTime;
        _character.Move(_moveDirection * Time.deltaTime);
        if(Input.GetButton("Horizontal")|| Input.GetButton("Vertical"))
        {
            _moving = true;
        }else
        {
            _moving = false;
        }
    }

    private void Hit()
    {
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            int layer = 1 << 8;
            layer = ~layer;
            _goDistance -= Input.GetAxis("Mouse ScrollWheel");
            _goDistance = Mathf.Clamp(_goDistance, -1, 1);
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 25f,layer);
            try
            {
                if (_goField == null && hit.transform.gameObject.GetComponent<PickUpObject>() != null )
                {
                    _goField = hit.transform.gameObject;
                    _goField.transform.SetParent(this.gameObject.transform);
                    _goField.GetComponent<Rigidbody>().isKinematic = true;
                    _goField.GetComponent<Renderer>().material.SetFloat("_OutlineExtrusion", 0.01f);
                    _goPick = _goField.GetComponent<PickUpObject>().PickUp;
                    CanvasController.Instance.RightClick.gameObject.SetActive(true);
                }
            }
            catch (System.NullReferenceException) { Debug.Log("null"); }
            if (_goField != null)
            {
                float posZ = _goField.transform.localPosition.z - _goDistance * Time.deltaTime;
                float posY = _goField.transform.localPosition.y + _goDistance * Time.deltaTime;
                float posX = _goField.transform.localPosition.x;
                posZ = Mathf.Clamp(posZ, 1f, 1.3f);
                posY = Mathf.Clamp(posY, 0f, 0.9f);
                _goField.transform.localPosition = new Vector3(posX, posY, posZ);
            }
            if (Input.GetMouseButtonDown(1))
            {
                if(_goField != null)
                {
                    _goPick.Use();
                }
                CanvasController.Instance.RightClick.gameObject.SetActive(false);
            }
        }
        if (Input.GetMouseButtonUp(0) && _goField != null)
        {

            _goField.GetComponent<Rigidbody>().isKinematic = false;
            _goDistance = 0;
            _goField.transform.SetParent(null);
            _goField.GetComponent<Renderer>().material.SetFloat("_OutlineExtrusion", 0.0f);
            _goField = null;
            _goPick = null;
            CanvasController.Instance.RightClick.gameObject.SetActive(false);
        }
    }

    private void Keys()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
        }
    }

    IEnumerator Food()
    {
        while(this.gameObject!= null)
        {
            CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Food, Random.Range(-0.5f, -2.5f));
            yield return new WaitForSeconds(_moving ? 5f : 6f);
        }
    }

    IEnumerator Water()
    {
        while (this.gameObject != null)
        {
            CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Water, Random.Range(-0.5f, -2.5f));
            yield return new WaitForSeconds(_moving ? 6f : 7f);
        }
    }

    IEnumerator Temperature()
    {
        while (this.gameObject != null)
        {
            CanvasController.Instance.ChangeValueSlider(CanvasController.ESliders.Temperature, -1);
            yield return new WaitForSeconds(_moving ? 9f : 8f);
        }
    }
}