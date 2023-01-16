using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] HPBar hpBar;

    public void SetData(Pokemon pokemon)
    {
        //take a pokemon class
        nameText.text = pokemon.PokemonBase.GetName();//get name
        levelText.text = "Lvl " + pokemon.Level;//get lvl
        hpBar.SetHP((float) pokemon.CurrentHp / pokemon.GetMaxHp());//get hp
    }
}
