using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
    [TaskCategory("Basic/Rigidbody")]
    [TaskDescription("Sets the mass of the Rigidbody. Returns Success.")]
    public class SetMass : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The mass of the Rigidbody")]
        public SharedFloat mass;

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

            targetRigidbody.mass = mass.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            mass = 0;
        }
    }
}