using System.Collections.Generic;
using UnityEngine;

//portrait_slug
//model_slug
//icon_slug
public class CharInfo
{
    public string slug { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}

public class CharList
{
    public List<CharInfo> charList { get; set; }
}

namespace DataModels
{
    public enum DisplayScreen
    {
        None = 0,
        Menu = 1,
        Dojo = 2,
        Select = 3
    }
}
