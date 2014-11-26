using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RessourceBoard : Object
{
    public Dictionary<Ressource, Stack<int>> RessourceValues;

    public Ressource Metal { get; set; }
    public Ressource Oil { get; set; }
    public Ressource Fields { get; set; }

    private Stack<int> MetalStack;
    private List<int> StackValueList;

    public RessourceBoard() {
        RessourceValues = new Dictionary<Ressource, Stack<int>>();
        StackValueList = CreateStackValueList();
        Metal = new Ressource();
        Metal.Id = 1;
        Metal.Name = "Metal";
        MetalStack = CreateRessourceStack();

        RessourceValues.Add(Metal, MetalStack);


    }

    private List<int> CreateStackValueList()
    {
        List<int> result = new List<int>() { 1, 2, 2, 3, 3, 4, 4, 5};
        return result;
    }

    private Stack<int> CreateRessourceStack()
    {
        Stack<int> result = new Stack<int>();
        for (int i = StackValueList.Count - 1; i > -1; i--) {
            result.Push(StackValueList[i]);
        }
        return result;
    }


    public void RemoveRessource(Ressource ressource)
    {
        RessourceValues[ressource].Pop();
    }

    public int SellRessource(Ressource ressource)
    {
        RestoreMissingRessource(ressource);
        return GetSoldPrice(ressource);
    }

    private int GetSoldPrice(Ressource ressource)
    {
        return RessourceValues[ressource].Peek();
    }

    private void RestoreMissingRessource(Ressource ressource)
    {
        int valueToAdd = GetValueToAdd(ressource);
        RessourceValues[ressource].Push(valueToAdd);
    }

    private int GetValueToAdd(Ressource ressource)
    {
        int valueCount = StackValueList.Count;
        int valueToAddIndex = (valueCount - RessourceValues[ressource].Count) - 1;
        int valueToAdd = StackValueList[valueToAddIndex];
        return valueToAdd;
    }
}
