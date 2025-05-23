using UnityEngine;
using System.Collections;

public class MusicChanger : MonoBehaviour
{
    [Header("Music Settings")]
    [SerializeField] private AudioClip newMusicClip;
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private bool loopNewMusic = true;

    [Header("Trigger Settings")]
    [SerializeField] private string triggerTag = "Player";
    [SerializeField] private bool checkClipEquality = true;

    private AudioSource playerAudioSource; // Теперь ссылаемся на AudioSource игрока
    private float originalVolume;
    private bool isFading = false;

    private void Awake()
    {
        // Добавляем отладочное сообщение
        Debug.Log("MusicChanger initialized");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(triggerTag)) return;

        // Получаем AudioSource от игрока
        playerAudioSource = other.GetComponent<AudioSource>();

        if (playerAudioSource == null)
        {
            Debug.LogError("No AudioSource found on player!");
            return;
        }

        if (isFading) return;
        if (newMusicClip == null)
        {
            Debug.LogWarning("New music clip is not assigned!");
            return;
        }

        if (checkClipEquality && playerAudioSource.clip == newMusicClip && playerAudioSource.isPlaying)
        {
            Debug.Log("Same music clip is already playing, skipping...");
            return;
        }

        StartCoroutine(ChangeMusicCoroutine());
    }

    private IEnumerator ChangeMusicCoroutine()
    {
        isFading = true;

        // Сохраняем оригинальную громкость
        originalVolume = playerAudioSource.volume;

        // Фаза затухания
        if (playerAudioSource.isPlaying)
        {
            float fadeOutTime = 0;
            float startVolume = playerAudioSource.volume;

            while (fadeOutTime < fadeDuration)
            {
                fadeOutTime += Time.deltaTime;
                playerAudioSource.volume = Mathf.Lerp(startVolume, 0, fadeOutTime / fadeDuration);
                yield return null;
            }
        }

        // Смена клипа
        playerAudioSource.clip = newMusicClip;
        playerAudioSource.loop = loopNewMusic;
        playerAudioSource.Play();

        // Фаза увеличения громкости
        float fadeInTime = 0;
        while (fadeInTime < fadeDuration)
        {
            fadeInTime += Time.deltaTime;
            playerAudioSource.volume = Mathf.Lerp(0, originalVolume, fadeInTime / fadeDuration);
            yield return null;
        }

        playerAudioSource.volume = originalVolume;
        isFading = false;
    }

    private void OnDrawGizmos()
    {
        Collider collider = GetComponent<Collider>();
        if (collider == null || !collider.enabled) return;

        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.matrix = transform.localToWorldMatrix;

        if (collider is BoxCollider box)
        {
            Gizmos.DrawCube(box.center, box.size);
        }
        else if (collider is SphereCollider sphere)
        {
            Gizmos.DrawSphere(sphere.center, sphere.radius);
        }
    }
}
