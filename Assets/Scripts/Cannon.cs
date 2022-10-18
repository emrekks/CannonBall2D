using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;

    private Vector3 difference;
    
    public float power;
    
    public Transform firePoint;
    
    private bool _pressingMouse = false;

    private Vector3 _initialVelocity;

    private bool reload = false;

    private float timer;

    //Trajectory
    
    [SerializeField] private int dotsNumber = 20;

    [SerializeField] private GameObject dotsParent;
    
    [SerializeField] private GameObject dotsPrefab;

    [SerializeField] private float dotSpacing;
    
    [SerializeField] [Range(0.01f, 0.5f)] private float dotMinScale;
    
    [SerializeField] [Range(0.5f, 1f)] private float dotMaxScale;

    [SerializeField] private Transform[] dotList;
    
    private Vector2 pos;
    
    private float _dotSpacing;
    
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        PrepareDots();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pressingMouse = true;
            Show();
        }
        
        if (Input.GetMouseButtonUp(0) && !reload)
        {
            _pressingMouse = false;
            Fire();
            Hide();
        }

        if (_pressingMouse)
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            
            if (rotationZ >= -19.45f && rotationZ <= 110)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            }

            _initialVelocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position);

            UpdateDots(firePoint.position, _initialVelocity * power);
        }

        if (reload)
        {
             timer = timer + Time.deltaTime;
             if (timer >= 2)
             {
                 timer = 0;
                 reload = false;
             }
        }
    }
    
    void Fire()
    {
        GameObject newBall = BallPoolling.instance.GetBallFromPool();
        newBall.transform.position = firePoint.position;
        newBall.SetActive(true);
        newBall.GetComponent<Rigidbody2D>().AddForce((_initialVelocity * power) , ForceMode2D.Impulse);
        reload = true;
    }

    void PrepareDots()
    {
        dotList = new Transform[dotsNumber];
        
        dotsPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;

        float scaleFactor = scale / dotsNumber;

        for (int i = 0; i < dotsNumber; i++)
        {
            dotList[i] = Instantiate(dotsPrefab, null).transform;
            dotList[i].parent = dotsParent.transform;

            dotList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
            {
                scale -= scaleFactor;
            }
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        _dotSpacing = dotSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
            pos.x = (ballPos.x + forceApplied.x * _dotSpacing);
            pos.y = (ballPos.y + forceApplied.y * _dotSpacing) - (Physics2D.gravity.magnitude * _dotSpacing * _dotSpacing) / 2f;

            dotList[i].position = pos;
            _dotSpacing += dotSpacing;
        }
    }

    void Show()
    {
        dotsParent.SetActive(true);
    }
    void Hide()
    {
        dotsParent.SetActive(false);
    }
}
