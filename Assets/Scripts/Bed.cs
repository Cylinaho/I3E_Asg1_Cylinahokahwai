using UnityEngine;

public class Bed : MonoBehaviour
{
// How much HP the player loses when they interact with this bed
    public int hpDamage = 10;
    public void InteractWithBed(Player player)
    {
        player.currentHP -= hpDamage;
        print($"Ouch! You interacted with a bed and lost {hpDamage} HP. Current HP: {player.currentHP}");
    }
}

