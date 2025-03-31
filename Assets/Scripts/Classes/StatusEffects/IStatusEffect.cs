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
    string Name { get; }
    int Priority { get; }
    bool update(IEntity entity);
    // update will return true when it should be kept and false once it expires
}
