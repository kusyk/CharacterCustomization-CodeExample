using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class RandomSet
{
    [SerializeField] private string name;
    [SerializeField] private bool showRandom = true;

    [SerializeField] private List<GameObject> objects = new List<GameObject>();

    public string Name { get => name; set => name = value; }
    public bool ShowRandom { get => showRandom; set => showRandom = value; }
    public List<GameObject> Objects { get => objects; set => objects = value; }

    public void ShowRandomElement()
    {
        if (showRandom == false)
            return;

        int randomIndex = Random.Range(0, Objects.Count);
        Objects[randomIndex].SetActiveOptimized(true);
    }
}