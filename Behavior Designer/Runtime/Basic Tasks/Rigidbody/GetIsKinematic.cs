using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Stores the is kinematic value of the Rigidbody. Returns Success.")]
    public class GetIsKinematic : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The is kinematic value of the Rigidbody")]
        [RequiredField]
        public SharedBool storeValue;

        // cache the rigidbody component
        private Rigidbody targetRigidbody;

        public override void OnStart()
        {
            targetRigidbody = GetDefaultGameObject(targetGameObject.Value).GetComponent<Rigidbody>();
        }

        public override TaskStatus OnUpdate()
        {
            if (targetRigidbody == null) {
                Debug.LogWarning("Rigidbody is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = targetRigidbody.isKinematic;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            storeValue = false;
        }
    }
}