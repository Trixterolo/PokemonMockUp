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

public class TypeChart
{
    static float[][] chart = //static lets us use the chart directly from the class WITHOUT creating an OBJECT.
    {
        //Remember to subtract one from the interger value of the ENUM because we have None as Index 0.
        //                          NOR  FIR   WAT  ELE   GRA   ICE  FIG   POI   GRO  FLY   PSY   BUG  ROC   GHO  DRA
        /*NOR*/        new float[] { 1f,  1f,   1f,  1f,   1f,   1f,  1f,   1f,   1f,  1f,   1f,   1f, 0.5f,  0f,  1f},
        /*FIR*/        new float[] { 1f, 0.5f, 0.5f, 1f,   2f,   2f,  1f,   1f,   1f,  1f,   1f,   2f, 0.5f,  1f, 0.5f},
        /*WAT*/        new float[] { 1f,  2f,  0.5f, 1f,  0.5f,  1f,  1f,   1f,   2f,  1f,   1f,   1f,  2f,   1f, 0.5f},
        /*ELE*/        new float[] { 1f,  1f,   2f, 0.5f, 0.5f,  1f,  1f,   1f,   0f,  2f,   1f,   1f,  1f,   1f, 0.5f},
        /*GRA*/        new float[] { 1f, 0.5f,  2f,  1f,  0.5f,  1f,  1f,  0.5f,  2f, 0.5f,  1f,  0.5f, 2f,   1f, 0.5f},
        /*ICE*/        new float[] { 1f, 0.5f, 0.5f, 1f,   2f,  0.5f, 1f,   1f,   2f,  2f,   1f,   1f,  1f,   1f,  2f},
        /*FIG*/        new float[] { 2f,  1f,   1f,  1f,   1f,   2f,  1f,  0.5f,  1f, 0.5f, 0.5f, 0.5f, 2f,   0f,  1f},
        /*POI*/        new float[] { 1f,  1f,   1f,  1f,   2f,   1f,  1f,  0.5f, 0.5f, 1f,   1f,   1f, 0.5f, 0.5f, 1f},
        /*GRO*/        new float[] { 1f,  2f,   1f,  2f,  0.5f,  1f,  1f,   2f,   1f,  0f,   1f,  0.5f, 2f,   1f,  1f},
        /*FLY*/        new float[] { 1f,  1f,   1f, 0.5f,  2f,   1f,  1f,   2f,   1f,  1f,   1f,   2f, 0.5f,  1f,  1f},
        /*PSY*/        new float[] { 1f,  1f,   1f,  1f,  0.5f,  1f,  2f,   2f,   1f,  1f,  0.5f,  1f,  1f,   1f,  1f},
        /*BUG*/        new float[] { 1f, 0.5f,  1f,  1f,   2f,   1f, 0.5f, 0.5f,  1f, 0.5f,  2f,   1f,  1f,  0.5f, 1f},
        /*ROC*/        new float[] { 1f,  2f,   1f,  1f,   1f,   2f, 0.5f,  1f,  0.5f, 2f,   1f,   2f,  1f,   1f,  1f},
        /*GHO*/        new float[] { 0f,  1f,   1f,  1f,   1f,   1f,  1f,   1f,   1f,  1f,   2f,   1f,  1f,   2f,  1f},
        /*DRA*/        new float[] { 1f,  1f,   1f,  1f,   1f,   1f,  1f,   1f,   1f,  1f,   1f,   1f,  1f,   1f,  2f},

    }; //a 2D array

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if(attackType == PokemonType.None || defenseType == PokemonType.None)
        {
            return 1;
        }

        int row = (int)attackType - 1;
        int column = (int)defenseType - 1;

        return chart[row][column];
    }
}
