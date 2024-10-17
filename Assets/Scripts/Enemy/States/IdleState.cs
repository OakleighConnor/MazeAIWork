using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class IdleState : State
    {
        public float direction;

        // constructor
        public IdleState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
        {
        }

        public override void Enter()
        {

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
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }

}
