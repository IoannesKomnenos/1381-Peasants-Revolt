using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int LevelToLoad;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToNextLevel();
        }
    }
    public void FadeToNextLevel ()
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
