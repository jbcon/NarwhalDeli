using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class NoVrMouselook : MonoBehaviour {

    public float xMovement = 2;
    public float zMovement = 2;
    public float snapSpeed = 2;

    private Vector3 initialPos;

	// Use this for initialization
	void Awake () {
	    //check for oculus
        if (VRDevice.isPresent)
        {
            Debug.Log("Detected " + VRSettings.loadedDevice);
        }
        else
        {
            Debug.Log("No VR device detected.  Initializing First Person Controller...");
            transform.gameObject.AddComponent<SimpleSmoothMouseLook>();
            initialPos = transform.position;
            Camera.main.fov = 106;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (!VRDevice.isPresent)
        {
            float movX = Input.GetAxisRaw("Horizontal") * xMovement;
            float movZ = Input.GetAxisRaw("Vertical") * zMovement;
            Quaternion yRot = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

            transform.position = Vector3.Lerp(transform.position,initialPos + yRot * new Vector3(movX, 0, movZ ), Time.deltaTime * snapSpeed);
        }
	}
}
