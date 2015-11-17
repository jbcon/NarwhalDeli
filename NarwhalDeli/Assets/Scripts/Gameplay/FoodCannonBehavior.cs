using UnityEngine;
using System.Collections;

public class FoodCannonBehavior : MonoBehaviour {

    public float trackRange = 20;
    public float oscillationSpeed = .1f;
    private float t;

	// Use this for initialization
	void Start () {
        t = Random.Range(0, 180);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(Mathf.Cos(t * Mathf.Deg2Rad), 0, 0) * trackRange * Time.deltaTime;
        t += oscillationSpeed;
        if (t > 360)
        {
            t -= 360;
        }
	}
}
