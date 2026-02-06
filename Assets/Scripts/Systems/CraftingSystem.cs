using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public Inventory playerInventory;

    public bool Craft(CraftingRecipe recipe)
    {
        // Check if player has all required items
        for(int i = 0; i < recipe.requiredItems.Length; i++)
        {
            int count = CountItem(recipe.requiredItems[i]);
            if(count < recipe.requiredAmounts[i])
            {
                Debug.Log("Missing: " + recipe.requiredItems[i].itemName);
                return false; // Cannot craft
            }
        }

        // Remove required items
        for(int i = 0; i < recipe.requiredItems.Length; i++)
        {
            for(int j = 0; j < recipe.requiredAmounts[i]; j++)
                playerInventory.RemoveItem(recipe.requiredItems[i]);
        }

        // Add crafted item
        playerInventory.AddItem(recipe.resultItem);
        Debug.Log("Crafted: " + recipe.resultItem.itemName);
        return true;
    }

    private int CountItem(Item item)
    {
        int count = 0;
        foreach(Item i in playerInventory.items)
        {
            if(i == item)
                count++;
        }
        return count;
    }
}
