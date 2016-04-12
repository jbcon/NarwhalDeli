using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class NoVrMouselook : MonoBehaviour {

    public float xMovement = 2;
    public float zMovement = 2;
    public float snapSpeed = 2;
    public bool vrActive = false;

    private Vector3 initialPos;

	// Use this for initialization
	void Awake () {
	    //check for oculus
        if (vrActive)
        {
            Debug.Log("Detected " + VRDevice.model);
        }
        else
        {
            Debug.Log("No VR device detected.  Initializing First Person Controller...");
            transform.gameObject.AddComponent<SimpleSmoothMouseLook>();
            initialPos = transform.position;
            Camera.main.fieldOfView = 106;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (!vrActive)
        {
            float movX = Input.GetAxisRaw("Horizontal") * xMovement;
            float movZ = Input.GetAxisRaw("Vertical") * zMovement;
            Quaternion yRot = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

            transform.position = Vector3.Lerp(transform.position,initialPos + yRot * new Vector3(movX, 0, movZ ), Time.deltaTime * snapSpeed);
        }
	}
}
