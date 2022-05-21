using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D NPCRigidbody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    private void Start()
    {
        NPCRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = waitTime;

        ChooseDirection();
    }

    private void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;


            switch (WalkDirection)
            {
                case 0:
                    NPCRigidbody.velocity = new Vector2(0, moveSpeed);
                    break;

                case 1:
                    NPCRigidbody.velocity = new Vector2(moveSpeed, 0);
                    break;

                case 2:
                    NPCRigidbody.velocity = new Vector2(0, -moveSpeed);
                    break;
                
                case 3:
                    NPCRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    break;

            }
            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;

            NPCRigidbody.velocity = Vector2.zero; 

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}

