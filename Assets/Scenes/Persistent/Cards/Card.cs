using UnityEngine;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Card
{
    public int id;
    public string name;
    public int cost;
    public int yield;
    public int price;
    public string description;
    public string tag;
    public List<CardEffect> effects = new();

    public Card(int idarg)
    {
        id = idarg;
    }
}
