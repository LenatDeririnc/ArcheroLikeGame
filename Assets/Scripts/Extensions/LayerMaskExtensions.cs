using UnityEngine;

namespace Extensions
{
    public static class LayerMaskExtensions
    {
        public static bool IsInLayerMask(int layerMask, int otherLayer)
        {
            return (layerMask & (1 << otherLayer)) > 0;
        }
        
        public static bool IsInLayerMask(this LayerMask layerMask, LayerMask otherLayer)
        {
            return IsInLayerMask(layerMask.value, otherLayer.value);
        }
    }
}