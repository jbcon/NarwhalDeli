using UnityEngine;
using System.Collections;
using OSVR.Unity;

public class MatchVRViewer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        VRViewer viewer = FindObjectOfType<VRViewer>();
        transform.rotation = viewer.cachedTransform.rotation;
        //Debug.Log("New Rotation: " + transform.rotation);
	}
}
