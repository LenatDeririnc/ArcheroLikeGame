using System;
using Components.HUD;
using UnityEngine;

namespace Components
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private int cost;

        private Rigidbody m_rigidbody;
        public Rigidbody Rigidbody => m_rigidbody;
        private HUDController m_hudController;
        private GarbageCollector m_garbageCollector;
        
        private Transform m_transform;
        public Transform Transform => m_transform;
        private GameObject m_gameObject;
        public GameObject GameObject => m_gameObject;

        private void Awake()
        {
            m_transform = transform;
            m_gameObject = gameObject;
            m_rigidbody = GetComponent<Rigidbody>();
            
            m_hudController = HUDController.self;
            HUDController.ONHUDControllerInit += () => m_hudController = HUDController.self;
            
            m_garbageCollector = GarbageCollector.self;
            GarbageCollector.GarbageCollectorInited += () => m_garbageCollector = GarbageCollector.self;
        }

        private void Start()
        {
            m_transform.parent = m_garbageCollector.Transform;
        }

        public void PickUp()
        {
            m_hudController.AddMoney(cost);
            m_gameObject.SetActive(false);
        }
    }
}