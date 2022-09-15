using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehaviour : MonoBehaviour
{
    private Vector3 m_startingPosition;
    private Quaternion m_startingRotation;
    public Transform m_floor;
    public float m_XRotation;
    // Start is called before the first frame update
    void Start()
    {
        m_startingPosition = transform.localPosition;
        m_startingRotation = transform.localRotation;
        m_XRotation = transform.eulerAngles.x;
    }


    void Update()
    {
        if (transform.rotation.eulerAngles.x <30 || transform.rotation.eulerAngles.x > 340 || transform.position.y < m_floor.position.y) {
            gameObject.SetActive(false);
            PointsText.m_currentPoints++;
        }

        m_XRotation = transform.eulerAngles.x;
    }

    public void Reset() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = m_startingPosition;
        transform.rotation = m_startingRotation;
        gameObject.SetActive(true);        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            gameObject.SetActive(false);
            PointsText.m_currentPoints++;
        }
    }
}
