using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArrow : MonoBehaviour
{
    public Transform m_Pivot;

    public int m_direction;

    public 

    void Start()
    {
        m_direction = 1;
    }

    void Update()
    {
        if (transform.rotation.y > .45f) {
            m_direction = -1;
        }

        else if (transform.rotation.y < -.45f) {
            m_direction = 1;
        }

        transform.RotateAround(m_Pivot.position, m_direction * Vector3.up, 40 * Time.deltaTime);
    }
}
