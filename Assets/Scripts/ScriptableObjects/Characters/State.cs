using Components.Characters;
using UnityEngine;

namespace ScriptableObjects.Characters
{
    public abstract class State : ScriptableObject
    {
        [HideInInspector] public CharacterBehaviour characterBehaviour;

        public virtual void Init(CharacterBehaviour context)
        {
            characterBehaviour = context;
        }
        
        public abstract void Update();
    }
}