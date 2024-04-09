using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine; 
//using Services.Interfaces.ICatalog; 
// ������ ��� ���������� ������
public class ClassOfItem //: ICatalog 
{
    
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public int Place {  get; set; }
    public int Health { get; set; }
    public double Power { get; set; }

    // ��������� ��������� ��������� ��� ����������� ��� ������ item � ���� � ���� �����
    public double XPover { get; set; }
    //������� ��������� ������ � �������� ����� ���������� �� ������ ������
    public static List<ClassOfItem> list = new List<ClassOfItem>();
    public static int coins;

    // �����������
    public ClassOfItem(string title, string description, int price, string Image, int place, int Health, double Power, double XPover)
    {
        this.Title = title;
        this.Description = description;
        this.Price = price;
        this.Image = Image;
        this.Place = place;
        this.Health = Health;
        this.Power = Power;
        this.XPover = XPover;

    }
    
}

