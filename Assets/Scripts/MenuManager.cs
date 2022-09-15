using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public Transform m_blackOutSquare;

    public void Update(){
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(FadeBlackOutSquare("GameplayScene"));
        }
    }

    public IEnumerator FadeBlackOutSquare(string scene, bool fadeToBlack = true, int fadeSpeed = 1) {
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
        }
    }
}

