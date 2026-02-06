using UnityEngine;

public class MiningNode : MonoBehaviour
{
    public int hitsRequired = 3;
    private int currentHits;

    void OnMouseDown()
    {
        currentHits++;

        if (currentHits >= hitsRequired)
        {
            Destroy(gameObject);
            Debug.Log("Ore collected");
        }
    }
}
