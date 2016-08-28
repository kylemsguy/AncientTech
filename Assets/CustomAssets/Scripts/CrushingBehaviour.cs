using UnityEngine;
using UnityStandardAssets._2D;
using System.Collections;
using UnityEngine.SceneManagement;

public class CrushingBehaviour : DeathBehaviour {

    protected void OnCollisionEnter2D(Collision2D coll)
    {
        Collider2D other = coll.collider;
        if (other.tag == "Player")
        {
            PlatformerCharacter2D player = other.GetComponent<PlatformerCharacter2D>();
            Debug.Log(player.isGrounded());
            if (player.isGrounded() && coll.relativeVelocity.y > 100)
            {
                base.OnTriggerEnter2D(other);
            }
        }
    }
}
