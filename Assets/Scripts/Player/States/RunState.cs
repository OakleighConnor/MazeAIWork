using Enemy;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class RunState : State
    {

        // constructor
        public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.speed = 15f;
            player.groundDrag = 1.5f;
            Debug.Log("Running");
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
            player.CheckForMovement();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            Vector3 moveDirection = player.orientation.forward * player.yInput + player.orientation.right * player.xInput;
            player.rb.AddForce(moveDirection.normalized * player.speed * 100f * Time.deltaTime, ForceMode.Force);

            player.ApplyMovement();

        }
    }
}