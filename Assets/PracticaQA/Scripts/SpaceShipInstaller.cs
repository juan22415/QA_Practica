using System;
using UnityEngine;
using Zenject;

namespace zenject.PracticaQA
{


    public class SpaceShipInstaller : MonoInstaller
    {
        [SerializeField]
        Settings _settings = null;

        public override void InstallBindings()
        {
            Container.Bind<Player>().AsSingle()
                .WithArguments(_settings.Rigidbody, _settings.MeshRenderer);

            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerDirectionHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerShootHandler>().AsSingle();
            Container.Bind<PlayerInputState>().AsSingle();


            Container.BindMemoryPool<Bullet, Bullet.Pool>()
               .WithInitialSize(25)
               .FromComponentInNewPrefab(_settings.BulletPrefab)
               .UnderTransformGroup("Bullets");

        }
        [Serializable]
        public class Settings
        {
            public Rigidbody Rigidbody;
            public MeshRenderer MeshRenderer;
            public GameObject BulletPrefab;

        }
    }
}