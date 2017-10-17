using System;
using UnityEngine;
using Zenject;

namespace zenject.PracticaQA
{
    public class PlayerShootHandler : ITickable
    {
        readonly Player _player;
        readonly Bullet.Pool _bulletPool;
        readonly PlayerInputState _inputState;


        float _lastFireTime;
        float MaxShootInterval = 0.15f;
        float BulletSpeed = 10;
        float BulletLifetime = 1;
        float BulletOffsetDistance = 0.01f;




        public PlayerShootHandler(
            PlayerInputState inputState,
            Bullet.Pool bulletPool,
            Player player)
        {
            _player = player;
            _bulletPool = bulletPool;
            _inputState = inputState;
        }

        public void Tick()
        {
            if (_player.IsDead)
            {
                return;
            }

            if (_inputState.IsFiring && Time.realtimeSinceStartup - _lastFireTime > MaxShootInterval)
            {
                _lastFireTime = Time.realtimeSinceStartup;
                Fire();
            }
        }

        void Fire()
        {

            var bullet = _bulletPool.Spawn(
                BulletSpeed, BulletLifetime, BulletTypes.FromPlayer);

            bullet.transform.position = _player.Position + _player.LookDir * BulletOffsetDistance;
            bullet.transform.rotation = _player.Rotation;
        }
    }
}
