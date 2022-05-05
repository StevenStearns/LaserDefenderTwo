using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float fltShootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float fltDamageVolume = 1f;

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, fltShootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, fltDamageVolume);
    }

    void PlayClip(AudioClip clip, float fltVolume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, fltVolume);
        }
    }
}
