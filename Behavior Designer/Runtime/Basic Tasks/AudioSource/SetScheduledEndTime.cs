#if !(UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2)
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Changes the time at which a sound that has already been scheduled to play will end. Notice that depending on the " +
                     "timing not all rescheduling requests can be fulfilled. Returns Success.")]
    public class SetScheduledEndTime : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("Time in seconds")]
        float time = 0;

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

            audioSource.SetScheduledEndTime(time);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            time = 0;
        }
    }
}
#endif