using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Horn : MonoBehaviour {

    public GameObject bottom;
    public float slideDownSpeed = 1f;
    public float foodHeight = .3f;       // height of food for stacking (use y scale in the future!!)
    List<Food> sandwich, allFood;
    bool stacking;

	// Use this for initialization
	void Start () {
        sandwich = new List<Food>();
        allFood = new List<Food>();
        stacking = false;
	}
	
    public void AttachFood(GameObject food)
    {
        // make sure that the food is going towards the horn
        // do some dot product shit
        // 45 degrees?

        float aligned = Vector3.Dot(-transform.up, food.GetComponent<Rigidbody>().velocity.normalized);
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
            allFood.Add(f);
            if (f.isBread)
            {
                if (!stacking)
                {
                    stacking = true;
                }
                else
                {
                    sandwich.Add(f);
                    // deliver sandwich
                    Waiter.onDuty.DeliverSandwich(sandwich);
                    stacking = false;
                    StartCoroutine(SlideSandwichOffHorn(sandwich, 2));
                    
                }
            }
            if (stacking)
            {
                // only add to sandwich if preliminary bread piece has been caught
                sandwich.Add(f);
            }
        }
    }

    IEnumerator SlideSandwichOffHorn(List<Food> sandwich, float seconds)
    {
        yield return new WaitForSeconds(slideDownSpeed);
        Debug.Break();
        GameObject sandwichObject = new GameObject();
        foreach (Food f in sandwich)
        {
            f.gameObject.GetComponent<Collider>().enabled = false;
            allFood.RemoveAt(allFood.Count - 1);
            f.gameObject.transform.parent = sandwichObject.transform;
        }
        float elapsed = 0;
        while (elapsed < seconds)
        {
            sandwichObject.transform.Translate(transform.up * 20 * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        foreach (Food f in sandwich)
        {
            Destroy(f.gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, transform.up * 20, Color.green);

    }
}
