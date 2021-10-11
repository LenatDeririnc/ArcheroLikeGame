using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components
{
    public class MoneyDrop : MonoBehaviour
    {
        [SerializeField] private GameObject m_moneyPrefab;
        [SerializeField] private int dropCount;
        [SerializeField] private float forceDrop;
        private Transform m_transform;

        private void Awake()
        {
            m_transform = transform;
        }

        private void Start()
        {
            for (int i = 0; i < dropCount; ++i)
            {
                var randX = Random.value - 0.5f;
                var randY = Random.value - 0.5f;
                
                Vector3 randomDirection = new Vector3(randX, 0, randY).normalized;
                var newMoney = Instantiate(m_moneyPrefab);

                Money newMoneyClass = newMoney.GetComponent<Money>();
                newMoneyClass.Transform.position = m_transform.position;
                newMoneyClass.Rigidbody.AddForce(randomDirection * forceDrop, ForceMode.VelocityChange);
            }
        }
    }
}