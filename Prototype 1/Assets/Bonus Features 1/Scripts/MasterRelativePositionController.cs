using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterRelativePositionController : MonoBehaviour
{

    protected MasterPositionController masterPositionController;
    protected Vector3 offset = Vector3.zero;

    private void Start()
    {
        EndlessManager.Instance.MasterPositionControllerChanged += OnMasterPositionControllerChanged;
    }

    protected void OnMasterPositionControllerChanged(MasterPositionController masterPositionController)
    {
        this.masterPositionController = masterPositionController;
        this.offset = transform.position - this.masterPositionController.transform.position;
    }

    private void LateUpdate()
    {
        if (this.masterPositionController == null)
            return;
        Vector3 pos = transform.position;
        Vector3 masterPos = this.masterPositionController.transform.position;
        transform.position = new Vector3(pos.x, pos.y, masterPos.z + this.offset.z);
    }

}
