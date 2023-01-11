using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{

    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float turnSpeed = 25.0f;
    [SerializeField]
    private float maxTurnAngle = 20.0f;
    private float horizontalInput;

    [SerializeField]
    private List<GameObject> wheels;
    [SerializeField]
    private float wheelsSpeed = 20f;

    private Rigidbody rb;

    private void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.rb.maxAngularVelocity = 2f;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        this.UpdateTurn();
        this.UpdateWheels();
    }

    protected void UpdateTurn()
    {
        float angle = Mathf.DeltaAngle(0f, transform.rotation.eulerAngles.y);
        if (angle < -this.maxTurnAngle)
        {
            angle = -this.maxTurnAngle;
        }
        else if(angle > this.maxTurnAngle)
        {
            angle = this.maxTurnAngle;
        }
        Vector3 rot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rot.x, angle, rot.z);
    }

    protected void UpdateWheels()
    {
        foreach (GameObject wheel in this.wheels)
        {
            wheel.transform.Rotate(Vector3.right, this.wheelsSpeed);
        }
    }

}
