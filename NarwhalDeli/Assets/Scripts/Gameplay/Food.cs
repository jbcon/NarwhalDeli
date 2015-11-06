using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    private bool onGround = false;

	// Use this for initialization
	void Start () {
	     
	}
	
    void OnCollisionEnter(Collision c)
    {
        int layer = c.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = true;
            StartCoroutine(CommitSudoku());
        }
    }

    void OnTriggerEnter(Collider c)
    {
        int layer = c.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Horn") && !onGround)
        {
            gameObject.layer = LayerMask.NameToLayer("FoodOnHorn");
            GetComponent<Rigidbody>().isKinematic = true;
            c.GetComponent<Horn>().AttachFood(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
        
	}

    public IEnumerator SlideDownHorn(Vector3 target, Quaternion endRot, float time)
    {
        float elapsed = 0;
        while (elapsed < time)
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, target, elapsed/time);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, endRot, elapsed/time);
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator CommitSudoku()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
