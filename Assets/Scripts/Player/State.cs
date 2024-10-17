using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class State
    {
        protected PlayerScript player;
        protected StateMachine sm;

        // base constructor
        protected State(PlayerScript player, StateMachine sm)
        {
            this.player = player;
            this.sm = sm;
        }

        // These methods are common to all states
        public virtual void Enter()
        {
            //Debug.Log("This is base.enter");
        }

        public virtual void HandleInput()
        {

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }
    }

}
