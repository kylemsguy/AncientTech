using UnityEngine;
using System.Collections;

public class SlingBallBehaviour : MonoBehaviour {
    private AudioClip m_BallExplodeSE;
    private AudioClip m_DestroyableExplodeSE;
    private AudioSource m_AudioSource;
    public GameObject m_DeathParticleSystem;

    void Start()
    {
        m_BallExplodeSE = Resources.Load<AudioClip>("Sounds/thud1");
        m_DestroyableExplodeSE = Resources.Load<AudioClip>("Sounds/explosion3");
        m_AudioSource = FindObjectOfType<AudioSource>();
    }

    void Update() {
        GetComponent<Rigidbody2D>().velocity = GlobalVars.isInWater ? new Vector2(-2, 0) : new Vector2(-4, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") return;
        if (m_AudioSource && m_BallExplodeSE)
            m_AudioSource.PlayOneShot(m_BallExplodeSE);
        var particles = Instantiate(m_DeathParticleSystem, transform.position, Quaternion.identity);
        Destroy(particles, 1);
        Destroy(gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("Destroyable")) {
            if (m_AudioSource && m_DestroyableExplodeSE)
                m_AudioSource.PlayOneShot(m_DestroyableExplodeSE);
            Destroy(other.gameObject.GetComponentInParent<Rigidbody2D>().gameObject);
        }
    }
}
