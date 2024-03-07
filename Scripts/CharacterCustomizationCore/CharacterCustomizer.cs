using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(CharacterCustomization))]
public class CharacterCustomizer : MonoBehaviour
{
    private CharacterCustomization characterCustomization;

    [SerializeField, PropertyRange(0, "BodyTypesCount"), OnValueChanged("ApplyCustomization"), ShowIf("enabledEditor")]
    [Title("$BodyName", null, TitleAlignments.Centered, horizontalLine: false)]
    private int selectedBody = 0;

    [SerializeField, PropertyRange(0, "OutfitsCount"), OnValueChanged("ApplyCustomization"), ShowIf("enabledEditor")]
    [Title("$OutfitName", null, TitleAlignments.Centered, horizontalLine: false)]
    private int selectedOutfit = 0;

    [Space]
    [SerializeField, PropertyRange(0, 100), OnValueChanged("ApplyCustomization"), ShowIf("enabledEditor")]
    private int seed = 0;

    [PropertySpace]
    [InfoBox("For better performance use only with Scene View that has checked ALWAYS REFRESH!")]

    [ShowInInspector]
    public bool HasCaracterCustomization => characterCustomization != null;
    public int SelectedBody { get => selectedBody; set => selectedBody = value; }
    public int SelectedOutfit { get => selectedOutfit; set => selectedOutfit = value; }
    public int Seed { get => seed; set => seed = value; }

    public CharacterCustomization CharacterCustomization
    {
        get 
        {
            if(characterCustomization == null)
            {
                characterCustomization = GetComponent<CharacterCustomization>();
            }

            return characterCustomization; 
        }
        set 
        {
            characterCustomization = value; 
        }
    }

    public int BodyTypesCount => CharacterCustomization.Bodies.Count - 1;
    public int OutfitsCount => CharacterCustomization.Outfits.Count - 1;

    private string BodyName => CharacterCustomization.Bodies[selectedBody].Name;
    private string OutfitName => CharacterCustomization.Outfits[selectedOutfit].Name;

    private bool enabledEditor = true;

    public void ApplyCustomization()
    {
        if (enabledEditor == false)
            return;

        CharacterCustomization.SetupCustomization(selectedBody, selectedOutfit, seed);
    }

    [PropertySpace, Button, HideIf("enabledEditor", false), PropertyOrder(-1)]
    public void EnableEditor()
    {
        enabledEditor = true;
    }

    [PropertySpace, Button, ShowIf("enabledEditor", false), PropertyOrder(-1)]
    public void DisableEditor()
    {
        enabledEditor = false;
    }

    [PropertySpace(10), Button]
    public void DeactivateAllObjects()
    {
        CharacterCustomization.HideAllElements();
        DisableEditor();
    }

    [OnInspectorInit]
    private void GetValues()
    {
        selectedBody = CharacterCustomization.BodyType;
        selectedOutfit = CharacterCustomization.OutfitType;
        seed = CharacterCustomization.Seed;
    }
}
