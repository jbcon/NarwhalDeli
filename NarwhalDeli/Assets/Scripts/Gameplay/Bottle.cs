using UnityEngine;
using Valve.VR;
using System.Collections;

public class Bottle : MonoBehaviour {

    SteamVR_TrackedObject controller;
    int controllerIndex;
    public GameObject proj;

	// Use this for initialization
	void Start () {
        controller = GetComponentInParent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject p = Instantiate(proj, transform.position + transform.forward / 4, transform.rotation) as GameObject;
            p.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
            Destroy(p, 2);
        }
        else
        {

        }
    }
}
