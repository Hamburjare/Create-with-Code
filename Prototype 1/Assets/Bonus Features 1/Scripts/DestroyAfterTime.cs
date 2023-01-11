using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    [SerializeField]
    protected float destroyTime;

    private void OnEnable()
    {
        Destroy(gameObject, this.destroyTime);
    }

}
