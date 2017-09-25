using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家比父类多什么，一个是积分，一个是身份
/// </summary>
public class PlayerControl : CharacterBase
{
    public CharacterUI characterUI;
    private Identity identity;
    public Identity Identity
    {
        get { return identity; }
        set
        {
            identity = value;
            characterUI.SetIdentity(value);

        }
    }


    /// <summary>
    /// 出牌
    /// </summary>
    /// <param name="card"></param>
    public override Card DealCard()
    {
        Card card = base.DealCard();
            characterUI.SetRemain(CardCount);
        return card;
    }
    /// <summary>
    /// 添加卡牌
    /// </summary>
    /// <param name="card"></param>
    public override void AddCard(Card card,bool selected)
    {
        base.AddCard(card,selected);
      
        characterUI.SetRemain(CardCount);

    }
    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="asc"></param>
    public override void Sort(bool asc)
    {
        base.Sort(asc);
       
    }
    List<CardUI> tempUI;
    List<Card> tempCard;
    /// <summary>
    /// 寻找手牌
    /// </summary>
    /// <returns></returns>
    public List<Card> FindSelectCard()
    {
        CardUI[] cardUIs = characterUI.CreatePoint.GetComponentsInChildren<CardUI>();
        tempUI = new List<CardUI>();
        tempCard = new List<Card>();


        for (int i = 0; i < cardUIs.Length; i++)
        {

            if (cardUIs[i].IsSelectes)
            {
                tempUI.Add(cardUIs[i]);
                tempCard.Add(cardUIs[i].Card);


            }


        }

        Toos.Sort(tempCard, true);
        return tempCard;


    }

    /// <summary>
    /// 删除手牌
    /// </summary>
    public void DeleteSelectCardUI()
    {

        if (tempUI == null || tempCard == null)//没有选中的牌
        {

            return;

        }
        else
        {
            //有选中的牌
            for (int i = 0; i < tempCard.Count; i++)
            {
                tempUI[i].Destroy();
                CardList.Remove(tempCard[i]);


            }



        }
        this.SortCardUI(CardList);
        characterUI.SetRemain(CardCount);
    }



}
