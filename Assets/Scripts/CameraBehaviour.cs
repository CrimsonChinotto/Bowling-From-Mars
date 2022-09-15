using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject m_Ball;
    public Vector3 m_StartingPosition;
    public Quaternion m_StartingRotation;
    public Transform m_Threshold;
    public float m_cameraOffsetZ = 5f;
    public float m_cameraOffsetX = 6f;
    public bool b_isMoving;

    void Start()
    {
        m_StartingPosition = transform.position;
        m_StartingRotation = transform.rotation;
        b_isMoving = false;
    }

    void Update()
    {
        FollowBall();
    }

    public void FollowBall() {
        if (transform.position.z < m_Threshold.position.z) {
            Vector3 _position = m_Ball.transform.position;
            transform.position = new Vector3(_position.x, transform.position.y, _position.z - m_cameraOffsetZ);
        }
    }

    public void Reset() {
        transform.position = m_StartingPosition;
        transform.rotation = m_StartingRotation;
    }

}
