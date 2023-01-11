using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public static Counter instance;
    public Text CounterText;

    public int Count = 0;

    private void Start()
    {
        instance = this;
    }

    private void FixedUpdate() {
        CounterText.text = "Points : " + Count;
    }

}
