using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PatternEditor : MonoBehaviour
{
    public PatternConfig config;

    private void OnDrawGizmos()
    {
        List<EmiterTransform> emiters = PatternCalculus.ConfigToTransforms(config);

        foreach (EmiterTransform emiter in emiters)
        {
            DrawArrow.ForGizmo(emiter.position, PatternCalculus.DegreeToCoord(emiter.zRotation, 0.01f));
        }
    }
}