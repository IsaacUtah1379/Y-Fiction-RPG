using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : IEntity
{
    private List<IStatusEffect> phaseOneStatusEffects;
    private List<IStatusEffect> phaseTwoStatusEffects;

    public bool AddStatusEffect(IStatusEffect effect) {
        // FIXME: I'm not complicated enough yet!
        // (We still need to handle adding effects that already exist)

        if (effect.Phase == StatusEffectPhase.PhaseOne) {
            phaseOneStatusEffects.Add(effect);
            return true;
        } else if (effect.Phase == StatusEffectPhase.PhaseTwo) {
            phaseTwoStatusEffects.Add(effect);
            return true;
        }

        return false;
    }

    public bool RemoveStatusEffect(string name, StatusEffectPhase phase) {
        List<IStatusEffect> effects;
        if (phase == StatusEffectPhase.PhaseOne) {
            effects = phaseOneStatusEffects;
        } else if (phase == StatusEffectPhase.PhaseTwo) {
            effects = phaseTwoStatusEffects;
        } else {
            effects = new List<IStatusEffect>();
        }

        for (int i = 0; i < effects.Count; i++) {
            if (effects[i].Name == name) {
                effects.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    private bool RemoveStatusEffect(IStatusEffect effect) {
        if (effect.Phase == StatusEffectPhase.PhaseOne) {
            return phaseOneStatusEffects.Remove(effect);
        } else if (effect.Phase == StatusEffectPhase.PhaseTwo) {
            return phaseTwoStatusEffects.Remove(effect);
        }

        return false;
    }

    public void ResolveStatusEffects(StatusEffectPhase phase) {
        List<IStatusEffect> effects;
        if (phase == StatusEffectPhase.PhaseOne) {
            effects = phaseOneStatusEffects;
        } else if (phase == StatusEffectPhase.PhaseTwo) {
            effects = phaseTwoStatusEffects;
        } else {
            effects = new List<IStatusEffect>();
        }

        if (effects.Count > 0) {
            SortStatusEffects(effects);
            for (int i = 0; i < effects.Count; i++) {
                bool keep = effects[i].update(this);
                if (!keep) {
                    RemoveStatusEffect(effects[i]);
                }
            }
        }
    }

    public void SortStatusEffects(List<IStatusEffect> effects) {

    }
}
