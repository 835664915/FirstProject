using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{


    /// <summary>
    /// 当前角色类型
    /// </summary>
    public CharacterType characterType;

    private Transform createPoint;
    public Transform CreatePoint
    {

        get
        {
            if (createPoint==null)
            {
                createPoint = transform.Find("CreatePoint");
                

            }
            return createPoint;
        }

    }


    private List<Card> _cardList = new List<Card>();
    public List<Card> CardList
    {
        get { return _cardList; }

    }
   

    /// <summary>
    /// 是否还有手牌
    /// </summary>
    public bool HasCard
    {
        get { return _cardList.Count != 0; }

    }


    /// <summary>
    /// 根据索引获取卡牌信息
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Card this[int index]
    {
        get { return _cardList[index]; }

    }
    /// <summary>
    /// 根据卡牌获取索引
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public int this[Card card]
    {
        get { return _cardList.IndexOf(card); }

    }
 
    /// <summary>
    /// 卡牌的数量
    /// </summary>
    public int CardCount
    {
        get { return _cardList.Count; }

    }
 
    /// <summary>
    /// 添加牌
    /// </summary>
    public virtual void AddCard(Card card, bool selected)
    {

        _cardList.Add(card);
        card.BelongTo = characterType;
        CreateCardUI(card, CardCount - 1, selected);

    }

    /// <summary>
    /// 出牌
    /// </summary>
    public virtual Card DealCard(  )
    {
        Card card = _cardList[CardCount - 1];
        _cardList.Remove(card);
        return card;

    }

    /// <summary>
    /// 创建卡牌预设
    /// </summary>
    /// <param name="card"></param>
    /// <param name="index"></param>
    public  void CreateCardUI(Card card, int index, bool selected)
    {

        GameObject go = PoolManager.Instance.GetObject("Card");
        CardUI cardUI = go.GetComponent<CardUI>();
        cardUI.Card = card;
        cardUI.IsSelectes = selected;
        cardUI.SetPosition(CreatePoint, index);

    }

    #region 排序方法
    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="asc">升序asc 降序desc</param>
    public virtual void Sort(bool asc)
    {

        Toos.Sort(_cardList, asc);
        SortCardUI(_cardList);

    }
    /// <summary>
    /// 排序卡牌的ui
    /// </summary>
    /// <param name="cards">有序序列</param>
    public  void SortCardUI(List<Card> cards)
    {
        CardUI[] cardUIs = CreatePoint.GetComponentsInChildren<CardUI>();


        for (int i = 0; i < cards.Count; i++)
        {
            for (int j = 0; j < cardUIs.Length; j++)
            {
                if (cards[i] == cardUIs[j].Card)
                {

                    cardUIs[j].SetPosition(CreatePoint, i);
                }



            }
        }



    }

    #endregion


}
