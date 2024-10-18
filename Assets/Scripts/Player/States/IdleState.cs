using Enemy;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Player
{
    public class IdleState : State
    {
        public float direction;

        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
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
            if (player.alive)
            {
                player.CheckForMovement();
                player.CheckForRun();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();


        }
    }
}

