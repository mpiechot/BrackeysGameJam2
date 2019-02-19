using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractObject : MonoBehaviour
{

    public bool CanGetIngredient;
    public bool IsEmpty;

    [SerializeField]
    protected float ProcessTime;
    protected float currentProcessTime;
    protected bool isProcessing;
    protected Essen currentEssen;

    public abstract Essen GetFood();
    public virtual void AddFood(Essen foodToAdd) { }

    protected virtual void Process() { }
}
