using UnityEngine;
using UnityEngine.SceneManagement;

// trigger collider (boxCollider with "is trigger" checked)
// placed at the exit door or endpoint of level
public class ExitZone : MonoBehaviour
{
    public string winSceneName = "WinScreen";
    public string playerTag = "Player";
    private bool triggered;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag(playerTag)) return;

        triggered = true;
        SceneManager.LoadScene(winSceneName);
    }
}