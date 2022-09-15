using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public int m_currentTurn;
    public int m_currentRound;
    public BallMovement m_Ball;
    public PlayerInput m_Input;
    public Transform m_Arrow;
    private Transform m_anchor;
    public PointsText m_Points;
    public PinBehaviour[] m_pinsArray;
    public CameraBehaviour m_Camera;

    public enum Phase {
        Direction,
        Inclination,
        Rolling,
        Ending,
        Pause
    }

    public Phase m_CurrentPhase;

    private void Awake() {
        m_currentRound = 1;
    }

    void Start()
    {
        if (m_Ball == null) {
            m_Ball = GameObject.Find("Ball").GetComponent<BallMovement>();
        }

        m_currentTurn = 1;
        m_CurrentPhase = Phase.Direction;
        m_Input = GetComponent<PlayerInput>();
        m_Arrow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Ball == null) {
            m_Ball = GameObject.Find("Ball").GetComponent<BallMovement>();
        }
    }

    public void Manage() {
        if (m_CurrentPhase == PhaseManager.Phase.Direction) {
            m_Arrow.transform.position = new Vector3(m_Ball.transform.position.x, m_Arrow.transform.position.y, m_Ball.transform.position.z + (m_Arrow.transform.localScale.z / 2));
            m_Arrow.gameObject.SetActive(true);
            m_CurrentPhase = PhaseManager.Phase.Inclination;
            
        }

        else if (m_CurrentPhase == PhaseManager.Phase.Inclination) { 
            m_Arrow.gameObject.SetActive(false);
            Transform _anchor = m_Arrow.GetComponentInChildren<Transform>();
            m_Ball.Throw(_anchor);
            m_Camera.b_isMoving = true;
            m_CurrentPhase = PhaseManager.Phase.Rolling;
            StartCoroutine(BallIsMoving());
        }
    }

    IEnumerator BallIsMoving() {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => m_Ball.m_Rigidbody.velocity.magnitude < 2f);
        yield return new WaitForSeconds(3f);
        
        m_Points.AddPoints();
        m_currentTurn++;

        if (m_currentTurn > 2) {
            foreach (PinBehaviour pin in m_pinsArray) {
                pin.Reset();
            }
            m_currentTurn = 1;
            m_currentRound++;

            if (m_currentRound <= 5) {
                m_Points.AddNewRound();
            }
        }

        m_Ball.Reset();
        m_Camera.Reset();
        m_Input.enabled = true;

        

        if (m_currentRound > 5) {
            m_CurrentPhase = Phase.Ending;
            GetComponent<UIManager>().SetScore();
        }

        else {
            m_CurrentPhase = Phase.Direction;
        }
        

        
    }
}
