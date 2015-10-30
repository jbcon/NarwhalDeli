using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour
{

    public float interval = 2f;
    public GameObject projectile;
    public float force = 10f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Fire()
    {
        while (true)
        {
            //Debug.Log("FIRE!!!");
            yield return new WaitForSeconds(interval);
            GameObject b = Instantiate(projectile) as GameObject;
            b.transform.position = transform.position;
            b.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(0,0,0) * transform.forward * force, ForceMode.Impulse);
        }
    }
}
