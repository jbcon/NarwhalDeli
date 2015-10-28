using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class NoVrMouselook : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	    //check for oculus
        if (!VRDevice.isPresent)
        {
            Debug.Log("Detected " + VRSettings.loadedDevice);
        }
        else
        {
            Debug.Log("No VR device detected.  Initializing First Person Controller...");
            transform.gameObject.AddComponent<SimpleSmoothMouseLook>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
