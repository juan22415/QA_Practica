using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace zenject.PracticaQA
{
    public interface IPlayer
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }

    public class Spaceship : MonoBehaviour, IPlayer
    {
        Player _model;

        [Inject]
        public void Construct(Player player)
        {
            _model = player;
           
        }
        public Vector3 Position
        {
            get { return _model.Position; }
        }

        public Quaternion Rotation
        {
            get { return _model.Rotation; }
        }

    }
}
