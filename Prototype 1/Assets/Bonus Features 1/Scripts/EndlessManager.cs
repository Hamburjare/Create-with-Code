using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour
{

    public static EndlessManager Instance { get; private set; }

    [SerializeField]
    protected Transform resetTransform;

    protected MasterPositionController masterPositionController;

    public event System.Action<float> ResetPosition;
    public event System.Action<MasterPositionController> MasterPositionControllerChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterMasterPositionController(MasterPositionController masterPositionController)
    {
        this.masterPositionController = masterPositionController;
        this.MasterPositionControllerChanged?.Invoke(this.masterPositionController);
    }

    private void Update()
    {
        if (this.masterPositionController == null)
            return;
        if (this.masterPositionController.transform.position.z > this.resetTransform.position.z)
        {
            float masterOffset = this.masterPositionController.transform.position.z - this.resetTransform.position.z;
            float zOffset = -(this.resetTransform.position.z + masterOffset);
            this.ResetPosition?.Invoke(zOffset);
        }
    }

}
