using System;
using UnityEngine;

public class SetChardCard : MonoBehaviour
{
    private LoadCharCard loadCharCard;
    void OnEnable()
    {
        if(loadCharCard == null)
            loadCharCard = FindAnyObjectByType<LoadCharCard>();

        loadCharCard.OnCharacteristicsChanged += UpdateCharacteristics;
        UpdateCharacteristics();
    }

    void Start()
    {
        loadCharCard = FindAnyObjectByType<LoadCharCard>();
    }

    void OnDisable()
    {
        if(loadCharCard != null)
            loadCharCard.OnCharacteristicsChanged -= UpdateCharacteristics;
    }
    private void UpdateCharacteristics()
    {
        
    }
}
