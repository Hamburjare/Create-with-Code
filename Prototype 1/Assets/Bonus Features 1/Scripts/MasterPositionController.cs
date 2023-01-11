using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPositionController : MonoBehaviour
{

    private void Start()
    {
        EndlessManager.Instance.RegisterMasterPositionController(this);
        EndlessManager.Instance.ResetPosition += OnResetPosition;
    }

    protected void OnResetPosition(float zOffset)
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y, pos.z + zOffset);
    }

}
