using UnityEngine;

public interface IAbility
{
    void use(IEntity target);
    void use(IEntity[] targets);
}
