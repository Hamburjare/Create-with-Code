using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVehicleController : MonoBehaviour
{

    [SerializeField]
    private float speed = 20f;

    private void Update()
    {
        transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
    }

}
