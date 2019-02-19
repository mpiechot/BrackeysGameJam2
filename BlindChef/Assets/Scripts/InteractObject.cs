using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractObject : MonoBehaviour
{

    public bool CanGetIngredient { get; protected set; }
    public bool IsEmpty { get; protected set; }

    [SerializeField]
    protected float ProcessTime;
    protected float currentProcessTime;
    protected bool isProcessing;
    protected Essen currentEssen;

    public abstract Essen GetFood();
    public virtual void AddFood(Essen foodToAdd) { }

    protected virtual void Process() { }
}
