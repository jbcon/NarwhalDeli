using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Waiter : MonoBehaviour {
    public static Waiter onDuty = null;
    private Horn horn;
    private Text orderPad;

	// Use this for initialization
	void Start () {
        horn = GameObject.FindGameObjectWithTag("Horn").GetComponent<Horn>();
        if (onDuty == null)
        {
            onDuty = this;
        }
        orderPad = GameObject.FindGameObjectWithTag("OrderPad").GetComponent<Text>();
        WriteOrder();
    }

    void WriteOrder()
    {
        orderPad.text = "Sandwich";
    }

    public void DeliverSandwich(Stack<Food> sandwich)
    {
        ServeSandwich(sandwich);
    }

    void ServeSandwich(Stack<Food> sandwich)
    {
        // scoring?
    }

	// Update is called once per frame
	void Update () {
	
	}
}
