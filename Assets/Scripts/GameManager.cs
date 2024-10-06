using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator transition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator loadScene(string scene)
    {
        if (transition != null)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(2f);
        }
        else
        {
            yield return new WaitForSeconds(0f);
        }
        SceneManager.LoadScene(scene);
    }

    public void OpenScene(string levelName)
    {
        //previousScene = SceneManager.GetActiveScene().name;
        StartCoroutine(loadScene(levelName));

    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial_Scene");
    }

    public string getSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
