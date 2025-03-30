using UnityEngine;

public interface IEntity
{
    bool addStatusEffect(IStatusEffect statusEffect);
    bool removeStatusEffect(IStatusEffect statusEffect);
    void resolveStatusEffects(StatusEffectPhase phase);
}
