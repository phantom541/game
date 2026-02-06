using UnityEngine;

public class MiningNode : MonoBehaviour
{
    public int hitsRequired = 3;
    private int currentHits;

    public Item dropItem; // Assign in inspector

    void OnMouseDown()
    {
        currentHits++;

        if(currentHits >= hitsRequired)
        {
            // Add item to player's inventory
            Inventory playerInventory = FindObjectOfType<Inventory>();
            if(playerInventory != null && dropItem != null)
                playerInventory.AddItem(dropItem);

            Destroy(gameObject);
            Debug.Log("Ore collected: " + dropItem.itemName);
        }
    }
}
