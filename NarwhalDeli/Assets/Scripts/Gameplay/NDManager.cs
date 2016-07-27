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

    public void TransitionToGame(uint level)
    {
        // potentially use to restart game?
        if (levelState == LevelState.GAME) return;
        levelState = LevelState.GAME;
        /* things to turn on for game:
            - Horn script
            - Cannons
            - Scoreboard
            - Supervisor
           turn off:
            - TitleBoard
            - Menus
        */

        // do deactivations first
        switch (levelState)
        {
            case LevelState.TITLE:

                break;

            default:
                break;
        }

        GetComponent<Supervisor>().enabled = true;

        // should only be one horn in scene
        GameObject.FindGameObjectWithTag("Horn").GetComponent<Horn>().enabled = true;

        // each level has its own food cannons
    }
}
