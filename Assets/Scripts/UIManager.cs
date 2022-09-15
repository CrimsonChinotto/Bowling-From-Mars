using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text UI_scoreText;
    public Canvas UI_Canvas;
    public Canvas EndingCanvas;
    public PointsText m_Points;
    public Text UI_totalText;
    public Transform m_blackOutSquare;
    public Canvas PauseCanvas;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R) && EndingCanvas.gameObject.activeSelf == true) {
            StartCoroutine(FadeBlackOutSquare("GameplayScene"));
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            if (PauseCanvas.gameObject.activeSelf == true) {
                PauseCanvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else {
                PauseCanvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && (Time.timeScale == 1 || GetComponent<PhaseManager>().m_CurrentPhase == PhaseManager.Phase.Ending)) {
            Debug.Log("Famme uscì");
            Application.Quit();
        }  
    }

    public void SetScore() {
        UI_Canvas.gameObject.SetActive(false);
        EndingCanvas.gameObject.SetActive(true);
        UI_scoreText.text = scoreText.text;
        UI_totalText.text = "Total: " + m_Points.m_totalPoints;

    }

    public IEnumerator FadeBlackOutSquare(string scene = "", bool fadeToBlack = true, int fadeSpeed = 1) {
        m_blackOutSquare.gameObject.SetActive(true);
        Color objectColor = m_blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack) {
            while (m_blackOutSquare.GetComponent<Image>().color.a < 1) {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                m_blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }

            SceneManager.LoadScene(scene);
        }

        else {
            while (m_blackOutSquare.GetComponent<Image>().color.a > 0) {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                m_blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }

            m_blackOutSquare.gameObject.SetActive(false);
        }
    }

}
