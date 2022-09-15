using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Transform m_Pin;
    private Color m_enabledColor = new Color(255, 255, 255);
    private Color m_disabledColor = new Color(0, 0, 0);
    private Image m_Image;

    void Start()
    {
        m_Image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Pin.gameObject.activeSelf == false) {
            m_Image.color = m_disabledColor;
        }

        else {
            m_Image.color = m_enabledColor;
        }
    }
}
