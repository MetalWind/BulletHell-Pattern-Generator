using System;
using UnityEngine;

[Serializable]
public class Instruction
{
    public PatternConfig config;
    public float launchDelay;

    public static Instruction Lerp(Instruction from, Instruction to, float t)
    {
        if(t > 1) t = 1;
        if(t < 0) t = 0;

        Instruction interpolated = new Instruction();

        interpolated.config = PatternConfig.Lerp(from.config, to.config, t);
        interpolated.launchDelay = Mathf.Lerp(from.launchDelay, to.launchDelay, t);

        return interpolated;
    }
}
