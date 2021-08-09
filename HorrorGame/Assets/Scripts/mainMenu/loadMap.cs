using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMap : MonoBehaviour
{
    [Header("Loading settings")]
    public int sceneToLoad;
    [Tooltip("optional Animation"),Space]
    public Animator animator;
    public Animator animatorAudio;
    [Tooltip("tempo da attendere prima di poter AVVIARE il livello")]
    public float timeToWait;

    private float act_time=0;
    private bool startTime = false;
    void Update()
    {
        if (transform.GetComponent<buttonHandler>().clicked)
        {
            if (animator != null)
            {
                animator.enabled = true;
                animator.Play("startLoading");
                
                if(animatorAudio!=null) animatorAudio.Play("playAudio");
            }

            startTime = true;


            if (startTime)
                act_time += Time.deltaTime;

            if (act_time >= timeToWait)
            {
                StartCoroutine(LoadAsyncronously(sceneToLoad));
                SceneManager.UnloadSceneAsync(0);
            }
        }
    }

    IEnumerator LoadAsyncronously(int levelIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelIndex);

        while (!op.isDone)
        {
            Debug.Log(op.progress);

            yield return null;
        }


    }
}
