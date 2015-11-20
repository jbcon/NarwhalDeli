using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waiter : MonoBehaviour {
    public static Waiter onDuty = null;
    private Horn horn;

	// Use this for initialization
	void Start () {
        horn = GameObject.FindGameObjectWithTag("Horn").GetComponent<Horn>();
        if (onDuty == null)
        {
            onDuty = this;
        }
    }

    public void DeliverSandwich(List<Food> sandwich)
    {
        ServeSandwich(sandwich);
    }

    void ServeSandwich(List<Food> sandwich)
    {
        // scoring?
    }

	// Update is called once per frame
	void Update () {
	
	}
}
