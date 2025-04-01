using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public enum StatusEffectPhase
{
    PhaseOne,
    PhaseTwo
}

public interface IStatusEffect
{
    string Name { get; }
    int Priority { get; }
    StatusEffectPhase Phase { get; }
    bool update(IEntity entity);
    // update will return true when it should be kept and false once it expires
}
