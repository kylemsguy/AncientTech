using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets._2D;

public class WaterToggleBehaviour : MonoBehaviour {
    [SerializeField] float m_MaxOxygen = 100.0f;
    [SerializeField] Text m_OxyDisplay;
    bool m_HasOxygen = false;
    float m_CurrentOxygen;
    Color m_DefaultColour = new Color(0x31 / 255.0f, 0x4D / 255.0f, 0x79 / 255.0f);
    Camera m_Camera;
    Rigidbody2D m_Rigid2D;

    // Use this for initialization
    void Start () {
        m_CurrentOxygen = m_MaxOxygen;
        m_Camera = FindObjectOfType<Camera>();
        m_Rigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        GlobalVars.isInWater = CrossPlatformInputManager.GetButton("Water");
        if (GlobalVars.isInWater && checkOxygen())
        {
            m_CurrentOxygen -= 1.0f * Time.deltaTime;
            m_Rigid2D.drag = 10;
            m_Camera.backgroundColor = Color.blue;
        }
        else
        {
            GlobalVars.isInWater = false;
            if (m_CurrentOxygen < m_MaxOxygen)
                m_CurrentOxygen += 0.5f * Time.deltaTime;
            if(m_CurrentOxygen > 0.5 * m_MaxOxygen)
                m_HasOxygen = true;
            m_Camera.backgroundColor = m_DefaultColour;
            m_Rigid2D.drag = 0;
        }

        m_OxyDisplay.text = m_CurrentOxygen.ToString();
    }

    bool checkOxygen()
    {
        if (m_CurrentOxygen <= 0)
            m_HasOxygen = false;
        return m_CurrentOxygen > 0 && m_HasOxygen;
    }
}
