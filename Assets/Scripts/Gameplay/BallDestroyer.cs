using UnityEngine;
using System.Collections;

public class BallDestroyer : MonoBehaviour {

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

	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator CommitSudoku()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
