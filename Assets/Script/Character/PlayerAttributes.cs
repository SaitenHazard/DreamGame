using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : CharacterAttributes {

    bool m_freezeGameState = false;
    public GameObject speechBubble;

    public static PlayerAttributes instance;

    private void Awake()
    {
        instance = this;
    }

    public bool IsGameStateFrozen()
    {
        return m_freezeGameState;
    }

    public void setFreezeGameState(bool freezeGameState)
    {
        m_freezeGameState = freezeGameState;
    }
}
