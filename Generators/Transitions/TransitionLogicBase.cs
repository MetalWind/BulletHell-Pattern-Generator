using UnityEngine;

public abstract class TransitionLogicBase : ScriptableObject
{
    public abstract float[] GetTs(int launchesNumber);
}
