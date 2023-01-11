using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2 : MonoBehaviour
{

    [System.Serializable]
    public class CameraDef
    {
        public Vector3 offset;
        public bool rotationAsVehicle = false;
    }

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private List<CameraDef> cameras = new List<CameraDef>()
    {
        new CameraDef() { offset = new Vector3(0f, 5f, -7f) },
        new CameraDef() { offset = new Vector3(0f, 2f, 1.5f), rotationAsVehicle = true }
    };

    private int cameraIndex = 0;
    private Vector3 baseRotation;

    private void Start()
    {
        this.baseRotation = transform.rotation.eulerAngles;
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.ChangeCamera();
        }
    }

    void LateUpdate()
    {
        CameraDef camera = this.cameras[this.cameraIndex];
        if (camera.rotationAsVehicle)
        {
            transform.position = this.player.transform.TransformPoint(camera.offset);
            transform.rotation = this.player.transform.rotation;
        }
        else
        {
            transform.position = this.player.transform.position + camera.offset;
            transform.rotation = Quaternion.Euler(this.baseRotation);
        }
    }

    protected void ChangeCamera()
    {
        this.cameraIndex++;
        if (this.cameraIndex >= this.cameras.Count)
        {
            this.cameraIndex = 0;
        }
    }

}
