using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] HPBar hpBar;

    Pokemon rootPokemon;

    public void SetData(Pokemon pokemon)
    {
        rootPokemon = pokemon;

        //take a pokemon class
        nameText.text = pokemon.PokemonBase.GetName();//get name
        levelText.text = "Lvl " + pokemon.Level;//get lvl
        hpBar.SetHP((float) pokemon.CurrentHp / pokemon.GetMaxHp());//get hp
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)rootPokemon.CurrentHp / rootPokemon.GetMaxHp());//update hp by calling the funciton SetHPSmooth

    }
}
