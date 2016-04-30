using UnityEngine;
using Valve.VR;
using System.Collections;

public class Bottle : MonoBehaviour {

    public GameObject proj;
    public GameObject laser;

    SteamVR_TrackedObject controller;

	// Use this for initialization
	void Start () {
        controller = GetComponentInParent<SteamVR_TrackedObject>();
        laser.transform.localRotation *= Quaternion.Euler(180,0,0);
        laser.SetActive(false);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject p = Instantiate(proj, transform.position, transform.rotation) as GameObject;
            p.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.Impulse);
            Destroy(p, 2);
            Time.timeScale = 1f;
            laser.SetActive(false);
        }
        else if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            laser.SetActive(true);
            Time.timeScale = 0.4f;
        }
    }
}
