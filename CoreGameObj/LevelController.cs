using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Win")]
    [SerializeField] GameObject levelWinCanvas;
    [SerializeField] AudioClip winSFX;

    [Header("Lost")]
    [SerializeField] GameObject levelLostCanvas;
    [SerializeField] AudioClip lostSFX;

    [Header("Other")]
    [SerializeField] [Range(0, 2)] float sfxVolume = 1f;
    [SerializeField] float waitToLoad = 4f;

    int attackerCount = 0;
    bool timerFinished = false;

    private void Start()
    {
        levelWinCanvas.SetActive(false);
        levelLostCanvas.SetActive(false);
    }

    public void SetTimerFinished()
    {
        timerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    public void AttackerSpawned()
    {
        attackerCount++;
    }

    public void AttackerKilled()
    {
        attackerCount--;

        if(attackerCount <= 0 && timerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        levelWinCanvas.SetActive(true);
        AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position, sfxVolume);

        yield return new WaitForSeconds(waitToLoad);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLostCondition()
    {
        levelLostCanvas.SetActive(true);
        AudioSource.PlayClipAtPoint(lostSFX, Camera.main.transform.position, sfxVolume);

        Time.timeScale = 0f;
    }
}
