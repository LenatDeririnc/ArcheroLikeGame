using System;
using UnityEngine;

namespace Components.Characters.Player
{
    public class PlayerPointer : MonoBehaviour
    {
        public CharacterProperties m_properties;
        public static PlayerPointer self;
        public static Action ONPlayerPointerInit; 

        private void Awake()
        {
            self = this;
            
            m_properties = GetComponent<CharacterProperties>();
            CharacterProperties.ONCharacterPropertiesInit += () => m_properties = GetComponent<CharacterProperties>();
            
            ONPlayerPointerInit?.Invoke();
        }
    }
}