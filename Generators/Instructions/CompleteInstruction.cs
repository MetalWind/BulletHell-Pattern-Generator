using UnityEngine;

[CreateAssetMenu]
public class CompleteInstruction : ScriptableObject
{
    public Instruction from;
    public Instruction to;

    public Projectile projPref;

    public TransitionLogicBase transition;

    public int launchesNumber;

    public Instruction[] GetCompleteInstructions()
    {
        float[] Ts = transition.GetTs(launchesNumber);
        Instruction[] complete = new Instruction[Ts.Length + 1];

        complete[0] = from;
        complete[Ts.Length] = to;

        for (int i = 0; i < Ts.Length; i++)
        {
            complete[i] = Instruction.Lerp(from, to, Ts[i]);
        }

        return complete;
    }
}
