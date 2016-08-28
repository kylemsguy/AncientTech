using UnityEngine;
using System.Collections;

public class SlingBallBehaviour : MonoBehaviour {
    public GameObject m_DeathParticleSystem;

    void Update() {
        GetComponent<Rigidbody2D>().velocity = GlobalVars.isInWater ? new Vector2(-2, 0) : new Vector2(-4, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        var particles = Instantiate(m_DeathParticleSystem, transform.position, Quaternion.identity);
        Destroy(particles, 1);
        Destroy(gameObject);
    }
}
