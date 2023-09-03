using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Exit : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        InputSystem.DisableDevice(Keyboard.current);
        m_Animator.SetTrigger("FadeOut");
        yield return new WaitForSecondsRealtime(1f);
        InputSystem.EnableDevice(Keyboard.current);
        m_Animator.SetTrigger("FadeOut");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
