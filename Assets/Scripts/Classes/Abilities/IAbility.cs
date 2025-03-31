using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void use(IEntity target);
    void use(List<IEntity> targets);
}
