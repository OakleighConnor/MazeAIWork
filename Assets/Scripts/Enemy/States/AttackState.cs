using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class AttackState : State
    {
        public float chaseTimer;

        public float direction;

        // constructor
        public AttackState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
        {
        }

        public override void Enter()
        {
            chaseTimer = 5;
            enemy.nav.speed = 5f;
            enemy.anim.Play("Male Sprint", 0, 0);
            enemy.aggressive = true;
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (chaseTimer <= 0)
            {
                enemy.CheckForMovement();
            }
            else
            {
                chaseTimer -= Time.deltaTime;
            }

            enemy.nav.destination = enemy.playerPos.position;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

        }
    }
}