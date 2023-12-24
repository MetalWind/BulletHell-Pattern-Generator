using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileModel model;
    private ProjectileModifierBase[] _modifiers;
    private bool _launched;

    public void Launch(ProjectileModel model)
    {
        this.model = model;
        _modifiers = GetComponents<ProjectileModifierBase>();

        foreach (ProjectileModifierBase modifier in _modifiers)
        {
            modifier.Initialize(this);
        }

        _launched = true;
    }

    private void FixedUpdate()
    {
        if (!_launched) return;

        foreach(ProjectileModifierBase modifier in _modifiers)
        {
            modifier.DoNextModifierStep();
        }
    }
}
