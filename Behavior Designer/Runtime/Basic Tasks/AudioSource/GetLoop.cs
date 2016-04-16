using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Stores the loop value of the AudioSource. Returns Success.")]
    public class GetLoop : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The loop value of the AudioSource")]
        [RequiredField]
        public SharedBool storeValue;

        private AudioSource audioSource;

        public override void OnStart()
        {
            audioSource = GetDefaultGameObject(targetGameObject.Value).GetComponent<AudioSource>();
        }

        public override TaskStatus OnUpdate()
        {
            if (audioSource == null) {
                Debug.LogWarning("AudioSource is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = audioSource.loop;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            storeValue = false;
        }
    }
}