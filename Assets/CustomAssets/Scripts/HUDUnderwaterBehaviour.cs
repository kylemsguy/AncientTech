using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDUnderwaterBehaviour : MonoBehaviour {
    [SerializeField] Image m_UnderwaterOverlay;
    Color m_UnderwaterColor;
    Color m_TransparentColor;

	// Use this for initialization
	void Start () {
        m_UnderwaterColor = new Color(0, 0, 1.0f, 0.4f);
        m_TransparentColor = new Color(0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (GlobalVars.isInWater)
            // i'm in water
            m_UnderwaterOverlay.color = m_UnderwaterColor;
        else
            m_UnderwaterOverlay.color = m_TransparentColor;
	}
}
