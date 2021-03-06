#if !(UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2)
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Sets the ignore listener pause value of the AudioSource. Returns Success.")]
    public class SetIgnoreListenerPause : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The ignore listener pause value of the AudioSource")]
        public SharedBool ignoreListenerPause;

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

            audioSource.ignoreListenerPause = ignoreListenerPause.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            ignoreListenerPause = false;
        }
    }
}
#endif