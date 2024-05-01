using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.SceneManagement;
using UnityEngine; 

// Шаблон для заполнения списка
public class ClassOfItem //: ICatalog 
{
    
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public int Place {  get; set; }
    public int Health { get; set; }
    public double Power { get; set; }
    public int Сurrency {  get; set; }

    // Коафицент умнажения мощьности при добовлнения еще одного item в одно и тоже место
    public double XPover { get; set; }
    //Создаем публичный список к которому будем обращяться из других фаилов
    public static List<ClassOfItem> list = new List<ClassOfItem>();
       


    // Конструктор
    public ClassOfItem(string title, string description, int price, string Image, int place, int Health, double Power, double XPover, int Сurrency)
    {
        this.Title = title;
        this.Description = description;
        this.Price = price;
        this.Image = Image;
        this.Place = place;
        this.Health = Health;
        this.Power = Power;
        this.XPover = XPover;
        this.Сurrency = Сurrency;

    }
    
}

