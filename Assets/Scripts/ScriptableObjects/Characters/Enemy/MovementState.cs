using Components.Characters.Enemy;
using UnityEngine;

namespace ScriptableObjects.Characters.Enemy
{
    public abstract class MovementState : ScriptableObject
    {
        [HideInInspector] public EnemyMovementStateMachine enemyMovementStateMachine;
        public abstract void Init();
        public abstract void Update();
    }
}