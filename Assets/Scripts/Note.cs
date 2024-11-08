using System;
using DG.Tweening;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public void Hit(PlayerController playerController) {
        playerController.CurrentInteractable = this;
    }

    public void Interact(PlayerController playerController)
    {
        float distance = Vector3.Distance(transform.position, playerController.transform.position);
        var sr = GetComponent<SpriteRenderer>();
        sr.DOColor(Color.green, 0.5f);
    }
}