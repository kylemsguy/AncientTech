using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndLevelBehaviour : MonoBehaviour {
    [SerializeField] string m_NextSceneID = "main";

	// Use this for initialization
	void Start () {
        Debug.Log(SceneManager.GetSceneAt(0).name);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(m_NextSceneID);
        }
    }   
}
