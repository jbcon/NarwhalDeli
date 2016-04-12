using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Supervisor : MonoBehaviour {
    public static Supervisor onDuty = null;
    private Horn horn;
    private Text orderPad;
    private List<GameObject> sandwiches;
    private Queue<GameObject> foodInWater;
    [SerializeField]
    private int maxFoodInWater = 40;

	// Use this for initialization
	void Start () {
        sandwiches = new List<GameObject>();
        foodInWater = new Queue<GameObject>();
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
        orderPad.text = "TOTAL: " + sandwiches.Count;
    }

    public void DeliverSandwich(GameObject sandwich)
    {
        sandwiches.Add(sandwich);
        //ServeSandwich(sandwich);
    }

    void ServeSandwich(Stack<Food> sandwich)
    {
        // scoring?
    }

    public void AddFoodToFloor(GameObject f)
    {
        foodInWater.Enqueue(f);
        if (foodInWater.Count > maxFoodInWater)
        {
            GameObject g = foodInWater.Dequeue();
            Destroy(g);
        }
    }

	// Update is called once per frame
	void Update () {
        WriteOrder();
	}
}
