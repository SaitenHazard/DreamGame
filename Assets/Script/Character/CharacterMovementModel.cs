using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementModel : MonoBehaviour
{
    private float m_speed;

    private Rigidbody2D m_Body;

    private Vector2 m_MovmentDirection;
    private Vector2 m_RecievedDirection;
    private Vector2 m_FacingDirection;

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_speed = gameObject.GetComponent<CharacterAttributes>().getSpeed();

        Debug.Log(m_Body);
    }

    protected void Update()
    {
        UpdateDirection();
        ResetRecievedDirection();
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    private void ResetRecievedDirection()
    {
        m_RecievedDirection = Vector2.zero;
    }

    private void UpdateMovement()
    {
        if(m_MovmentDirection != Vector2.zero)
        {
            m_MovmentDirection.Normalize();
        }

        m_Body.velocity = m_MovmentDirection * m_speed;
    }

    private void UpdateDirection()
    {
        if (PlayerAttributes.instance.IsGameStateFrozen()) return;

        m_MovmentDirection = new Vector2(m_RecievedDirection.x, m_RecievedDirection.y);

        if (m_RecievedDirection != Vector2.zero)
        {
            Vector2 facingDirection = m_MovmentDirection;

            if (facingDirection.x != 0 && facingDirection.y != 0)
            {
                if (facingDirection.x == m_FacingDirection.x)
                {
                    facingDirection.y = 0;
                }
                else if (facingDirection.y == m_FacingDirection.y)
                {
                    facingDirection.x = 0;
                }
                else
                {
                    facingDirection.x = 0;
                }
            }

            m_FacingDirection = facingDirection;
        }
    }

    //private void UpdateMovement()
    //{
    //    if (m_MovmentDirection != Vector2.zero)
    //    {
    //        m_MovmentDirection.Normalize();
    //    }
    //}

    public Vector2 GetFacingDirection()
    {
        return m_FacingDirection;
    }

    public bool IsMoving()
    {
        return m_MovmentDirection != Vector2.zero;
    }

    public void SetDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return;
        }

        m_RecievedDirection = direction;
    }

    virtual public void DoAction()
    {

    }
}
