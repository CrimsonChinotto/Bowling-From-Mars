using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{
    public Image m_backgroundBar;
    public Image m_knot;

    private float m_currentPosition, m_minDistance, m_maxDistance;

    private float m_speed;

    void Start()
    {
        m_minDistance = -(m_backgroundBar.rectTransform.rect.width / 2 - 6);
        m_maxDistance = (m_backgroundBar.rectTransform.rect.width / 2 - 6);

        m_knot.rectTransform.localPosition = new Vector2(m_minDistance, m_knot.rectTransform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        m_speed = m_knot.rectTransform.localPosition.x + m_maxDistance;
        Debug.Log(m_speed);
    }

    public void MoveFromTo() {

        Vector3 minDistance = new Vector3(m_minDistance, m_backgroundBar.rectTransform.localPosition.y, 0);
        Vector3 maxDistance = new Vector3(m_maxDistance, m_backgroundBar.rectTransform.localPosition.y, 0);
        float speed = 1.5f;
        var t = 0f;

        while (t < 1f) {
            t += speed * Time.deltaTime;
            m_knot.transform.localPosition = Vector3.Lerp(minDistance, maxDistance, t);
        }

        t = 0f;

        while (t < 1f) {
            t += speed * Time.deltaTime;
            m_knot.transform.localPosition = Vector3.Lerp(maxDistance, minDistance, t);
        }
        
    }
}
