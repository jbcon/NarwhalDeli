using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Horn : MonoBehaviour {

    public GameObject bottom;
    public float slideDownSpeed = 1f;
    public float foodHeight = .3f;       // height of food for stacking (use y scale in the future!!)
    List<GameObject> food;

	// Use this for initialization
	void Start () {
        food = new List<GameObject>();
	}
	
    public void AttachFood(GameObject food)
    {
        // make sure that the food is going towards the horn
        // do some dot product shit
        // 45 degrees?

        float aligned = Vector3.Dot(-transform.up, food.GetComponent<Rigidbody>().velocity.normalized);
        Debug.Log(aligned);
        if (aligned < 0.5f)
        {
            Debug.Log("NOPE!");
        }
        else
        {
            food.GetComponent<Rigidbody>().isKinematic = true;
            food.transform.parent = transform;
            Food f = food.GetComponent<Food>();
            food.transform.localPosition = Vector3.zero;
            StartCoroutine(f.SlideDownHorn(bottom.transform.localPosition, Quaternion.identity, slideDownSpeed));
            bottom.transform.position += bottom.transform.up * foodHeight;
        }
    }

	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, transform.up * 20, Color.green);

    }
}
