using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 卡牌
/// </summary>
public class Card 
{
    private string cardName;
    private Colors cardColor;
    private Weight cardWeight;//卡牌全值
    private CharacterType belongTo;//卡牌属于谁的

    /// <summary>
    /// 卡牌名字
    /// </summary>
    public string CardName
    {

        get { return cardName; }

    }
    /// <summary>
    /// 卡牌花色
    /// </summary>
    public Colors CardColor
    {

        get { return cardColor; }

    }
    /// <summary>
    /// 卡牌权值
    /// </summary>
    public Weight CardWeight
    {

        get { return cardWeight; }

    }
    /// <summary>
    /// 卡牌属于谁的
    /// </summary>
    public CharacterType BelongTo
    {

        get { return belongTo; }
        set { belongTo = value; }
    }

    public Card(string name,Colors color,Weight weight,CharacterType belongTo)
    {

        this.cardName = name;
        cardColor = color;
        cardWeight = weight;
        this. belongTo = belongTo;

    }





}
