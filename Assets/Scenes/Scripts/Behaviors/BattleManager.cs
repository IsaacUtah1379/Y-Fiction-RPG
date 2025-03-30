using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public enum BattleState
{
    Ongoing,
    Victory,
    Defeat
}

public class BattleManager : MonoBehaviour
{
    private MainCharacter[] activeCharacters;
    private MainCharacter[] unconsicousCharacters;
    private Enemy[] enemies;
    private IEntity[] initiative;
    private IEntity[] futureInitiative;
    private bool initiativeChanged = false;

    public void Start() {
        // TODO: initialize the battle
        StartCoroutine(DoRound());
    }

    private void CalculateInitiative() {
        initiativeChanged = true;
        futureInitiative = new IEntity[activeCharacters.Length + enemies.Length];
        // TODO: actually calculate futureInitiative
    }

    private IEnumerator DoRound() {
        if (initiativeChanged) {
            initiative = futureInitiative;
        }

        BattleState state;

        for (int i = 0; i < initiative.Length; i++) {
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
        if (enemies.Length == 0) {
            return BattleState.Victory;
        } else if (activeCharacters.Length == 0) {
            return BattleState.Defeat;
        } else {
            return BattleState.Ongoing;
        }
    }
}
