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
        food.transform.parent = transform;
        Food f = food.GetComponent<Food>();
        food.transform.localPosition = Vector3.zero;
        StartCoroutine(f.SlideDownHorn(bottom.transform.localPosition, Quaternion.identity, slideDownSpeed));
        bottom.transform.position += bottom.transform.up * foodHeight;
    }

	// Update is called once per frame
	void Update () {

    }
}
