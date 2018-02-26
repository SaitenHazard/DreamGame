using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementModel : CharacterMovementModel
{
    public void DoAction()
    {
        InteractableBase interactableInProximity = FindInteractableInProximity();

        if (interactableInProximity == null)
        {
            DoAttack();
            return;
        }

        interactableInProximity.OnInteract();
    }

    private void DoAttack()
    {
        //Later
    }

    private InteractableBase FindInteractableInProximity()
    {
        InteractableBase interactableBase = null;

        return interactableBase;
    }
}
