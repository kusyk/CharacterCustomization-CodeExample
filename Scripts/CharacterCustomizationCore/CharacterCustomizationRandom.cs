using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

//RANDOM
public partial class CharacterCustomization
{
    [Space]
    [Header("RANDOM ELEMENTS")]
    [SerializeField] private List<RandomSet> randomSets = new List<RandomSet>();

    public List<RandomSet> RandomSets { get => randomSets; }

    private void ShowRandomElements()
    {
        for (int i = 0; i < randomSets.Count; i++)
        {
            randomSets[i].ShowRandomElement();
        }
    }
}
