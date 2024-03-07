using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BODIES
public partial class CharacterCustomization
{
    [Space]
    [Header("BODIES")]
    [SerializeField] private List<BodyPreset> bodies = new List<BodyPreset>();

    public List<BodyPreset> Bodies { get => bodies; }

    private void ShowBody(int bodyIndex, BodyPreset.HandTypes handType)
    {
        bodies[bodyIndex].ShowBody(handType);
    }
}
