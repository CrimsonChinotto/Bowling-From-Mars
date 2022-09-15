using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public Transform m_Floor;
    public Rigidbody m_Rigidbody;
    public CameraBehaviour m_Camera;

    public PhaseManager m_Phase;
    public SoundManager m_Sound;

    private float m_maxDistance;

    [SerializeField]
    private float m_horizontalSpeed;
    private float m_direction = 1;
    private float m_currentForce;
    public Vector3 m_StartingPosition;
    public bool b_hasAlreadyCollided;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_maxDistance = (m_Floor.transform.localScale.x / 2) - 1;
        m_currentForce = 1000f;
        m_StartingPosition = transform.position;
        b_hasAlreadyCollided = false;
    }

    // Update is called once per frame
    void Update()
    {

        HorizontalMovement();        
    }

    private void HorizontalMovement() {
        if (m_Phase.m_CurrentPhase == PhaseManager.Phase.Direction) {
            if (transform.position.x > m_maxDistance) {
                m_direction = -1;
            }

            if (transform.position.x < -m_maxDistance) {
                m_direction = 1;
            }

            transform.Translate(m_direction * Vector3.right * Time.deltaTime * m_horizontalSpeed);
        }
    }

    public void Throw(Transform direction) {
        transform.rotation = direction.rotation;
        m_Rigidbody.AddForce(transform.forward.normalized * m_currentForce, ForceMode.Impulse);
        m_Sound.PlaySound(Sound.Rolling);
    }

    public void Reset() {
        transform.position = m_StartingPosition;
        transform.rotation = Quaternion.identity;
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
        b_hasAlreadyCollided = false;
    }

    public void OnCollisionEnter(Collision collision) {
        m_Camera.b_isMoving = false;

        if (collision.gameObject.CompareTag("Pin") && !b_hasAlreadyCollided) {
            b_hasAlreadyCollided = true;
            m_Sound.PlaySound(Sound.Strike);
        }
    }
}
