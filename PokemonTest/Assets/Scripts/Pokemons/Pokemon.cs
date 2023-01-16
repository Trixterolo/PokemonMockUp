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

    public bool TakeDamage(Move move, Pokemon attacker)
    {

    }
}
