using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{

    private void Start()
    {
        EndlessManager.Instance.ResetPosition += OnResetPosition;
    }

    private void OnDestroy()
    {
        EndlessManager.Instance.ResetPosition -= OnResetPosition;
    }

    protected void OnResetPosition(float zOffset)
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y, pos.z + zOffset);
    }

}
