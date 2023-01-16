using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] Color highlightedColor;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<TextMeshProUGUI> actionTexts;
    [SerializeField] List<TextMeshProUGUI> moveTexts;

    [SerializeField] TextMeshProUGUI ppText;
    [SerializeField] TextMeshProUGUI typeText;

    public void SetDialog(string dialog)
    {
        dialogText.text = dialog; 
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach(Char letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond); //1 sec can show 30 letters.
        }
    }

    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled; //text got enable property
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled); //GameObject got SetActive property.
    }

    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled); //GameObject got SetActive property.
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for(int i=0; i<actionTexts.Count; ++i)
        {
            if (i == selectedAction)
            {
                actionTexts[i].color = highlightedColor;
            }
            else
            {
                actionTexts[i].color = Color.black;
            } 
                
        }

    }

    public void UpdateMoveSelection(int selectedMove, Move move)
    {
        for (int i = 0; i < moveTexts.Count; ++i)
        {
            if (i == selectedMove)
            {
                moveTexts[i].color = highlightedColor;
            }
            else
            {
                moveTexts[i].color = Color.black;
            }
        }

        ppText.text = $"PP {move.PP}/{move.MoveBase.GetPP()}";
        typeText.text = move.MoveBase.GetType().ToString();
    }

    public void SetMoveNames(List<Move> moves)
    {
        for(int i=0; i<moveTexts.Count; ++i) //check moves in the Pokemon
        {
            if (i < moves.Count)
            {
                moveTexts[i].text = moves[i].MoveBase.GetName();
            }
            else
            {
                moveTexts[i].text = "-";
            }
        }
    }
}
