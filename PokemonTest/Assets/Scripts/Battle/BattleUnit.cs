using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase pokemonBase;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Pokemon PokemonUnit;

    public void Setup()
    {
        PokemonUnit = new Pokemon(pokemonBase, level);

        if (isPlayerUnit)//encounter, player or enemy.
        {
            GetComponent<Image>().sprite = PokemonUnit.PokemonBase.GetBackSprite();
        }
        else
        {
            GetComponent<Image>().sprite = PokemonUnit.PokemonBase.GetFrontSprite();

        }
    }
}
