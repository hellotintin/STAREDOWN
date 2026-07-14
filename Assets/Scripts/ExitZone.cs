using UnityEngine;
using UnityEngine.SceneManagement;

// trigger collider (boxCollider with "is trigger" checked)
// placed at the exit door or endpoint of level
public class ExitZone : MonoBehaviour
{
    [Tooltip("Name of the scene to load when the player escapes (e.g. a WinScreen scene)")]
    public string winSceneName = "WinScreen";

    [Tooltip("Tag the XR Origin root uses. Default XR Origin is untagged, so this defaults to Player - " +
             "make sure to tag your XR Origin as Player in the Inspector")]
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