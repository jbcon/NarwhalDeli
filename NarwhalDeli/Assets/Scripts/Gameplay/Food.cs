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
        }
    }

	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator CommitSudoku()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
