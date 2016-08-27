using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using UnityStandardAssets._2D;

public class WaterToggleBehaviour : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GlobalVars.isInWater = CrossPlatformInputManager.GetButton("Water");
        var rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.gravityScale = GlobalVars.isInWater ? 0.625f : 3;
        rigid2d.drag = GlobalVars.isInWater ? 1 : 0;
        var platchar = GetComponent<PlatformerCharacter2D>();
        platchar.m_JumpForce = GlobalVars.isInWater ? 300 : 800;
        platchar.m_MaxSpeed = GlobalVars.isInWater ? 3 : 9;
        FindObjectOfType<Camera>().backgroundColor = GlobalVars.isInWater ? Color.blue : Color.red;
	}
}
