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
    private List<Enemy> enemies;
    private List<IEntity> initiative = new List<IEntity>();
    private List<IEntity> futureInitiative = new List<IEntity>();
    private bool initiativeChanged = false;

    public void StartBattle() {
        // TODO: initialize the battle
        futureInitiative.AddRange(activeCharacters);
        futureInitiative.AddRange(enemies);
        CalculateInitiative();
        StartCoroutine(DoRound());
    }

    private void CalculateInitiative() {
        initiativeChanged = true;
        // TODO: actually calculate futureInitiative
    }

    private IEnumerator DoRound() {
        if (initiativeChanged) {
            initiative = futureInitiative;
        }

        BattleState state;

        for (int i = 0; i < initiative.Count; i++) {
            yield return StartCoroutine(DoTurn(initiative[i]));
            state = GetBattleState();

            if (state == BattleState.Defeat || state == BattleState.Victory) {
                break;
            }
        }

        // TODO: Handle victory and loss
    }

    private IEnumerator DoTurn(IEntity entity) {
        yield return null;
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
