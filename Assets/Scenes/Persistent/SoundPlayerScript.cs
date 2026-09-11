using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance;

    public AudioSource soundSource;
    public AudioSource musicSource;

    void Awake()
    {
        Instance = this;

        soundSource.playOnAwake = false;

        musicSource.playOnAwake = false;
        musicSource.loop = true;
    }

    public void PlaySound(string name, bool overlap = true)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);

        if (clip == null)
        {
            Debug.LogError("Sound not found: " + name);
            return;
        }

        if (!overlap)
            soundSource.Stop();

        soundSource.PlayOneShot(clip, SettingsData.AudioVolume);
    }

    public void PlaySong(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);

        if (clip == null)
        {
            Debug.LogError("Song not found: " + name);
            return;
        }

        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.volume = SettingsData.MusicVolume;
        musicSource.Play();
    }

    public void StopSong()
    {
        musicSource.Stop();
    }
}