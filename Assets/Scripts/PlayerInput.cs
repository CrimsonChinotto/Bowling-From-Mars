using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public BallMovement m_Ball;
    public PhaseManager m_PhaseManager;

    void Start()
    {
        if (m_Ball == null) {
            m_Ball = GameObject.Find("Ball").GetComponent<BallMovement>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            m_PhaseManager.Manage();
        }

        if (m_Ball == null) {
            m_Ball = GameObject.Find("Ball").GetComponent<BallMovement>();
        }
    }
}
