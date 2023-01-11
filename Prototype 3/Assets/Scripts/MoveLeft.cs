using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 25;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {  
        //Tarkistaa onko peli ohitse
        if (playerControllerScript.gameOver == false) 
        { 
            //Liikuttaa kaikkia yhdistettyjä objecteja vasemmalle
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //Jos objecti tagillä "Obstacle" menee yli rajojen"
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            //Tuhoaa sen objectin
            Destroy(gameObject);
        }

    }
}
