using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExponateButtonHandler : MonoBehaviour
{
    public ARExponate[] exponate;

    public void MoveExponateToTarget(int index)
    {
        if(index >= 0 && index < exponate.Length)
        {
            exponate[index].StartMoving();
        }
    }

    public void MoveExponateToInitial(int index)
    {
        if (index >= 0 && (index < exponate.Length))
        {
            exponate[index].ResetPosition();
        }
    }
}
