using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace Enemy
{
    public class EnemyScript : MonoBehaviour
    {

        public Animator anim;
        public NavMeshAgent nav;

        public float speed;

        public Transform[] points;
        public int desPoint;

        // variables holding the different states
        public AiSensor sensor;
        public WalkState walkState;
        public AttackState attackState;
        public StateMachine sm;

        public float direction;
        public bool aggressive;

        public Transform playerPos;

        public EnemyScriptableObject config;

        // Start is called before the first frame update
        void Start()
        {
            sm = gameObject.AddComponent<StateMachine>();
            anim = GetComponent<Animator>();
            nav = GetComponent<NavMeshAgent>();

            sensor = GetComponent<AiSensor>();

            // add new states here
            walkState = new WalkState(this, sm);
            attackState = new AttackState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(walkState);
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

        public void CheckForMovement()
        {
            if (nav.velocity != Vector3.zero)
            {
                sm.ChangeState(walkState);
                return;
            }
        }

        public void CheckForPlayer()
        {
            if(sensor.Objects.Count > 0)
            {
                sm.ChangeState(attackState);
                return;
            }
        }
        public void CheckForIdle()
        {
            if (!nav.pathPending && nav.remainingDistance < 0.5f)
            {
                sm.ChangeState(walkState);
                return;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerScript player = other.GetComponentInParent<PlayerScript>();
                player.alive = false;
                player.sm.ChangeState(player.idleState);
                Debug.Log("Kill");
            }
        }
    }
}

