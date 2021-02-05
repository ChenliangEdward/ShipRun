using UnityEngine;
using Turrets;

namespace TurretDemo
{
   public class TurretTester : MonoBehaviour
   {
        public TurretRotation[] turret;
        public Vector3 targetPos;
        public Transform targetTransform;
        private float distance;
        [Space]
        public bool turretsIdle = false;
        private ShipProperty shipproperty;
        private void Start()
        {
            shipproperty = GetComponentInParent<ShipProperty>();
            //distance = ship.shipShootingRange;
        }
        private void Update()
        {
            // When a transform is assigned, pass that to the turret. If not,
            // just pass in whatever this is looking at.
            targetPos = transform.TransformPoint(Vector3.forward * shipproperty.shipShootingRange);
            foreach (TurretRotation tur in turret)
            {
                //if (targetTransform == null)
               tur.SetAimpoint(targetPos);
                //else
               //tur.SetAimpoint(targetTransform.position);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(targetPos, 1.0f);
        }

   }
}
