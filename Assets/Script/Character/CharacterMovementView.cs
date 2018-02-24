using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementView : MonoBehaviour
{
    private Animator animator;
    private CharacterMovementModel m_MovementModel;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        m_MovementModel = GetComponent<CharacterMovementModel>();
    }

    public void Update()
    {
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        Vector2 direction = m_MovementModel.GetFacingDirection();

        if(direction != Vector2.zero)
        {
            if(direction.x != 1 || direction.y!=1)
            {
                animator.SetFloat("DirX", direction.x);
                animator.SetFloat("DirY", direction.y);
            }
        }

        animator.SetBool("IsMoving", m_MovementModel.IsMoving());
    }
}
