using System.Collections;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    [SerializeField] int playerLayer;
    [SerializeField] int platformLayer;

    private bool isDropping = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isDropping)
        {
            Debug.Log("Dropping...");
            StartCoroutine(DisablePlatformCollision());
        }
    }

    IEnumerator DisablePlatformCollision()
    {
        isDropping = true;

        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);

        yield return new WaitForSeconds(5f);

        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
    
        isDropping = false;
    }
}
