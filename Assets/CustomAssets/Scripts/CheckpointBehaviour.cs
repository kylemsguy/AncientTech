using UnityEngine;
using System.Collections;

public class CheckpointBehaviour : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
        GlobalVars.hasCheckpoint = true;
        GlobalVars.lastCheckpointPosition = transform.position;
    }
}
