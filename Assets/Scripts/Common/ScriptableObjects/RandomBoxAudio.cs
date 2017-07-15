using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( fileName = "RandomBoxAudio", menuName = "ScriptableObjects/AudioObject/RandomBox" )]
public class RandomBoxAudio : AudioObject {

    public AudioClip[] clips;
    [MinMaxRange(0, 1)]
    public RangedFloat volume = new RangedFloat(1,1);

    [MinMaxRange(0, 2)]
    public RangedFloat pitch = new RangedFloat(1,1);
    public override void Play(AudioSource source)
    {
        if( clips.Length == 0 ) return;

        source.clip = clips.Random( );
        source.volume = volume.RandomValue;
        source.pitch = pitch.RandomValue;
        source.Play( );
    }

}
