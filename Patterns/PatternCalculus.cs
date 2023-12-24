using System;
using System.Collections.Generic;
using UnityEngine;

public static class PatternCalculus
{
    public static Vector2 DegreeToCoord(float degree, float radius)
    {
        return new Vector2(MathF.Cos(degree * Mathf.Deg2Rad), MathF.Sin(degree * Mathf.Deg2Rad)) * radius;
    }

    public static List<EmiterTransform> ConfigToTransforms(PatternConfig config)
    {
        return ApplySimmetry(GetNotSimmetricPart(config), config);
    }

    private static List<EmiterTransform> ApplySimmetry(List<EmiterTransform> notSimTransform, PatternConfig config)
    {
        if (config.radialSimmetrySidesCount == 0) return notSimTransform;

        float degreeForSimmetry = 360 / config.radialSimmetrySidesCount;
        List<EmiterTransform> allEmiters = new List<EmiterTransform>();

        float currentDegree = config.radialSimmetryCenterRotation;

        for (int i = 0; i < config.radialSimmetrySidesCount; i++)
        {
            allEmiters.AddRange(GetRotated(currentDegree, notSimTransform, config.axisCenter));
            currentDegree += degreeForSimmetry;
        }

        return allEmiters;
    }

    private static List<EmiterTransform> GetRotated(float angle, List<EmiterTransform> startTransforms, Vector2 rotationPoint) 
    {
        List<EmiterTransform> newEmiters = new List<EmiterTransform>();

        foreach (EmiterTransform transform in startTransforms)
        {
            Vector2 newPointPos = RotatePoint(transform.position, rotationPoint, angle);
            newEmiters.Add(new EmiterTransform(newPointPos, transform.zRotation + angle));
        }

        return newEmiters;
    }

    private static Vector2 RotatePoint(Vector2 point, Vector2 pivot, float angle) 
    {
        float rad = angle * Mathf.Deg2Rad;

        float cos = MathF.Cos(rad);
        float sin = MathF.Sin(rad);

        float newX = (cos * (point.x - pivot.x)) + (sin * (point.y - pivot.y)) + pivot.x;
        float newY = (sin * (point.x - pivot.x)) - (cos * (point.y - pivot.y)) + pivot.y;

        return new Vector2(newX, newY);
    }

    private static List<EmiterTransform> GetNotSimmetricPart(PatternConfig config)
    {
        List<EmiterTransform> transforms = new List<EmiterTransform>();

        if (config.numberOfProjectile % 2 == 1)
        {
            Vector2 edgeEmiter = config.axisCenter + new Vector2(config.radius, 0);
            transforms.Add(new EmiterTransform(edgeEmiter, 0));
        }

        transforms.AddRange(GetTale(config, config.axisCenter, false));
        transforms.AddRange(GetTale(config, config.axisCenter, true));

        transforms = GetRotated(config.centerRotation, transforms, config.axisCenter);

        return transforms;
    }

    private static List<EmiterTransform> GetTale(PatternConfig config, Vector2 centerPos, bool mod)
    {
        float coeff = mod ? 1 : -1;
        float lengthCoeff = mod ? 0 : 1;
        int taleLength = (int)(config.numberOfProjectile * MathF.Abs(config.centerOfPatternArray - lengthCoeff));

        List<EmiterTransform > taleTransforms = new List<EmiterTransform>();
        if (taleLength == 0) return taleTransforms;

        float currentDegree = 0;
        float currentRotation = 0;
        Vector2 currentAxis = Vector2.zero;

        for(int i = 0; i < taleLength; i++)
        {
            currentDegree += config.degrees * coeff;
            currentRotation += config.rotationBetween * coeff;
            currentAxis += new Vector2(config.axisBetween.x, config.axisBetween.y * coeff);

            Vector2 position = DegreeToCoord(currentDegree, config.radius) + currentAxis + centerPos;
            float zRotation = currentRotation;

            taleTransforms.Add(new EmiterTransform(position, zRotation));
        }

        return taleTransforms;
    }
}
