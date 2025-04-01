using System.Collections;
using UnityEngine;

public interface IEntity
{
    bool AddStatusEffect(IStatusEffect statusEffect);
    bool RemoveStatusEffect(string name, StatusEffectPhase phase);
    void ResolveStatusEffects(StatusEffectPhase phase);
    IEnumerator Act();
}
