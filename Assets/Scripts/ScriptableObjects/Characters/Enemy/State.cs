using Components.Characters.Enemy;
using UnityEngine;

namespace ScriptableObjects.Characters.Enemy
{
    public abstract class State : ScriptableObject
    {
        public EnemyStateMachine EnemyStateMachine;
        public abstract void Init();
        public abstract void Update();
    }
}