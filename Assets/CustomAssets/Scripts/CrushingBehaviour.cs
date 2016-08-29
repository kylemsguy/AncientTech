using UnityEngine;
using UnityStandardAssets._2D;
using System.Collections;
using UnityEngine.SceneManagement;

public class CrushingBehaviour : DeathBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        Collider2D other = coll.collider;
        BoxCollider2D thisColl = FindObjectOfType<BoxCollider2D>();
        if (other.tag == "Player")
        {
            PlatformerCharacter2D player = other.GetComponent<PlatformerCharacter2D>();
            Debug.Log(player.isGrounded());
            if (player.isGrounded())
            {
                base.OnTriggerEnter2D(other);
            }
        }
    }
}
