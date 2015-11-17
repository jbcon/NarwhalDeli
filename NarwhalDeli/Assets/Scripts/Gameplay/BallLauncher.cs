using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour
{

    public float interval = 2f;
    public GameObject projectile;
    public float force = 10f;
    public float spinning = 2f;
    public bool randomForce = true;

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
            Rigidbody rb = b.GetComponent<Rigidbody>();
            float f;
            if (randomForce)
            {
                f = Random.Range(1, 1) * force;
            }
            else
            {
                f = (Random.value + 1) * force;
            }
            rb.AddForce(Quaternion.Euler(0,0,0) * transform.up * f, ForceMode.Impulse);
            Quaternion spin = Random.rotationUniform;
            rb.AddTorque(spin.eulerAngles * spinning, ForceMode.Impulse);            
        }
    }
}
