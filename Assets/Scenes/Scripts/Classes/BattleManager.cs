using UnityEngine;

public class BattleManager
{
    private MainCharacter[] mainCharacters;
    private Enemy[] enemies;
    private IEntity[] initiative;

    public BattleManager(Enemy[] enemies) {
        this.mainCharacters = GameObject.Find("Party").GetComponent<PartyInfo>().mainCharacters;
        this.enemies = enemies;
    }

    public void Start() {

    }
}
