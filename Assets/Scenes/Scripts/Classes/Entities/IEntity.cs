using UnityEngine;

public interface IEntity
{
    bool AddStatusEffect(IStatusEffect statusEffect);
    bool RemoveStatusEffect(IStatusEffect statusEffect);
    void ResolveStatusEffects(StatusEffectPhase phase);
}
