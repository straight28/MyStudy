using System;
using System.Reflection;

namespace CSharpTest5
{
    class Important : Attribute
    {
        string message;
        public Important(string message) { this.message = message; }
    }

    class Monster
    {
        [Important("매우 중요")]
        public int hp;
        protected int attack;
        private float speed;

        void Attack() {}
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Reflection : X-RAY
            // Attribute : 런타임에 체크할 수 잇는 주석
            Monster monster = new Monster();
            Type type = monster.GetType();

            var fields = type.GetFields(System.Reflection.BindingFlags.Public
                                        | System.Reflection.BindingFlags.NonPublic
                                        | System.Reflection.BindingFlags.Static
                                        | System.Reflection.BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                string access = "protected";

                if (field.IsPublic)
                    access = "public";
                else if (field.IsPrivate)
                    access = "private";


                var attiributes = field.GetCustomAttributes();
                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");

            }
        }
    }
}
