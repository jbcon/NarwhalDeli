using UnityEngine;
using System.Collections;

public class Condiment : MonoBehaviour {

    Color color;

	// Use this for initialization
	void Start () {
        color = GetComponentInChildren<MeshRenderer>().material.color;
	}
	

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.GetComponent<Food>())
        {
            MeshRenderer[] foodRenderers = coll.gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer r in foodRenderers)
            {
                Material newMat = new Material(r.material);
                newMat.color = color;
                r.material = newMat;
            }
        }
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
