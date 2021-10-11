using System;
using TMPro;
using UnityEngine;

namespace Components.HUD
{
    public class HUDController : MonoBehaviour
    {
        public static HUDController self;
        public static Action ONHUDControllerInit;
        
        [SerializeField] private TMP_Text m_text;

        private int m_hp = 0;
        private int m_money = 0;

        private void Awake()
        {
            self = this;
            ONHUDControllerInit?.Invoke();
        }

        private void DrawUpdate()
        {
            m_text.text = $"HP: {m_hp}\nMoney: {m_money}";
        }

        public void SetHp(int value)
        {
            m_hp = value;
            DrawUpdate();
        }

        public void SetMoney(int value)
        {
            m_money = value;
            DrawUpdate();
        }

        public void AddMoney(int value)
        {
            m_money += value;
            DrawUpdate();
        }
    }
}