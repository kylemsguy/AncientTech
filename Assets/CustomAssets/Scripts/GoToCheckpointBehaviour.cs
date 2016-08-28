using UnityEngine;
using System.Collections;

public class GoToCheckpointBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    if (GlobalVars.hasCheckpoint) {
            transform.position = GlobalVars.lastCheckpointPosition;
        }
	}
}
