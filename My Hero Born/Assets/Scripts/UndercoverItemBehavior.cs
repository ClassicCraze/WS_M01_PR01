using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;

public class UndercoverItem : MonoBehaviour
{
    public float invisibilityDuration = 10f;

    public GameObject player;

    private Renderer playerRenderer;

    private Collider playerCollider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRenderer = player.GetComponent<Renderer>();
        playerCollider = player.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.CompareTag("Player"))
        {
            StartCoroutine(ActivateInvisibility());
            
            Destroy(gameObject);
        }
    }

    private IEnumerator ActivateInvisibility()
    {
        playerRenderer.enabled = false;

        yield return new WaitForSeconds(invisibilityDuration);

        playerRenderer.enabled = true;
    }
}
