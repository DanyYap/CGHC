using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string LevelName;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && LevelManager.Instance.hasKey)
        {
            SceneManager.LoadScene(LevelName);
        }
    }
}
