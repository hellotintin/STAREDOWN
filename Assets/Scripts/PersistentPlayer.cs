using UnityEngine;

//  keeps the VR rig alive when loading into the WinScreen scene,
// make player not lose their headset camera and controllers
public class PersistentPlayer : MonoBehaviour
{
    private static PersistentPlayer instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}