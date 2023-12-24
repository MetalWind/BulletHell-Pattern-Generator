using UnityEngine;

public abstract class ProjectileModifierBase : MonoBehaviour
{
    public abstract void Initialize(Projectile projectile);

    public abstract void DoNextModifierStep();
}