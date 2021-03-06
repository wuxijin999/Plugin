using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Returns Success if the Rigidbody is using gravity, otherwise Failure.")]
    public class UseGravity : Conditional
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;

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

            return targetRigidbody.useGravity ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnReset()
        {
            targetGameObject = null;
        }
    }
}