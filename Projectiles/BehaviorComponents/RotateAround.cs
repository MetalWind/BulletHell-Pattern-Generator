using UnityEngine;

public class RotateAround : ProjectileModifierBase
{
    [SerializeField] private float _angleChangeSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _radius;

    private ProjectileModel _model;
    private float _angle;

    public override void Initialize(Projectile projectile)
    {
        _model = projectile.model;
    }

    public override void DoNextModifierStep()
    {
        float x = Mathf.Cos(_angle) * _radius;
        float y = Mathf.Sin(_angle) * _radius;

        Vector2 direction = new Vector2(x, y);
        _model.velocity += direction * _rotationSpeed;

        _angle += _angleChangeSpeed * Time.fixedDeltaTime;
    }
}

