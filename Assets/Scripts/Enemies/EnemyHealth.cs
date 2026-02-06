using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public Item dropItem;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Give player the item
        Inventory playerInventory = FindObjectOfType<Inventory>();
        if(playerInventory != null && dropItem != null)
            playerInventory.AddItem(dropItem);

        Destroy(gameObject);
        Debug.Log("Enemy defeated, item dropped: " + (dropItem != null ? dropItem.itemName : "None"));
    }
}
