using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace Components.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform m_transform;
        
        [SerializeField] private Transform m_target;
        [SerializeField] private float speed = 1;

        [SerializeField] private Vector3 m_offset;

        private void Awake()
        {
            m_transform = transform;
        }

        private void LateUpdate()
        {
            var newPosition = new Vector3(m_target.position.x, m_transform.position.y, m_target.position.z) + m_offset;

            m_transform.position = Vector3.Lerp(m_transform.position, newPosition, speed * Time.deltaTime);
        }
    }
}