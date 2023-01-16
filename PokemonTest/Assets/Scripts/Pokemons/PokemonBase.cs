using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    //Base Stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMoves> learnableMoves;

    //Get properties for Pokemon script
    public string GetName() { return name; }

                                                            //public string Name //another way of using property
                                                            //{
                                                            //    get { return name; }
                                                            //}

    public string GetDescription() { return description; }
    public Sprite GetFrontSprite() { return frontSprite; }
    public Sprite GetBackSprite() { return backSprite; }

    public PokemonType GetType1() { return type1; }
    public PokemonType GetType2() { return type2; }

    public int GetMaxHp() { return maxHp; }
    public int GetAttack() { return attack; }
    public int GetDefense() { return defense; }
    public int GetSpAttack() { return spAttack; }
    public int GetSpDefense() { return spDefense; }
    public int GetSpeed() { return speed; }

    public List<LearnableMoves> GetLearnableMoves() { return learnableMoves; }

}

[System.Serializable] //makes it visible in the Inspector
public class LearnableMoves
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase GetMoveBase() { return moveBase; }
    public int GetLevel() { return level; }
}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}
