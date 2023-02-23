using UnityEngine;

namespace Unity_Prefab_Collider_Generator_v1._0
{
    public class ColliderBoundsDebugger : MonoBehaviour
    {
        public Collider myCollider;

        private void OnEnable() => myCollider = GetComponent<Collider>();

        private void OnDrawGizmos()
        {
            if (myCollider == null) return;
            var bounds = myCollider.bounds;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }
}
