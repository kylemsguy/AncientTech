using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets._2D;

public class WaterToggleBehaviour : MonoBehaviour {
    [SerializeField] float m_MaxOxygen = 100.0f;
    [SerializeField] float m_RegenRate = 0.5f;
    [SerializeField] Slider m_OxyValueDisplay;
    [SerializeField] Image m_OxyBarFill;
    [SerializeField] Text m_OxyDebugValue;
    [SerializeField] Image m_UnderwaterDisplay;
    bool m_HasOxygen = false;
    float m_CurrentOxygen;
    Camera m_Camera;
    Rigidbody2D m_Rigid2D;

    // Colour Declarations
    Color m_DrainingBlue = new Color(0.435f, 0.125f, 0.667f);
    Color m_DefaultBGColour = new Color(0x31 / 255.0f, 0x4D / 255.0f, 0x79 / 255.0f);

    // Use this for initialization
    void Start () {
        m_CurrentOxygen = m_MaxOxygen;
        m_Camera = FindObjectOfType<Camera>();
        m_Rigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        GlobalVars.isInWater = CrossPlatformInputManager.GetButton("Water");
        if (m_OxyBarFill)
        {
            if (m_HasOxygen)
                m_OxyBarFill.color = Color.blue;
            else
                m_OxyBarFill.color = Color.red;
        }
        if (GlobalVars.isInWater && checkOxygen())
        {
            if(m_OxyBarFill)
                m_OxyBarFill.color = m_DrainingBlue;
            m_CurrentOxygen -= 1.0f * Time.deltaTime;
            m_Rigid2D.drag = 10;
            //m_Camera.backgroundColor = Color.blue;
        }
        else
        {
            GlobalVars.isInWater = false;
            if (m_CurrentOxygen < m_MaxOxygen)
                m_CurrentOxygen += m_RegenRate * Time.deltaTime;
            if(m_CurrentOxygen > 0.5 * m_MaxOxygen)
                m_HasOxygen = true;
            //m_Camera.backgroundColor = m_DefaultBGColour;
            m_Rigid2D.drag = 0;
        }
        if(m_OxyDebugValue != null)
            m_OxyDebugValue.text = m_CurrentOxygen.ToString();
        if (m_OxyValueDisplay != null)
            m_OxyValueDisplay.value = m_CurrentOxygen / m_MaxOxygen;
    }

    bool checkOxygen()
    {
        if (m_CurrentOxygen <= 0)
            m_HasOxygen = false;
        return m_CurrentOxygen > 0 && m_HasOxygen;
    }
}
