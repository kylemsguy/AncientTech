using UnityEngine;
using System.Collections;

public class ShootProjectileBehaviour : MonoBehaviour {

    public GameObject m_ProjectileObject;
    public Vector2 m_InitialVelocity;
    public Vector2 m_InitialPositionOffset;
    public void Shoot() {
        if (!GetComponent<Renderer>().isVisible) return;
        var newObj = Instantiate<GameObject>(m_ProjectileObject);
        newObj.transform.position = transform.position + new Vector3(m_InitialPositionOffset.x, m_InitialPositionOffset.y);
        newObj.GetComponent<Rigidbody2D>().velocity = m_InitialVelocity;
    }
}
