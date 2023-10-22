using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemData/Clothing", order = 1)]
public class ClothingData : ItemData
{
    public SkinType Type;
    public Sprite Sprite;
}