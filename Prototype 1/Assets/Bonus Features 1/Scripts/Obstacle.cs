using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField]
    protected ParticleSystem explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ParticleSystem explosion = Instantiate(this.explosionPrefab, transform.position, this.explosionPrefab.transform.rotation);
            explosion.Play();
            this.AddExplosionForceToPlayerVehicle(collision.collider);
        }
    }

    protected void AddExplosionForceToPlayerVehicle(Collider collider)
    {
        Rigidbody rb = collider.gameObject.GetComponentInParent<Rigidbody>();
        if (rb == null)
        {
            rb = collider.gameObject.GetComponent<Rigidbody>();
        }
        if (rb != null)
        {
            rb.AddForceAtPosition(Vector3.up * 30000f, transform.position);
        }
    }

}
