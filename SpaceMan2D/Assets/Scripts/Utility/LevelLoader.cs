using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    //public Text levelText;
    //public Text levelShadow;

    private void Awake()
    {
        //gameObject.SetActive(true);
    }
    void Update()
    {
        if(LoadNewScene.isNewScene == true)
        {
            LoadNewScene.isNewScene = false;
            LoadScene();
            Debug.Log("go");
        }
    }

    public void LoadScene() //string sceneName, bool showLevel = false, string musicTheme = null
    {
        //FindObjectOfType<AudioManager>().ChangeMusicTheme(musicTheme, transitionTime);
        //levelText.gameObject.SetActive(showLevel);
        //levelShadow.gameObject.SetActive(showLevel);

        StartCoroutine(SceneTransition(SceneManager.GetActiveScene().buildIndex +1));
    }

    IEnumerator SceneTransition(int sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
