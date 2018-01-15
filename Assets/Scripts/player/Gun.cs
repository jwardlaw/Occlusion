using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public GameManager gm;
    public float weaponRange = 50f;                                     // Distance in Unity units over which the player can fire
    public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun
    public float fireRate = 0.25f;
    
    public AudioSource gunAudio;                                       // Reference to the audio source which will play our shooting sound effect
    public LineRenderer laserLine;                                     // Reference to the LineRenderer component which will display our laserline
    public Camera fpsCamera;
    public float laserActive = 0.07f;
    public WaitForSeconds shotDuration;
    public float nextFire;


    void Start()
    {
        // Get and store a reference to our LineRenderer component
        laserLine = GetComponent<LineRenderer>();

        // Get and store a reference to our AudioSource component
        gunAudio = GetComponent<AudioSource>();

        fpsCamera = GetComponentInChildren<Camera>();

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        shotDuration = new WaitForSeconds(laserActive);
    }


    void Update()
    {
        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

            // Set the start position for our visual effect for our laser to the position of gunEnd
            laserLine.SetPosition(0, gunEnd.position);

            // Check if our raycast has hit anything
            if (Physics.Raycast(rayOrigin, fpsCamera.transform.forward, out hit, weaponRange))
            {
                // Set the end position for our laser line 
                laserLine.SetPosition(1, hit.point);

                // If it was a target
                if (hit.collider.CompareTag("target"))
                {
                    gm.updateTime(-5f);
                    hit.collider.gameObject.SetActive(false);
                }
            }
            else
            {
                // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                laserLine.SetPosition(1, rayOrigin + (fpsCamera.transform.forward * weaponRange));
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        // Play the shooting sound effect
        gunAudio.Play();

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}