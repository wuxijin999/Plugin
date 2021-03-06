using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAudioSource
{
    [TaskCategory("Basic/AudioSource")]
    [TaskDescription("Plays an AudioClip, and scales the AudioSource volume by volumeScale. Returns Success.")]
    public class PlayOneShot : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The clip being played")]
        public SharedObject clip;
        [Tooltip("The scale of the volume (0-1)")]
        float volumeScale = 1;

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

            audioSource.PlayOneShot((AudioClip)clip.Value, volumeScale);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            clip = null;
            volumeScale = 1;
        }
    }
}