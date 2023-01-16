using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pokemon
{
    //This is where all the pokemon Moves are STORED.
    public PokemonBase PokemonBase { get; set; }
    public int Level { get; set; }

    public int CurrentHp { get; set; } //set is in private by DEFAULT

    public List<Move> Moves { get; set; } //gets and stores Move infos from the Move script

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        PokemonBase = pBase;
        Level = pLevel;
        CurrentHp = GetMaxHp();

        //pokemanBase.GetName();

        //When a pokemon is created, we generate moves based on its level with this loop.
        Moves = new List<Move>(); //Generates all moves based on level
        foreach(LearnableMoves move in PokemonBase.GetLearnableMoves())
        {
            if(move.GetLevel() <= Level)
            {
                Moves.Add(new Move(move.GetMoveBase()));//adds move when reaching certain level
            }

            if (Moves.Count >= 4)
            {
                break;//go out of this loop.
            }
        }
    }

    //Actual stat calculations from the game.
    public int GetMaxHp()
    {
        return Mathf.FloorToInt((PokemonBase.GetMaxHp() * Level) / 100f) + 10;
    }
    public int GetAttack()
    {
        return Mathf.FloorToInt((PokemonBase.GetAttack() * Level) / 100f) + 5;
    }
    public int GetDefense()
    {
        return Mathf.FloorToInt((PokemonBase.GetDefense() * Level) / 100f) + 5;
    }
    public int GetSpAttack()
    {
        return Mathf.FloorToInt((PokemonBase.GetSpAttack() * Level) / 100f) + 5;
    }
    public int GetSpDefense()
    {
        return Mathf.FloorToInt((PokemonBase.GetSpDefense() * Level) / 100f) + 5;
    }
    public int GetSpeed()
    {
        return Mathf.FloorToInt((PokemonBase.GetSpeed() * Level) / 100f) + 5;
    }

    public bool TakeDamage(Move move, Pokemon attacker)//bool for pokemon whether it died or not
    {
        float critical = 1f;//normal dmg
        //critical hits
        if(Random.value * 100f <= 6.25f) //random value gives 0 to 1f, multiply with 100f wil give us a float between 0 to 100.
                                         //6.25% is the chance of getting a critical hit.
        {
            critical = 2f;//critical gives double dmg.
        } 

        //checks type of attack move targeting the pokemon getting dmg on BOTH types.
        float type = TypeChart.GetEffectiveness(move.MoveBase.GetType(),this.PokemonBase.GetType1())
                   * TypeChart.GetEffectiveness(move.MoveBase.GetType(), this.PokemonBase.GetType2());

        //random variable for variety in dmg calculation along with move EFFECTIVENES and Critical chance.
        float modifiers = Random.Range(0.85f, 1f) * type * critical;
        float attackLevel = (2 * attacker.Level + 10) / 250f;//checks lvl

        //check power and attack of attacker and defense of defender
        float damageValue = attackLevel * move.MoveBase.GetPower() * ((float)attacker.GetAttack() / GetDefense() + 2);
        int damage = Mathf.FloorToInt(damageValue * modifiers);//final dmg value rounded to int

        CurrentHp -= damage;
        if(CurrentHp <= 0)
        {
            CurrentHp = 0;
            return true; //it died
        }
        return false;//it survived
    }

    public Move GetRandomMove() //calls upon a Random Move
    {
        int random = Random.Range(0, Moves.Count);
        return Moves[random];
    }
}
