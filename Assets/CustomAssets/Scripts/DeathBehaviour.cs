using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource m_BGMSource;
    [SerializeField] private AudioClip m_DeathClip;
    private AudioSource[] m_AllAudioSources;

    private void Start()
    {
        if (!m_BGMSource)
            m_BGMSource = FindObjectOfType<AudioSource>();
        if (!m_DeathClip)
            m_DeathClip = Resources.Load<AudioClip>("Sounds/explosion1");
    }

    private void Awake()
    {
        m_AllAudioSources = FindObjectsOfType<AudioSource>();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(!m_DeathClip || !m_BGMSource)
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
            else
            {
                StartCoroutine("WaitForDeath");
            }
        }
    }

    private IEnumerator WaitForDeath()
    {
        StopAllAudio();
        m_BGMSource.PlayOneShot(m_DeathClip);
        // stop time
        Time.timeScale = 0;
        yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(1));
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        Time.timeScale = 1;
    }

    private void StopAllAudio()
    {
        foreach(var source in m_AllAudioSources)
        {
            if (source == null) continue;
            source.Stop();
        }
    }
}