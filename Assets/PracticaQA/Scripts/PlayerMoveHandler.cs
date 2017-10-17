using System;
using UnityEngine;
using Zenject;

//por si lo daño 

namespace zenject.PracticaQA
{
    public class PlayerMoveHandler : ITickable
    {
        readonly Player _player;
        readonly PlayerInputState _inputState;
        public float MoveSpeed = 10 ;
        public float SlowDownSpeed;

        public PlayerMoveHandler(
            PlayerInputState inputState,
            Player player)
        {
            _player = player;
            _inputState = inputState;
        }

        public void Tick()
        {

            if (_inputState.IsMovingLeft)
            {
                _player.AddForce(
                    Vector3.left * MoveSpeed);
            }

            if (_inputState.IsMovingRight)
            {
                _player.AddForce(
                    Vector3.right * MoveSpeed);
            }

            if (_inputState.IsMovingUp)
            {
                _player.AddForce(
                    Vector3.up * MoveSpeed);
            }

            if (_inputState.IsMovingDown)
            {
                _player.AddForce(
                    Vector3.down * MoveSpeed);
            }

            // Always ensure we are on the main plane
            _player.Position = new Vector3(_player.Position.x, _player.Position.y, 0);

        }

    }
}
