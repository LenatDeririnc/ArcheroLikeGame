using System;
using UnityEngine;

namespace Components.Meshes
{
    public class HideMeshOnStart : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}