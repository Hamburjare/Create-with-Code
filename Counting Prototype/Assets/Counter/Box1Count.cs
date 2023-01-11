using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box1Count : MonoBehaviour
{
    public Text LeftText;
    private int LeftBalls = 0;

    private void OnTriggerEnter(Collider other)
    {
        Counter.instance.Count += 1;
        LeftBalls += 1;
        LeftText.text = "Left: " + LeftBalls;

    }
}
