using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 出牌顺序累
/// </summary>
public class RoundModel
{

    //--------事件------------
    public static event Action<bool> PlayerHandler;

    public static event Action<ComputerSmartArgs> ComputionHandler;
    //--------------------

    /// <summary>
    /// 当前出牌者
    /// </summary>
    private CharacterType _currentCharacter;
    public CharacterType CurrentCharacter
    {


        get { return _currentCharacter; }

        set { _currentCharacter = value; }


    }






 
    /// <summary>
    /// 最大出牌
    /// </summary>
    private CharacterType _biggesterCharacter;
    public CharacterType BiggesterCharacter
    {



        get { return _biggesterCharacter; }

        set { _biggesterCharacter = value; }
    }




    /// <summary>
    /// 当前出牌类型
    /// </summary>
    private CardType _currentType;
    public CardType CardType
    {
        get { return _currentType; }

        set { _currentType = value; }

    }
    /// <summary>
    /// 最大的权值
    /// </summary>
    private int _currentWeight;
    public int CurrentWeight
    {
        get { return _currentWeight; }

        set { _currentWeight = value; }
    }
    /// <summary>
    ///出牌长度，最大的人
    /// </summary>
    private int _currentLength;
    public int CurrentLength
    {
        get { return _currentLength; }

        set { _currentLength = value; }
    }
    /// <summary>
    /// 初始化回合信息
    /// </summary>
    /// <param name="biggesterCharacter"></param>
    /// <param name=""></param>
    public void InitRound()
    {
        this._currentCharacter = CharacterType.Desk;
        this._biggesterCharacter = CharacterType.Desk;
        this._currentType = CardType.None;
        this._currentWeight = 0;
        this._currentLength = 0;



    }

    /// <summary>
    /// 开始游戏
    /// </summary>
    /// <param name="cType">谁是地主谁先出牌</param>
    public void Start(CharacterType cType)
    {

        this._currentCharacter = cType;
        this._biggesterCharacter = cType;
        BeginWith(cType);

    }
  


    /// <summary>
    /// 换着出牌
    /// </summary>
    public void Trun()
    {
        //如果currentCharacter 等于CharacterType.Library或 currentCharacter==CharacterType.Desk我们想让   currentCharacter += 1;
        _currentCharacter++;
        //过
        if (_currentCharacter == CharacterType.Library|| _currentCharacter == CharacterType.Desk)
        {

            _currentCharacter = CharacterType.Player;

        }


        BeginWith(_currentCharacter);



    }


    /// <summary>
    /// 开始回合
    /// </summary>
    /// <param name="cType"></param>
    private  void BeginWith(CharacterType cType)
    {
        if (cType == CharacterType.Player)
        {

            //------委托
            if (PlayerHandler != null)
            {

                PlayerHandler(_biggesterCharacter!=CharacterType.Player);//判断最大出牌着如果是玩家，就必须出



            }


        }
        else
        {
            //------电脑自动出牌----------

            if (ComputionHandler != null)
            {

                ComputerSmartArgs e = new ComputerSmartArgs()
                {
                    biggerst = this.BiggesterCharacter,

                    cardType = this.CardType,
                    characterType = this.CurrentCharacter,
                    lenght = this.CurrentLength,
                    weight = this.CurrentWeight,
             

                };

                ComputionHandler(e);


               // Debug.Log(_currentCharacter.ToString() + "轮到你出牌了");
            }

        }
    }
}
