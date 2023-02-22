using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipRefsSO : ScriptableObject
{
    public AudioClip[] chopSounds;
    public AudioClip[] deliveryFailSounds;
    public AudioClip[] deliverySuccessSounds;
    public AudioClip[] footstepSounds;
    public AudioClip[] objectDropSounds;
    public AudioClip[] objectPickupSounds;
    public AudioClip[] trashSounds;
    public AudioClip[] warningSounds;
    public AudioClip stoveSizzleSound;
}