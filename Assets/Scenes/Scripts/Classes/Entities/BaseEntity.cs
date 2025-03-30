using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : IEntity
{
    private List<IStatusEffect> phaseOneStatusEffects;
    private List<IStatusEffect> phaseTwoStatusEffects;

    public bool AddStatusEffect(IStatusEffect effect) {
        if (effect.Phase == StatusEffectPhase.PhaseOne) {
            phaseOneStatusEffects.Add(effect);
            return true;
        } else if (effect.Phase == StatusEffectPhase.PhaseTwo) {
            phaseTwoStatusEffects.Add(effect);
            return true;
        }

        return false;
    }

    public bool RemoveStatusEffect(IStatusEffect effect) {
        if (effect.Phase == StatusEffectPhase.PhaseOne) {
            return phaseOneStatusEffects.Remove(effect);
        } else if (effect.Phase == StatusEffectPhase.PhaseTwo) {
            return phaseTwoStatusEffects.Remove(effect);
        }

        return false;
    }

    public void ResolveStatusEffects(StatusEffectPhase phase) {
        
    }

    public void SortStatusEffects(List<IStatusEffect> effects) {

    }
}
