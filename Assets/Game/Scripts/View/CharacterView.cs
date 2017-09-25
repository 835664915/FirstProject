using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理人物出牌的
/// </summary>
public class CharacterView : View
{
    public PlayerControl player;
    public ComputerControl ComputerLeft;
    public ComputerControl ComputerRight;
    public DeskControl Desk;

    /// <summary>
    /// 初始化id
    /// </summary>
    public void Init()
    {

        player.Identity = Identity.Farmer;
        ComputerLeft.Identity = Identity.Farmer;
        ComputerRight.Identity = Identity.Farmer;


    }



    public void AddCard(CharacterType cType,Card card,bool selected )
    {
        switch (cType)
        {
          
            case CharacterType.Player:
                player.AddCard(card, selected);
                break;
            case CharacterType.ComputerRight:
                ComputerRight.AddCard(card, selected);
                break;
            case CharacterType.ComputerLeft:
                ComputerLeft.AddCard(card, selected);
                break;
            case CharacterType.Desk:
                Desk.AddCard(card, selected);
                break;
            default:
                break;
        }


    }

    public void AddThreeCard(CharacterType cType)
    {
        Card cards = null;
        switch (cType)
        {
        
            case CharacterType.Player:
                for (int i = 0; i <3; i++)
                {
               cards=     Desk.DealCard();
                
                    player.AddCard(cards, true);
                }
                player.Identity = Identity.LandLord;
                player.Sort(false);

                break;
            case CharacterType.ComputerRight:

                for (int i = 0; i < 3; i++)
                {
                    cards = Desk.DealCard();
                    ComputerRight.AddCard(cards, false);

                }
                ComputerRight.Identity = Identity.LandLord;
                ComputerRight.Sort(true);
                break;
            case CharacterType.ComputerLeft:
                for (int i = 0; i < 3; i++)
                {
                    cards = Desk.DealCard();
                    ComputerLeft.AddCard(cards, false);

                }
                ComputerLeft.Identity = Identity.LandLord;
                ComputerLeft.Sort(true);
                break;
        
            default:
                break;
        }

        Desk.Clear();


    }

}
