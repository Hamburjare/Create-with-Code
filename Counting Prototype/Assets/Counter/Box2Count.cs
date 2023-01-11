using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box2Count : MonoBehaviour
{
    public Text MiddleText;
    private int MiddleBalls = 0;

    private void OnTriggerEnter(Collider other)
    {
        Counter.instance.Count += 5;
        MiddleBalls += 1;
        MiddleText.text = "Middle: " + MiddleBalls;

    }
}
