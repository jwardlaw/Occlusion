using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float time = 0f;
    public Collider player;
    public Collider goal; 
    

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("player").GetComponent<CapsuleCollider>();
        goal = GameObject.FindWithTag("goal").GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
	}

    public void updateTime(float delta)
    {
        time += delta;
    }
}
