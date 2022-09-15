using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsText : MonoBehaviour
{
    public static int m_currentPoints;
    private int m_lastRoundPoints;
    public int m_totalPoints;
    public Text m_pointsText;
    public PhaseManager m_PhaseManager;
    public SoundManager m_SoundManager;

    void Start()
    {
        m_currentPoints = 0;
        m_totalPoints = 0;
        m_pointsText = GetComponent<Text>();
        m_pointsText.text += "Round " + m_PhaseManager.m_currentRound + ":  ";
    }

    public void AddNewRound() {
        m_currentPoints = 0;
        m_lastRoundPoints = 0;
        m_pointsText.text += "\n";
        m_pointsText.text += "Round " + m_PhaseManager.m_currentRound + ":  ";
    }

    public void AddPoints() {
        if (m_currentPoints == 0 || m_currentPoints - m_lastRoundPoints == 0) {
            m_pointsText.text += "-" + "  ";
            m_SoundManager.PlaySound(Sound.Groaming);
        }

        else if (m_currentPoints == 10 && m_PhaseManager.m_currentTurn == 1) {
            m_pointsText.text += "X" + "  ";
            m_SoundManager.PlaySound(Sound.Clapping);
            m_PhaseManager.m_currentTurn++;
        }
        
        else if (m_currentPoints == 10 && m_PhaseManager.m_currentTurn == 2) {
            m_pointsText.text += "/" + "  ";
            m_SoundManager.PlaySound(Sound.Clapping);
        }

        else {
            m_pointsText.text += (m_currentPoints - m_lastRoundPoints).ToString() + "  ";
        }

        m_lastRoundPoints = m_currentPoints;

        if (m_PhaseManager.m_currentTurn == 2) {
            m_totalPoints += m_currentPoints;
        }
    }
}
