using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionModel : MonoBehaviour {

    private CharacterMovementModel m_MovementModel;

    private void Awake()
    {
        m_MovementModel = GetComponent<CharacterMovementModel>();
    }

    public void OnInteract()
    {
        
    }
}
