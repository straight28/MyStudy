using System;
using System.Collections.Generic;

namespace CSharpTest4
{
    internal class Program
    {

        static void OnInputTest()
        {
            Console.WriteLine("Input Received ! ");
        }

        enum ItemType
        {
            Weapon, 
            Armor, 
            Amulet, 
            Ring
        }

        enum Rarity
        {
            Normal,
            Uncommon,
            Rare,
        }

        class Item
        {
            public ItemType ItemType;
            public Rarity Rarity;
        }


        static List<Item> _items = new List<Item>();
        static Item FindItem(Func<Item, bool> selector)
        {
            foreach (Item item in _items)
            {
                if(selector(item))
                    return item; 
            }
            return null;
        }


        static void Main(string[] args)
        {
            InputManager inputManager = new InputManager();
            inputManager.InputKey += OnInputTest;

            while (true)
            {
                inputManager.Update();
            }

            _items.Add(new Item() { ItemType = ItemType.Weapon, Rarity = Rarity.Normal });
            _items.Add(new Item() { ItemType = ItemType.Armor, Rarity = Rarity.Uncommon });
            _items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });

            // delegate 를 직접 선언하지 않아도, 이미 만들어진 것들
            // => 반환 타입이 있을 경우 Func
            // => 반환 타입이 없을 경우 Action

            // Lambda : 일회용 함수를 만드는데 사용하는 문법이다.
            // Anonymous Function : 무명 함수 / 익명 함수
            Item item = FindItem((Item item) => { return item.ItemType == ItemType.Weapon; });
        }
    }
}
