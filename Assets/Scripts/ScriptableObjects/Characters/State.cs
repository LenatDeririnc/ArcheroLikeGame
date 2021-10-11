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

        public abstract string StateName();
        
        public static bool IsStatesEqual(State state1, State state2)
        {
            if (state1 == null || state2 == null)
            {
                return (state1 != null || state2 == null) && (state1 == null || state2 != null);
            }

            return state1.StateName() == state2.StateName();
        }
    }
}