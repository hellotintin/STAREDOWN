using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class EnemyController : MonoBehaviour
{
    [Header("References")]
    public Transform playerCamera;

    [Header("Gaze Detection")]
    public float sightRange = 50f;
    public LayerMask sightMask;

    [Header("Audio")]
    public float minAudioDistance = 1.5f;
    public float maxAudioDistance = 25f;
    public float minVolume = 0.05f;
    public float maxVolume = 1f;
    public float minPitch = 0.9f;
    public float maxPitch = 1.15f;

    private NavMeshAgent agent;
    private AudioSource audioSource;
    private bool isFrozen;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.spatialBlend = 1f;  
        if (!audioSource.isPlaying) audioSource.Play();
    }

    void Update()
    {
        // cast a ray 
        // if hits enemy then enemy freeze. If not then enemy chase.
        isFrozen = Physics.Raycast(playerCamera.position, transform.position - playerCamera.position,
                                    out RaycastHit hit, sightRange, sightMask)
                   && hit.transform == transform;

        agent.isStopped = isFrozen;
        if (!isFrozen)
        {
            agent.SetDestination(playerCamera.position);
        }

        UpdateAudio();
    }

    void UpdateAudio()
    {
        float distance = Vector3.Distance(transform.position, playerCamera.position);
        float t = 1f - Mathf.InverseLerp(minAudioDistance, maxAudioDistance, distance);
        audioSource.volume = Mathf.Lerp(minVolume, maxVolume, t);
        audioSource.pitch = Mathf.Lerp(minPitch, maxPitch, t);
    }

    //  draw the sight ray in the Scene view to debug 
    void OnDrawGizmosSelected()
    {
        if (playerCamera == null) return;
        Gizmos.color = isFrozen ? Color.red : Color.yellow;
        Gizmos.DrawLine(playerCamera.position, transform.position);
    }
}