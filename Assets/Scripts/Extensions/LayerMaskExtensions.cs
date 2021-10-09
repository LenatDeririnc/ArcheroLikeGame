using UnityEngine;

namespace Extensions
{
    public static class LayerMaskExtensions
    {
        public static bool IsInLayerMask(this LayerMask layerMask, LayerMask otherLayer)
        {
            return ((layerMask.value & (1 << otherLayer)) > 0);
        }
    }
}