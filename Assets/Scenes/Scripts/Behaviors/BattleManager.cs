using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    private MainCharacter[] mainCharacters;
    private Enemy[] enemies;
    private IEntity[] initiative;
    private IEntity[] futureInitiative;
    private bool initiativeChanged = false;

    public void Start() {
        // TODO: initialize the battle
        
    }

    private void CalculateInitiative() {
        initiativeChanged = true;
        futureInitiative = new IEntity[mainCharacters.Length + enemies.Length];
        // TODO: actually calculate futureInitiative
    }

    private IEnumerator DoRound() {
        if (initiativeChanged) {
            initiative = futureInitiative;
        }
        
        for (int i = 0; i < initiative.Length; i++) {
            yield return StartCoroutine(DoTurn(initiative[i]));
        }
    }

    private IEnumerator DoTurn(IEntity entity) {
        yield return null;
    }
}
