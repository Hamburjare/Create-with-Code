using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    [SerializeField]
    protected GameObject vehicle;

    [SerializeField]
    protected Vector3 vehicleOffset = new Vector3(0, 17f, 70f);

    [SerializeField]
    protected List<GameObject> obstaclePrafabs;

    [SerializeField]
    protected float maxVerticalRange = 10f;

    protected Vector3 targetPlaneOffset;
    protected Vector3 planeOffset;

    private void Start()
    {
        InvokeRepeating("DropObstacle", 1f, 1f);
    }

    private void Update()
    {
        this.UpdatePlaneOffser();
    }

    protected Vector3 GetBasePosition()
    {
        return new Vector3(0f, 0f, this.vehicle.transform.position.z);
    }

    protected void UpdatePlaneOffser()
    {
        if (Vector3.Distance(this.planeOffset, this.targetPlaneOffset) < 0.01f)
        {
            float x = Random.Range(-this.maxVerticalRange, this.maxVerticalRange);
            float y = Random.Range(-2, 2);
            float z = Random.Range(-2, 2);
            this.targetPlaneOffset = new Vector3(x, y, z);
        }
        this.planeOffset = Vector3.MoveTowards(this.planeOffset, this.targetPlaneOffset, 3f  * Time.deltaTime);

        transform.position = this.GetBasePosition() + this.vehicleOffset + planeOffset;
    }

    protected void DropObstacle()
    {
        GameObject obstacle = this.obstaclePrafabs[0];
        Instantiate(obstacle, transform.position, obstacle.transform.rotation);
    }

}
