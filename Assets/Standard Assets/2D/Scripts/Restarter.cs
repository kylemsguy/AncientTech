using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        [SerializeField] private AudioSource m_BGMSource;
        [SerializeField] private AudioClip m_DeathClip;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                if(!m_DeathClip || !m_BGMSource)
                {
                    SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                }
                else
                {
                    m_BGMSource.PlayOneShot(m_DeathClip);
                    // stop time
                    //Time.timeScale = 0;
                    StartCoroutine("waitDeath");
                }
            }
        }

        private IEnumerator waitDeath()
        {
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
