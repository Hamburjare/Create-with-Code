using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] GameObject centerOfMass;
    private Rigidbody playerRb;
    [SerializeField] float turnSpeed = 45.0f;
    [SerializeField] float horsePower = 20.0f;
    private float horizontalInput;
    private float forwardInput;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void Update()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        speedometerText.SetText($"Speed: {speed} km/h");
        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText($"RPM: {rpm}");
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // Liikuttaa ajoneuvoa eteen päin käyttäen vertical inputtia
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            // Liikuttaa ajoneuvoa eteen päin käyttäen horizontal inputtia
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }




        bool IsOnGround()
        {
            wheelsOnGround = 0;
            foreach (WheelCollider wheel in allWheels)
            {
                if (wheel.isGrounded)
                {
                    wheelsOnGround++;
                }
            }
            if (wheelsOnGround == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
