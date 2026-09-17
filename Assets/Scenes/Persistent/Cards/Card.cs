using UnityEngine;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Card
{
    public string name;
    public int cost;
    public int yield;
    public int price;
    public int rarity;
    public string description;
    public List<string> tags;
    public List<CardEffect> effects = new();
    public List<Condition> conditions = new();

    public Card(string namearg)
    {
        name = namearg;
    }
}
