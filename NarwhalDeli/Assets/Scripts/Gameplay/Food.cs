using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    [SerializeField]
    public static float flotationConstant = 1f;
    public bool isBread = false;

    private Rigidbody rb;
    private bool onGround = false;
    private static float waterHeight;

	// Use this for initialization
	void Start () {
        waterHeight = GameObject.FindGameObjectWithTag("Water").transform.position.y+0.2f;
        rb = GetComponent<Rigidbody>();
	}
	
    void OnCollisionEnter(Collision c)
    {
        int layer = c.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Water"))
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
            c.GetComponent<Horn>().AttachFood(gameObject);
        }
    }

    void FixedUpdate()
    {
        //buoyant force
        if (transform.position.y < waterHeight)
        {
            rb.velocity *= 0.3f;
            rb.AddForce((waterHeight - transform.position.y) * Vector3.up, ForceMode.Impulse);
            Quaternion targetRot = Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime);
        }
    }

	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, GetComponent<Rigidbody>().velocity, Color.red);
	}

    public IEnumerator SlideDownHorn(Vector3 target, Quaternion endRot, float time)
    {
        float elapsed = 0;

        // So they are rotated differently on the horn, but still stack
        Quaternion finalRot = Quaternion.Euler(endRot.eulerAngles.x,
                                            transform.localRotation.eulerAngles.y,
                                            endRot.eulerAngles.z);

        while (elapsed < time)
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, target, elapsed/time);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRot, elapsed/time);
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
