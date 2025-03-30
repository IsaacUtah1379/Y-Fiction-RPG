using UnityEngine;

public enum StatusEffectPhase
{
    PhaseOne,
    PhaseTwo
}

public interface IStatusEffect
{
    StatusEffectPhase Phase { get; }
    bool update(IEntity entity);
}
