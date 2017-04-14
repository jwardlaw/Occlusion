using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class NetworkPlayer : Photon.MonoBehaviour {

    public GameObject Playercam;
    public GameObject Spawncam;


	// Use this for initialization
	void Start ()
    {
        if (photonView.isMine)
        {
            Spawncam = GameObject.FindGameObjectWithTag("SpawnCamera");
            Spawncam.SetActive(false);

            Playercam.SetActive(true);
            Playercam.GetComponent<Camera>().enabled = true;
            Playercam.GetComponent<GUILayer>().enabled = true;
            Playercam.GetComponent<EdgeDetectionColor>().enabled = true;
            Playercam.GetComponent<AudioListener>().enabled = true;
            GetComponent<FirstPersonController>().enabled = true;
            GetComponent<CharacterController>().enabled = true;
        }

    }
	
	
}
