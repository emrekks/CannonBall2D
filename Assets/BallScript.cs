using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private void Start()
    {
        Invoke("SetFalse", 3.5f);
    }

    void SetFalse()
    {
        this.gameObject.SetActive(false);
    }

}
