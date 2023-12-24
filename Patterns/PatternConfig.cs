using UnityEngine;

[CreateAssetMenu]
public class PatternConfig : ScriptableObject
{
    public int numberOfProjectile;
    public float centerOfPatternArray;

    public Vector2 axisBetween;
    public float rotationBetween;

    public Vector2 axisCenter;
    public float centerRotation;

    public float radius;
    public float degrees;

    public int radialSimmetrySidesCount;
    public float radialSimmetryCenterRotation;

    public static PatternConfig Lerp(PatternConfig from, PatternConfig to, float t)
    {
        PatternConfig transitionPoint = ScriptableObject.CreateInstance<PatternConfig>();

        transitionPoint.numberOfProjectile = (int)Mathf.Lerp(from.numberOfProjectile, to.numberOfProjectile, t);
        transitionPoint.centerOfPatternArray = Mathf.Lerp(from.centerOfPatternArray, to.centerOfPatternArray, t);

        transitionPoint.axisBetween = Vector2.Lerp(from.axisBetween, to.axisBetween, t);
        transitionPoint.rotationBetween = Mathf.Lerp(from.rotationBetween, to.rotationBetween, t);

        transitionPoint.axisCenter = Vector2.Lerp(from.axisCenter, to.axisCenter, t);
        transitionPoint.centerRotation = Mathf.Lerp(from.centerRotation, to.centerRotation, t);

        transitionPoint.radius = Mathf.Lerp(from.radius, to.radius, t);
        transitionPoint.degrees = Mathf.Lerp(from.degrees, to.degrees, t);

        transitionPoint.radialSimmetrySidesCount = (int)Mathf.Lerp(from.radialSimmetrySidesCount, to.radialSimmetrySidesCount, t);
        transitionPoint.radialSimmetryCenterRotation = Mathf.Lerp(from.radialSimmetryCenterRotation, to.radialSimmetryCenterRotation, t);

        return transitionPoint;
    }
}
