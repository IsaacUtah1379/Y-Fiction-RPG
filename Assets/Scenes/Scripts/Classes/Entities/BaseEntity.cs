using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : IEntity
{
    private List<IStatusEffect> phaseOneStatusEffects;
    private List<IStatusEffect> phaseTwoStatusEffects;
}
