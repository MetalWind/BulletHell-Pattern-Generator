using UnityEngine;

[CreateAssetMenu]
public class LinearTransition : TransitionLogicBase
{
    public override float[] GetTs(int launchesNumber)
    {
        float k = 1 / (float)launchesNumber;

        float[] ts = new float[launchesNumber];
        for (int i = 0;i < ts.Length; i++)
        {
            ts[i] = k * i;
        }

        return ts;
    }
}
