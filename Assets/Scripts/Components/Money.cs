using System;
using System.Collections;
using Components.Characters.Player;
using Components.HUD;
using UnityEngine;
using Tools.Timer;

namespace Components
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private int cost;
        [SerializeField] private float collectSpeed = 1f;

        private Rigidbody m_rigidbody;
        public Rigidbody Rigidbody => m_rigidbody;
        private HUDController m_hudController;
        private GarbageCollector m_garbageCollector;
        
        private Transform m_transform;
        public Transform Transform => m_transform;
        private GameObject m_gameObject;
        public GameObject GameObject => m_gameObject;

        private Timer m_timer;

        private PlayerPointer m_playerPointer;
        private bool m_isGoingToPlayer = false;

        private void Awake()
        {
            m_transform = transform;
            m_gameObject = gameObject;
            m_rigidbody = GetComponent<Rigidbody>();
            
            m_hudController = HUDController.self;
            HUDController.ONHUDControllerInit += () => m_hudController = HUDController.self;
            
            m_garbageCollector = GarbageCollector.self;
            GarbageCollector.GarbageCollectorInited += () => m_garbageCollector = GarbageCollector.self;
            
            m_playerPointer = PlayerPointer.self;
            PlayerPointer.ONPlayerPointerInit += () => m_playerPointer = PlayerPointer.self; 
        }

        private void Start()
        {
            m_transform.parent = m_garbageCollector.Transform;
            m_timer = new Timer(this);
            m_timer.Start(DelayForMove());
        }

        public void PickUp()
        {
            m_hudController.AddMoney(cost);
            m_gameObject.SetActive(false);
        }

        IEnumerator DelayForMove()
        {
            yield return new WaitForSeconds(1f);
            m_rigidbody.isKinematic = true;
            m_isGoingToPlayer = true;
        }

        private void Update()
        {
            if (!m_isGoingToPlayer)
                return;

            var PlayerTransform = m_playerPointer.m_properties.Transform;
            var direction = (PlayerTransform.position - m_transform.position).normalized;

            m_transform.position += direction * collectSpeed * Time.deltaTime;
        }
    }
}