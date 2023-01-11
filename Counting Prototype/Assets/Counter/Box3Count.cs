using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box3Count : MonoBehaviour
{
    public Text RightText;
    private int RightBalls = 0;

    private void OnTriggerEnter(Collider other)
    {
        Counter.instance.Count += 1;
        RightBalls += 1;
        RightText.text = "Right: " + RightBalls;

    }
}
