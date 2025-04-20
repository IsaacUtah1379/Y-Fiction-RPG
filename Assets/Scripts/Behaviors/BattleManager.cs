using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BattleState
{
    Ongoing,
    Victory,
    Defeat
}

public class BattleManager : MonoBehaviour
{
    private List<MainCharacter> activeCharacters;
    private List<MainCharacter> unconsicousCharacters;
    private List<Ally> allies;
    private List<Enemy> enemies;
    private List<IEntity> initiative = new List<IEntity>();
    private List<IEntity> futureInitiative = new List<IEntity>();
    private bool initiativeChanged = false;

    public void StartBattle(List<MainCharacter> chars, List<Ally> alls, List<Enemy> ens) {
        // TODO: initialize the battle screen
        activeCharacters = chars;
        allies = alls;
        enemies = ens;

        futureInitiative.AddRange(activeCharacters);
        futureInitiative.AddRange(allies);
        futureInitiative.AddRange(enemies);
        CalculateInitiative();
        StartCoroutine(DoRound());
    }

    public void CalculateInitiative() {
        initiativeChanged = true;
        // TODO: actually calculate futureInitiative
    }

    private IEnumerator DoRound() {
        if (initiativeChanged) {
            initiative = futureInitiative;
        }

        BattleState state = BattleState.Ongoing;

        for (int i = 0; i < initiative.Count; i++) {
            yield return StartCoroutine(DoTurn(initiative[i]));
            state = GetBattleState();

            if (state == BattleState.Defeat || state == BattleState.Victory) {
                break;
            }
        }

        
        if (state == BattleState.Victory) {
            // TODO: handle victory
        } else if (state == BattleState.Defeat) {
            // TODO: handle defeat
        } else {
            StartCoroutine(DoRound());
        }
    }

    private IEnumerator DoTurn(IEntity entity) {
        entity.ResolveStatusEffects(StatusEffectPhase.PhaseOne);
        yield return StartCoroutine(entity.Act(this));
        entity.ResolveStatusEffects(StatusEffectPhase.PhaseTwo);
    }

    private BattleState GetBattleState() {
        if (enemies.Count == 0) {
            return BattleState.Victory;
        } else if (activeCharacters.Count == 0) {
            return BattleState.Defeat;
        } else {
            return BattleState.Ongoing;
        }
    }

    public void Death(IEntity entity) {
        if (entity is Enemy enemy) {
            enemies.Remove(enemy);
        } else if (entity is MainCharacter character) {
            unconsicousCharacters.Add(character);
            activeCharacters.Remove(character);
        }
    }
}
