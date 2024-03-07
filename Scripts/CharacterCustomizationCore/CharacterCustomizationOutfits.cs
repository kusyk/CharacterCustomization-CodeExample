using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//OUTFITS
public partial class CharacterCustomization
{
    [Space]
    [Header("OUTFITS")]
    [SerializeField] private List<OutfitPreset> outfits = new List<OutfitPreset>();

    public List<OutfitPreset> Outfits { get => outfits; }
    public OutfitPreset SelectedOutfit => outfits[outfitType];

    private void ShowOutfit(int outfitIndex)
    {
        outfits[outfitIndex].ShowOutfit();
    }
}
