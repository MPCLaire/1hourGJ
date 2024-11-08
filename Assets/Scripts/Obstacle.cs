using UnityEngine;

public class Obstacle : MonoBehaviour, IInteractable
{
    public void Hit(PlayerController player) {
        player.Kill();
    }

    public void Interact(PlayerController playerController)
    {
        throw new System.NotImplementedException();
    }
}