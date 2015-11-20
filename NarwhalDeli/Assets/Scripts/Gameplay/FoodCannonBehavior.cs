using UnityEngine;
using System.Collections;

public class FoodCannonBehavior : MonoBehaviour {

    // public float trackRange = 20;
    public float sweepAngle = 60f;
    public float oscillationSpeed = .1f;
    private float t;
    private float initialYaw;

	// Use this for initialization
	void Start () {
        t = 0;
        initialYaw = transform.rotation.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
        // transform.position += new Vector3(Mathf.Cos(t * Mathf.Deg2Rad), 0, 0) * trackRange * Time.deltaTime;
        t += oscillationSpeed;
        if (t > 360)
        {
            t -= 360;
        }

        /* Rotating cannon, mounted to a wall */
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                                            initialYaw + Mathf.Cos(t * Mathf.Deg2Rad) * sweepAngle / 2, 
                                            transform.rotation.eulerAngles.z);
         
	}
}
