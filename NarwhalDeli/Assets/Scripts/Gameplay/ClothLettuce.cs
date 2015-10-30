using UnityEngine;
using System.Collections;
using System.Linq;

public class ClothLettuce : MonoBehaviour {

    private Cloth cl;

	// Use this for initialization
	void Start () {
        CapsuleCollider horn = GameObject.FindGameObjectWithTag("Horn").GetComponent<CapsuleCollider>();
        cl = GetComponent<Cloth>();
        cl.capsuleColliders.SetValue(horn, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
