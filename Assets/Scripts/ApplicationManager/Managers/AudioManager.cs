using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public enum SoundType
    {
        BGM, Explode, Shoot, PlayerDestroyed
    }
    
    public class AudioManager : AppManager
    {
        [SerializeField] private AudioSource BackgroundMusic;
        [SerializeField] private AudioSource ExplodeSound;
        [SerializeField] private AudioSource ShootSound;
        [SerializeField] private AudioSource PlayDestroyedSound;

        private Dictionary<SoundType, AudioSource> soundTable;

        public override void Initialized()
        {
            base.Initialized();

            soundTable = new Dictionary<SoundType, AudioSource>()
            {
                { SoundType.BGM              , BackgroundMusic    },
                { SoundType.Explode          , ExplodeSound       },
                { SoundType.Shoot            , ShootSound         },
                { SoundType.PlayerDestroyed  , PlayDestroyedSound },
            };
        }

        public void PlaySound(SoundType _type)
        {
            if (soundTable.TryGetValue(_type, out var _source))
            {
                if(_source.isPlaying)
                    _source.Stop();
                
                _source.Play();
            }
        }

        public void StopSound(SoundType _type)
        {
            if (soundTable.TryGetValue(_type, out var _source))
                _source.Stop();
        }
    }
}
