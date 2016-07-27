using UnityEngine;
using System.Collections;
using NewtonVR;

public class BallLauncher : MonoBehaviour
{

    public float firingInterval = 2f;
    public GameObject projectile;
    public float force = 10f;
    public float spinning = 2f;
    public bool randomForce = true;

    [SerializeField]
    private NVRLever lever;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("FireRepeatedly", firingInterval);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (lever && lever.CurrentLeverPosition == NVRLever.LeverPosition.On && lever.CurrentLeverPosition != lever.LastLeverPosition)
        {
            Fire();
        }*/
    }

    public void Fire()
    {
        GameObject b = Instantiate(projectile) as GameObject;
        b.transform.position = transform.position;
        Rigidbody rb = b.GetComponent<Rigidbody>();
        // Debug.Log(f);
        rb.AddForce(Quaternion.Euler(0, 0, 0) * transform.up * force, ForceMode.Impulse);
        Quaternion spin = Random.rotationUniform;
        rb.AddTorque(spin.eulerAngles * spinning, ForceMode.Impulse);
    }

    IEnumerator FireRepeatedly(float interval)
    {
        while (true)
        {
            //Debug.Log("FIRE!!!");
            yield return new WaitForSeconds(interval);
            Fire();
        }
    }
}
