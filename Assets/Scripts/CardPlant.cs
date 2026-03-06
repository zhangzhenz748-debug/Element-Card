// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CardPlant : MonoBehaviour//卡牌工厂:只创建基础卡牌
// {
//     public static (ICardEffect, AbstractGameAction) Plant(string Cardname)
//     {
//         AbstractGameAction action;
//         switch (Cardname)
//         {
//             //绿牌
//             case "绿牌1":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌2":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌3":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌4":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌5":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌6":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌7":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌8":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌9":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌10":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌11":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌12":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "绿牌13":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌1":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌2":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌3":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌4":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌5":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌6":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌7":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌8":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌9":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌10":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌11":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌12":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "红牌13":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌1":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌2":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌3":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌4":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌5":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌6":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌7":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌8":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌9":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌10":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌11":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌12":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "黑牌13":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌1":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌2":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌3":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌4":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌5":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌6":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌7":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌8":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌9":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌10":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌11":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌12":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//             case "紫牌13":
//                 action = new AbstractGameAction();
//                 action.harm = 10;
//                 action.name = Cardname;
//                 action.image = CardManager.Cardmanager.Cardimage(Cardname);
//                 return (new BasicsAttack(), action);
//         }
//         return (null, null);
//     }
// }
