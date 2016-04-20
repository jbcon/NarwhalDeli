using UnityEngine;
using System.Collections;

public class NDManager : MonoBehaviour {

    public static NDManager manager;
    public enum LevelState {  TITLE, MENU, GAME };
    public LevelState levelState = LevelState.TITLE;

	// Use this for initialization
	void Awake () {
        if (manager == null)
            manager = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
