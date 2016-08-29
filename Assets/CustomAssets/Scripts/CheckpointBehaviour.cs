using UnityEngine;
using System.Collections;

public class CheckpointBehaviour : MonoBehaviour {

    void Start()
    {
        if (!GlobalVars.isDebug)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }

	void OnTriggerEnter2D(Collider2D other) {
        GlobalVars.hasCheckpoint = true;
        GlobalVars.lastCheckpointPosition = transform.position;
    }
}
