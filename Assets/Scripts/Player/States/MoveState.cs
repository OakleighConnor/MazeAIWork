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

        // constructor
        public MoveState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.speed = 3.5f;
            player.groundDrag = 3f;
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
            player.CheckForRun();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.ApplyMovement();

            Vector3 moveDirection = player.orientation.forward * player.yInput + player.orientation.right * player.xInput;
            player.rb.AddForce(moveDirection.normalized * player.speed * 100f * Time.deltaTime, ForceMode.Force);
        }
    }
}

