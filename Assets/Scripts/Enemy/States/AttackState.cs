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
            chaseTimer = 10;
            //enemy.anim.Play("Male Sword Sprint", 0, 0);
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
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            // Move

            if (!enemy.nav.pathPending && enemy.nav.remainingDistance < 0.5f)
            {
                if (enemy.points.Length == 0)
                {
                    return;
                }
                enemy.nav.destination = enemy.points[enemy.desPoint].position;
                enemy.desPoint = (enemy.desPoint + 1) % enemy.points.Length;
            }

        }
    }
}