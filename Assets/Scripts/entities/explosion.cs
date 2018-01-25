using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    public float explosionForce = 10000f;
    public float lifetime = 0.1f;
    public SphereCollider sColl;

    private float deathtime;

    public void Start()
    {
        deathtime = Time.time + lifetime;
        sColl = GetComponent<SphereCollider>();
    }

    public void Update()
    {
        if(Time.time > deathtime)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddExplosionForce(explosionForce, this.gameObject.transform.position, sColl.radius, 2f);
    }
}
