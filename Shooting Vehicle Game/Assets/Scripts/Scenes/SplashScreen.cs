using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameStudios;
    [SerializeField] private GameObject gameImage;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioSource sound2;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(3);
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3f);
        sound.Play();
        gameStudios.SetActive(true);
        gameImage.SetActive(false);

        yield return new WaitForSeconds(3f);
        gameImage.SetActive(true);
        gameStudios.SetActive(false);
        sound2.Play();

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(1);
    }
}
