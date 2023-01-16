using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy} //stores the states in a battle.

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;

    [SerializeField] BattleHUD playerHud;
    [SerializeField] BattleHUD enemyHud;

    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;
    private int currentAction;
    private int currentMove;

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.PokemonUnit);
        enemyHud.SetData(enemyUnit.PokemonUnit);

        dialogBox.SetMoveNames(playerUnit.PokemonUnit.Moves);

        //a wild encounter message with String interpolation
        yield return dialogBox.TypeDialog($"A wild {enemyUnit.PokemonUnit.PokemonBase.GetName()} appeared.");
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    private void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
    }

    private void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);

        dialogBox.EnableMoveSelector(true);
    }

    private void Update()
    {
        if(state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if(state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }



    private void HandleActionSelection()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentAction < 1)
            {
                ++currentAction;
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentAction > 0)
            {
                --currentAction;
            }
        }



        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(currentAction== 0)
            {
                PlayerMove();
            }
            else if (currentAction == 1)
            {
                //Bag
            }
            else if (currentAction == 1)
            {
                //Pokemon
            }
            else if (currentAction == 1)
            {
                //Run
            }
        }
    }

    private void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.PokemonUnit.Moves.Count - 1)
            {
                ++currentMove;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
            {
                --currentMove;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentMove < playerUnit.PokemonUnit.Moves.Count - 2)
            {
                currentMove += 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 1)
            {
                currentMove -= 2;
            }
        }

        dialogBox.UpdateMoveSelection(currentMove, playerUnit.PokemonUnit.Moves[currentMove]);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);

            StartCoroutine(PerformPlayerMove());
        }
    }

    private IEnumerator PerformPlayerMove()
    {
        Move move = playerUnit.PokemonUnit.Moves[currentMove];//collects data of current action move
        yield return dialogBox.TypeDialog
                                ($"{playerUnit.PokemonUnit.PokemonBase.GetName()} used {move.MoveBase.GetName()}");//dialog for the move

        //delay, then deal damage
        yield return new WaitForSeconds(1f);
    }
}
