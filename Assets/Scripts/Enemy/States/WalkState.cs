using Enemy;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Enemy
{
    public class WalkState : State
    {
        public float direction;

        // constructor
        public WalkState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
        {
        }

        public override void Enter()
        {
            enemy.anim.Play("Male_Sword_Walk", 0, 0);
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
            enemy.CheckForIdle();
            enemy.CheckForPlayer();
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

