using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Image fader;
    private static SceneController instance;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            fader.rectTransform.sizeDelta = new Vector2(Screen.width + 20, Screen.height + 20);
            fader.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public static void LoadScene(int index, float duration = 0.5f, float waitTime = 0)
    {
        instance.StartCoroutine(instance.FadeScene(index, duration, waitTime));
    }

    private IEnumerator FadeScene(int index, float duration, float waitTime)
    {
        fader.gameObject.SetActive(true);

        for(float t = 0; t<1; t +=Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        SceneManager.LoadScene(index);

        yield return new WaitForSeconds(waitTime);

        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, t));
            yield return null;
        }

        fader.gameObject.SetActive(false);
    }

    public static void TransitionPlayer(Vector3 pos)
    {
        instance.StartCoroutine(instance.Transition(pos));
    }

    private IEnumerator Transition(Vector3 pos)
    {
        fader.gameObject.SetActive(true);

        for (float t = 0; t < 1; t += Time.deltaTime / 0.25f)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        player.transform.position = pos;

        yield return new WaitForSeconds(1);

        for (float t = 0; t < 1; t += Time.deltaTime / 0.25f)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, t));
            yield return null;
        }

        fader.gameObject.SetActive(false);
    }
}
