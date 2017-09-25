using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Consts
{

    /// <summary>
    /// 游戏数据
    /// </summary>
    public static readonly string DataPath = Application.persistentDataPath + @"\data.xml";


}


    /// <summary>
    /// View事件理解：这里事件用来做两个面板Mediator之间的通信
    /// </summary>
    public enum ViewEvent
    {
        /// <summary>
        /// //改变倍数
        /// </summary>
        CHANGE_MULTIPLE,
        /// <summary>
        ///发牌完成
        /// </summary>
        COMPLETE_DEAL,
    /// <summary>
    ///发3张底牌
    /// </summary>
    DEAL_THREECARD,
    /// <summary>
    /// 请求出牌的事件
    /// </summary>
    REQUST_PLAY,
    /// <summary>
    /// 成功出牌
    /// </summary>
    SUCCESSED_PLAY,
    /// <summary>
    /// 完成出牌
    /// </summary>
    COMPLETE_PLAY,
    /// <summary>
    /// 重新开始
    /// </summary>
    RESTART_GAME,
    /// <summary>
    /// 跟新积分
    /// </summary>
    UPDATE_INTEGRATION,
    /// <summary>
    /// 显示积分在结束面板上
    /// </summary>
    SHOW_INTERGRATION,
}
    /// <summary>
    /// Command事件理解：用来做面板与数据之间的同信，命令需要注册到框架里面
    /// </summary>
    public enum CommandEvent
    {
    /// <summary>
    /// 改变倍数
    /// </summary>
    ChangeMulitiple,

    /// <summary>
    /// 请求发牌
    /// </summary>
    RequestDeal,
    /// <summary>
    /// 发牌
    /// </summary>
    DealCard,
    /// <summary>
    /// 抢地主
    /// </summary>
    GrabLandLord,
    /// <summary>
    /// 出牌
    /// </summary>
    PlayCard,
    /// <summary>
    /// 不出
    /// </summary>
    PassCard,
    /// <summary>
    /// 游戏结束
    /// </summary>
    GameOver,
    /// <summary>
    /// 跟新积分
    /// </summary>
    RequestUpdate,

}

    /// <summary>
    /// 面板类型
    /// </summary>
    public enum PanelType
    {

    StartPanel,
    BackgroundPanel,
    CharacterPanel,
    InteractionPanel,
    GameOverPanel,

}
    /// <summary>
    /// 角色类型    
    /// </summary>
    public enum CharacterType
    {
        Library,//牌
        Player,//玩家
        ComputerRight,
        ComputerLeft,//电脑
        Desk//桌子


    }
    /// <summary>
    /// 花色
    /// </summary>
    public enum Colors
    {
        None,
        Club,//梅花
        Heart,//红桃
        Spade,//黑桃
        Square//方片

    }
    /// <summary>
    /// 全值
    /// </summary>
    public enum Weight
    {
        Three,
        Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, One, Two, SJoker, LJoker





    }
    /// <summary>
    /// 出牌类型
    /// </summary>
    public enum CardType
    {
        None,
        Single,//单
        Double,//对
        Straight,//顺子
        DoubleStraight,//双顺
        TripleStraight,//三顺
        Three,//三不带
        ThreeAndOne,//三带一
        ThreeAndTwo,//三带二
        Boom,//炸弹
        JokerBoom//王炸


    }





    /// <summary>
    /// 身份
    /// </summary>
    public enum Identity
    {
        Farmer,//农明

        LandLord//地主


    }


