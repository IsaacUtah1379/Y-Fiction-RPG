using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public enum StatusEffectPhase
{
    PhaseOne,
    PhaseTwo
}

public interface IStatusEffect
{
    StatusEffectPhase Phase { get; }
    int Priority { get; }
    bool update(IEntity entity);
}
