using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Horn : MonoBehaviour {

    public AnimationCurve slideOffCurve;
    public float distToFly = 30f;
    public GameObject bottom;
    public float slideDownSpeed = 1f;
    public float foodHeight = .3f;       // height of food for stacking (use y scale in the future!!)
    Stack<Food> sandwich, allFood;
    bool stacking;
    Vector3 bottomStart;

	// Use this for initialization
	void Start () {
        sandwich = new Stack<Food>();
        allFood = new Stack<Food>();
        stacking = false;
        bottomStart = bottom.transform.localPosition;
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
            allFood.Push(f);
            if (f.tag == "Bread")
            {
                if (!stacking)
                {
                    stacking = true;
                }
                else
                {
                    sandwich.Push(f);
                    // deliver sandwich
                    stacking = false;
                    StartCoroutine(SlideSandwichOffHorn(sandwich, .85f));
                    
                }
            }
            if (stacking)
            {
                // only add to sandwich if preliminary bread piece has been caught
                sandwich.Push(f);
            }
        }
    }

    IEnumerator SlideSandwichOffHorn(Stack<Food> sandwich, float seconds)
    {
        yield return new WaitForSeconds(slideDownSpeed);
        //Debug.Break();
        bottom.transform.localPosition = bottomStart;
        GameObject sandwichObject = new GameObject();
        sandwichObject.name = "Sandwich";
        sandwichObject.transform.position = bottom.transform.position;
        while (sandwich.Count > 0)
        {
            Food f = sandwich.Pop();
            f.transform.parent = sandwichObject.transform;
            f.transform.localPosition = sandwichObject.transform.InverseTransformPoint(f.transform.position);
            f.gameObject.GetComponent<Collider>().enabled = false;
            allFood.Pop();
        }
        sandwich = new Stack<Food>();
        //sandwichObject.transform.position = bottom.transform.position;
        float t = 0;
        Vector3 startPos = sandwichObject.transform.position;
        Vector3 endPos = startPos + transform.up * distToFly;

        MeshRenderer[] renderers = sandwichObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in renderers)
        {
            r.material = new Material(r.material);
        }

        while (t < seconds)
        {
            sandwichObject.transform.position = Vector3.Slerp(startPos, endPos, slideOffCurve.Evaluate(t / seconds));
            t += Time.deltaTime;
            foreach (MeshRenderer r in renderers)
            {
                r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, 1-(t / seconds));
            }
            yield return new WaitForEndOfFrame();
        }

        // reset for display later
        foreach (MeshRenderer r in renderers)
        {
            r.material.color += new Color(0, 0, 0, 1);
        }

        Supervisor.onDuty.DeliverSandwich(sandwichObject);
        sandwichObject.SetActive(false);

    }

    

	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, transform.up * 20, Color.green);

    }
}
