using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TitleBoardString : MonoBehaviour {

    public Transform[] anchors;
    public Color ropeColor;
    public Material ropeMat;
    private GameObject horn;
    LineRenderer r;

    // Use this for initialization
    void Awake() {
        horn = GetComponent<CharacterJoint>().connectedBody.gameObject;
        Vector3 hornAnchor = GetComponent<CharacterJoint>().connectedAnchor;
        r = gameObject.AddComponent<LineRenderer>();
        r.SetVertexCount(3);
        r.material = ropeMat;
        r.SetColors(ropeColor, ropeColor);
        r.SetPosition(0, anchors[0].position);
        r.SetPosition(1, anchors[1].position);
        r.SetPosition(2, anchors[2].position);
        r.SetWidth(0.1f,0.1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 hornAnchor = horn.transform.InverseTransformPoint(GetComponent<CharacterJoint>().connectedAnchor);
        r.SetPosition(0, anchors[0].position);
        r.SetPosition(1, anchors[1].position);
        r.SetPosition(2, anchors[2].position);
    }
}
