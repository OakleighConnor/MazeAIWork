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

        // variables holding the different states
        public IdleState idleState;
        public MoveState moveState;
        public StateMachine sm;

        public float direction;

        public EnemyScriptableObject config;

        // Start is called before the first frame update
        void Start()
        {
            sm = gameObject.AddComponent<StateMachine>();
            rb = gameObject.GetComponent<Rigidbody>();

            // add new states here
            moveState = new MoveState(this, sm);
            idleState = new IdleState(this, sm);

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
    }
}

