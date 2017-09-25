using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 电脑控制
/// </summary>
public class ComputerControl : CharacterBase
{
    public CanvasGroup cg_Pass;
    public ComputerAI computerAI;
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



    public override Card DealCard()
    {
        Card card = base.DealCard();
        characterUI.SetRemain(CardCount);
        return card;
    }

    public override void AddCard(Card card, bool selected)
    {
        base.AddCard(card, selected);

        characterUI.SetRemain(CardCount);

    }
    public override void Sort(bool asc)
    {
        base.Sort(asc);

    }
    List<CardUI> tempUI;
    List<Card> tempCard;


    void ComputerPass()
    {
        cg_Pass.alpha = 1;
        StartCoroutine(IEPassAnimation());

    }
    /// <summary>
    /// 渐隐动画
    /// </summary>
    /// <returns></returns>
    IEnumerator IEPassAnimation()
    {
        float times = 1;
        while (times >= 0)
        {
            yield return new WaitForSeconds(0.2f);
            
            times -= 0.2f;
cg_Pass.alpha -= 0.2f;

        }


    }
    /// <summary>
    /// 电脑当前出牌类型
    /// </summary>
    public CardType currType
    {
        get { return computerAI.currType; }
    }
    /// <summary>
    /// 电脑当前要出的牌
    /// </summary>
    public List<Card> SelectCards
    {
        get { return computerAI.selectCards; }

    }


    /// <summary>
    /// 电脑自动出牌
    /// </summary>
    public bool ComputerSemarPlayCard(CardType cardType, int weight, int length, bool isBiggest)
    {


        computerAI.SmartSelectCards(CardList, cardType, weight, length, isBiggest);
        //判断是否成功
        if (SelectCards.Count!=0)
        {
            //删除手牌
            DestroyCards();

            return true;
        }
        else
        {

            ComputerPass();
            return false;
        }

    }

    private void DestroyCards()
    {
        //获取所有的ui
        CardUI[] cardUis = transform.Find("CreatePoint").GetComponentsInChildren<CardUI>();
        for (int i = 0; i < cardUis.Length; i++)
        {
            for (int j = 0; j < SelectCards.Count; j++)
            {
                if (cardUis[i].Card== SelectCards[j])
                {
                    cardUis[i].Destroy();
                    CardList.Remove(SelectCards[j]);


                }


            }


        }

        SortCardUI(CardList);
        characterUI.SetRemain(CardCount);
    }
}
