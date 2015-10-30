using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	// Use this for initialization
	void Start () {
	     
	}
	
    void OnCollisionEnter(Collision c)
    {
        int layer = c.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Ground"))
        {
            StartCoroutine(CommitSudoku());
        }
    }

    void OnTriggerEnter(Collider c)
    {
        int layer = c.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Horn"))
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
