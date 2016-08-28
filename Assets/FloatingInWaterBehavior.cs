using UnityEngine;
using System.Collections;

public class FloatingInWaterBehavior : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().gravityScale = GlobalVars.isInWater ? -5f : 1f;
        GetComponent<Rigidbody2D>().drag = GlobalVars.isInWater ? 10 : 0;
	}
}
