using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

    public GameObject flipperBase;

    private SteamVR_TrackedObject myFlipper;
    private GameObject flipperObject;
    private static int numControllers = 0;

	// Use this for initialization
	void Awake () {
        flipperBase = Instantiate(flipperBase);
        myFlipper = flipperBase.GetComponent<SteamVR_TrackedObject>();
        myFlipper.origin = gameObject.transform;
        myFlipper.SetDeviceIndex(++numControllers);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
