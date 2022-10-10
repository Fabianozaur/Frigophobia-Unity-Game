using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

public class ConstantDamageWhenNotNearTorches : MonoBehaviour
{
    ObjectiveManager m_ObjectiveManager;
    PlayerCharacterController m_PlayerCharacterController;
    Health m_PlayerHealth;

    float damageMultiplyer = 1f;

    void Awake() 
    {
        m_ObjectiveManager = FindObjectOfType<ObjectiveManager>();
        m_PlayerCharacterController = FindObjectOfType<PlayerCharacterController>();
        m_PlayerHealth = m_PlayerCharacterController.GetComponent<Health>();
    }

    void Start()
    {
        InvokeRepeating(nameof(CheckForDamage), 1.0f, 1.0f);
    }

    void CheckForDamage()
    {
        if (m_ObjectiveManager.m_ObjectivesCompleted)
        {
            return;
        }

        var torches = GameObject.FindGameObjectsWithTag("Torch");
        var isNearTorch = false;

        foreach (var torch in torches)
        {
            var distanceFromTorch = Vector3.Distance(m_PlayerCharacterController.transform.position, torch.transform.position);

            if (distanceFromTorch < 5)
            {
                isNearTorch = true;
            }
        }

        if (isNearTorch)
        {
            damageMultiplyer = 1f;
            m_PlayerHealth.Heal(5.0f);
        }
        else
        {
            damageMultiplyer *= 1.5f;
            m_PlayerHealth.TakeDamage(1.0f * damageMultiplyer, torches[0]);
        }
    }
}
