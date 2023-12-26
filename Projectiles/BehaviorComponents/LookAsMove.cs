using UnityEngine;

public class LookAsMove : ProjectileModifierBase
{
    private ProjectileModel _model;
    private Vector2 _lastPos;

    public override void Initialize(Projectile projectile)
    {
        _model = projectile.model;
        _lastPos = transform.position;
    }

    public override void DoNextModifierStep()
    {
        Vector2 displacement = _lastPos - (Vector2)transform.position;
        _model.lookDirection = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg + 90;
        _lastPos = transform.position;
    }
}
