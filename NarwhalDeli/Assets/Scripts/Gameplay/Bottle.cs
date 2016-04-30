using UnityEngine;
using Valve.VR;
using System.Collections;

public class Bottle : MonoBehaviour {

    public GameObject proj;
    public GameObject laser;
    public GameObject bottle;

    // time before can fire condiment again
    public float cooldownRate = 3;
    public float slowMoTime = 8;
    public float burstFireTime = 0.5f;
    bool canFire;

    SteamVR_TrackedObject controller;

	// Use this for initialization
	void Start () {
        controller = GetComponentInParent<SteamVR_TrackedObject>();
        laser.transform.localRotation *= Quaternion.Euler(180,0,0);
        laser.SetActive(false);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);
        if (canFire)
        {
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                
                laser.SetActive(false);
                StartCoroutine(FireCondiments());
                StartCoroutine(RechargeBottle());
                //StartCoroutine(SpeedTimeUp());
            }
            else if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                laser.SetActive(true);
                //Time.timeScale = 0.2f;
            }
        }
        
    }

    IEnumerator FireCondiments()
    {
        float t = 0;
        while (t < burstFireTime)
        {
            GameObject p = Instantiate(proj, transform.position, transform.rotation) as GameObject;
            p.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
            Destroy(p, 2);
            t += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator RechargeBottle()
    {
        canFire = false;
        float time = 0;
        float t = 0;
        float initialHeight = bottle.transform.localScale.y;
        float initialZPos = bottle.transform.localPosition.z;
        Vector3 center = bottle.transform.localPosition;
        bottle.transform.localScale -= new Vector3(0, initialHeight, 0);
        bottle.transform.localPosition += Vector3.forward * initialHeight / 2.0f;
        while (time < cooldownRate)
        {
            t = Mathf.Lerp(0, 1, time / cooldownRate);
            if (t > 1) t = 1;
            bottle.transform.localScale = new Vector3(bottle.transform.localScale.x, t * initialHeight, bottle.transform.localScale.z);
            bottle.transform.localPosition = new Vector3(bottle.transform.localPosition.x, bottle.transform.localPosition.y, t * initialZPos);
            time += Time.unscaledDeltaTime;
            yield return null;
        }
        canFire = true;
    }

    IEnumerator SpeedTimeUp()
    {
        float t = 0 ;
        while (t < 3.0f)
        {
            t += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(0.2f, 1.0f, t);
            yield return null;
        }
    }
}
