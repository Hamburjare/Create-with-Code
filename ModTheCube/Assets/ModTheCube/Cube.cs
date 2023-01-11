using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    public Vector3 position = new Vector3(3, 4, 1);
    public float scale = 1.3f;
    private float rotateSpeedX;
    private float rotateSpeedY;
    private float rotateSpeedZ;
    public float speed = 1.0f;
    public Color color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    
    void Start()
    {
        rotateSpeedX = Random.Range(-10,10);
        rotateSpeedY = Random.Range(-10,10);
        rotateSpeedZ = Random.Range(-10,10);

        transform.position = position;
        transform.localScale = Vector3.one * scale;
        
        Material material = Renderer.material;
        
        material.color = color;
    }
    
    void Update()
    {
        transform.Rotate(rotateSpeedX * Time.deltaTime * speed, rotateSpeedY * Time.deltaTime * speed, rotateSpeedZ * Time.deltaTime * speed);
    }
}
