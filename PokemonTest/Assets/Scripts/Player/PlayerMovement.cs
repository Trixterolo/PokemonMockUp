using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    [SerializeField] LayerMask solidObjects;
    [SerializeField] LayerMask grassLayer;

    [SerializeField] public float moveSpeed;

    private bool isMoving;
    private Vector2 moveInput;

    [SerializeField] private Vector3 targetPos; //only to observe
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveInputs();
    }

    private void MoveInputs()
    {
        if (!isMoving)
        {
            //if player is not moving, they can use these inputs
            moveInput.x = Input.GetAxisRaw("Horizontal"); //axisraw always be 1 or -1
            moveInput.y = Input.GetAxisRaw("Vertical");

            //remove diagonal movement
            if (moveInput.x != 0) { moveInput.y = 0; }

            //if player is moving
            if (moveInput != Vector2.zero)
            {
                animator.SetFloat("Horizontal", moveInput.x);
                animator.SetFloat("Vertical", moveInput.y);

                targetPos = transform.position;
                targetPos.x += moveInput.x;
                targetPos.y += moveInput.y;

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));

                }

            }
            animator.SetBool("isMoving", isMoving);

        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            yield return null;
        }
        transform.position = targetPos;
        Debug.Log("Player moving");

        isMoving = false;

        CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetPos)//checks whether the targetpos is blocked or not
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjects) != null) //if targetpos is not walkable, return false., 0.3f is around 1 unit.
                                                                            //changed to 0.2f because y position changed to 0.8, and not 0.5.
        {
            return false;
        }
        return true;
    }

    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null)
        {
            if (UnityEngine.Random.Range(1, 101) <= 10)
            {
                Debug.Log("Encounter battle!");
            }
        }
    }

}
