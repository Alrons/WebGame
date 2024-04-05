using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassOfItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public int Place {  get; set; }

    public ClassOfItem(string title, string description, int price, string Image, int place)
    {
        this.Title = title;
        this.Description = description;
        this.Price = price;
        this.Image = Image;
        Place = place;
    }

}

