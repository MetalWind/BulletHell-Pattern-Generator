using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour 
{
    [SerializeField] private List<CompleteInstruction> _baseInstructions;

    [SerializeField] private bool _autoLaunch;
    [SerializeField] private bool _oneLaunch;
    [SerializeField] private bool _continueFromStart;

    private IEnumerator Start()
    {
        while (_autoLaunch)
        {
            yield return Launch();
            if (_oneLaunch) break;
        }
    }

    public IEnumerator Launch()
    {
        List<CompleteInstruction> reversedInstructions = GetReversedInstruction();

        foreach (var instruction in _baseInstructions)
        {
            yield return Launch(instruction);
        }

        if (!_continueFromStart)
        {
            foreach(CompleteInstruction instruction in reversedInstructions)
            {
                yield return Launch(instruction);
            }
        }
    }

    public IEnumerator Launch(CompleteInstruction completeInstruction)
    {
        Instruction[] instructions = completeInstruction.GetCompleteInstructions();

        foreach (Instruction instruction in instructions)
        {
            LaunchSinglePattern(instruction, completeInstruction.projPref);
            yield return new WaitForSeconds(instruction.launchDelay);
        }
    }

    public void LaunchSinglePattern(Instruction instruction, Projectile projectile)
    {
        List<EmiterTransform> transforms = PatternCalculus.ConfigToTransforms(instruction.config);

        foreach (EmiterTransform transform in transforms)
        {
            LaunchSingleProjectile(transform, projectile);
        }
    }

    private void LaunchSingleProjectile(EmiterTransform transform, Projectile projectile)
    {
        GameObject proj = GameObject.Instantiate(projectile.gameObject, transform.position, Quaternion.identity);
        proj.GetComponent<Projectile>().Launch(new ProjectileModel(PatternCalculus.DegreeToCoord(transform.zRotation, 1)));
    }

    private List<CompleteInstruction> GetReversedInstruction()
    {
        List<CompleteInstruction> rInstructions = new List<CompleteInstruction>();

        for(int i = _baseInstructions.Count - 1; i >= 0; i--)
        {
            rInstructions.Add(_baseInstructions[i]);
        }

        return rInstructions;
    }
}
