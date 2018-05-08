using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
    public static MainController Instance;

    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _pnlPause;

    public GameObject PanelPause
    {
        get { return _pnlPause; }
    }
    private void Start()
    {
        StartCoroutine(TimeController());
    }

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

    private void Update()
    {
       Keys();
    }

    private void Keys()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            Cursor.visible = !Cursor.visible;
            _pnlPause.active = !_pnlPause.active;
        }
    }

    private IEnumerator TimeController()
    {
        while(_light != null)
        {
            _light.transform.Rotate(10*Time.deltaTime, 0, 0, Space.World);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
