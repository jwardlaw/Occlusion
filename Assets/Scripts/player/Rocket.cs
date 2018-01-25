using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public GameManager gm;
    public float speed = 2f;
    public float lifetime = 10f;
    public GameObject explosion;

    private float deathtime;

    private Vector3 travelVector;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        deathtime = Time.time + lifetime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position += Time.deltaTime * speed * transform.forward;
        if(Time.time > deathtime)
        {
            GameObject.Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Instantiate(explosion, this.transform.position, Quaternion.identity);
        if(collision.collider.CompareTag("target"))
        {
            gm.updateTime(-5f);
            collision.collider.gameObject.SetActive(false);
        }

        GameObject.Destroy(this.gameObject);
    }
}
