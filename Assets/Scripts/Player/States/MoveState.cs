using Enemy;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class MoveState : State
    {
        public float direction;

        // constructor
        public MoveState(PlayerScript player, StateMachine sm) : base(player, sm)
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
            player.CheckForIdle();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Vector3 moveDirection = player.orientation.forward * player.yInput + player.orientation.right * player.xInput;
            player.rb.AddForce(moveDirection.normalized * 1 * 1000f * Time.deltaTime, ForceMode.Force);
        }
    }
}

