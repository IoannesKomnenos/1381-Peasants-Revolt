using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int LevelToLoad;

    public bool isEnableLeftClickChange = false;

    void Update()
    {
        if (isEnableLeftClickChange)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FadeToNextLevel(null);
            }
        }
    }

    public void OnEnable()
    {
        EventCenter.Instance.AddEventListener("ChangeScene", FadeToNextLevel);
    }

    public void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("ChangeScene", FadeToNextLevel);
    }

    public void FadeToNextLevel (object arg0)
    {
        FadeToLevel (SceneManager.GetActiveScene(). buildIndex+1);
    }

    public void FadeToLevel (int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
