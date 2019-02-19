using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractObject : MonoBehaviour
{

    public bool CanGetIngredient;
    public bool IsEmpty;

    public abstract Essen GetFood();

}
