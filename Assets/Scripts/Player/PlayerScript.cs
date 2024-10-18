using Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace Player
{
    public class PlayerScript : MonoBehaviour
    {
        public Transform orientation;
        public Rigidbody rb;

        public float xInput;
        public float yInput;

        public float speed;
        public float groundDrag;

        public bool alive;

        // variables holding the different states
        public IdleState idleState;
        public MoveState moveState;
        public RunState runState;
        public StateMachine sm;
        public EnemyScript enemy;

        public float direction;

        public EnemyScriptableObject config;

        // Start is called before the first frame update
        void Start()
        {
            sm = gameObject.AddComponent<StateMachine>();
            rb = gameObject.GetComponent<Rigidbody>();
            enemy = FindAnyObjectByType<EnemyScript>();

            // add new states here
            moveState = new MoveState(this, sm);
            idleState = new IdleState(this, sm);
            runState = new RunState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }

        public void CheckForIdle()
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");

            if (xInput == 0 && yInput == 0)
            {
                sm.ChangeState(idleState);
            }
        }

        public void CheckForMovement()
        {
            if (enemy.aggressive && sm.CurrentState == runState) return;
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");

            if(xInput > 0 || xInput < 0)
            {
                sm.ChangeState(moveState);
                return;
            }

            if (yInput > 0 || yInput < 0)
            {
                sm.ChangeState(moveState);
                return;
            }
        }

        public void CheckForRun()
        {
            if (enemy.aggressive)
            {
                Debug.Log("Enemy angry");
                sm.ChangeState(runState);
                return;
            }
        }

        public void ApplyMovement()
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");

            // Make the player slide less
            rb.drag = groundDrag;

            //limiting speed on ground or in air
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //limit velocity if needed to stop the player moving faster than intended
            if (flatVel.magnitude > speed)
            {
                Vector3 limitedVel = flatVel.normalized * speed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }

            // Applys the player's movement
            Vector3 moveDirection = orientation.forward * yInput + orientation.right * xInput;
            rb.AddForce(moveDirection.normalized * speed * 100f * Time.deltaTime, ForceMode.Force);
        }
    }
}

