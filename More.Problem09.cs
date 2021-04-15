using System;
using System.Collections.Generic;

namespace KGL.DEVCS.MORE.PROBLEM09
{
    class Program
    {
        static void Main()
        {
            Circle temp1 = new(-1f, "Red");
            Circle temp2 = new(10f, "Green");
            Circle temp3 = new(11.1111f, "Blue");

            Square temp4 = new(1.1f, 1.1f, "Cyan");
            Square temp5 = new(0f, 100000.1f, "Magenta");
            Square temp6 = new(3f, 4f, "Yellow");

            Triangle temp7 = new(3f, 4f, 5, "Silver");
            Triangle temp8 = new(30f, 40f, 50f, "Gold");
            Triangle temp9 = new(123.123f, 222.222f, 333.333f, "Platinum");

            BaseEntityForm temp10 = new();

            List<BaseEntityForm> myCollection = new();

            myCollection.Add(temp1);
            myCollection.Add(temp2);
            myCollection.Add(temp3);
            myCollection.Add(temp4);
            myCollection.Add(temp5);
            myCollection.Add(temp6);
            myCollection.Add(temp7);
            myCollection.Add(temp8);
            myCollection.Add(temp9);

            myCollection.Add(temp10); // в семье не без...

            foreach (BaseEntityForm item in myCollection)
            {
                Console.WriteLine(
                    "NAME: {0}\tAREA: {1:F4}\tCOLOR: {2}\tToString()=>{3}",
                    item.Form(),
                    item.Area(),
                    item.Color(),
                    item.ToString()
                    );
            }

            Console.WriteLine("COUNT ENTITIES: {0}", BaseEntityForm.Count());
        }
    }

    /* ВНИМАНИЕ! БЕЗ ЛОГИКИ ПРОВЕРКИ В КОНСТРУКТОРЕ. ПООЩРЯЕТСЯ ИСПОЛЬЗОВАТЬ В ПРОДАКШЕНЕ (NO) */
    class BaseEntityForm
    {
        private static int counter;

        public enum EntityForm
        {
            Undefine = 0,
            Circle,
            Square,
            Triangle
        }

        readonly string color;
        readonly EntityForm form;

        protected float area;

        public string Color() { return color; }
        public float Area() { return area; }
        public EntityForm Form() { return form; }
        public BaseEntityForm() { counter += 1; }
        public BaseEntityForm(EntityForm form, string color) : this()
        {
            this.form = form;
            this.color = color;
        }
        public static int Count() { return counter; }
        public override string ToString()
        {
            switch (form)
            {
                case EntityForm.Undefine:
                    return "Неопределенная";
                case EntityForm.Circle:
                    return "Круг";
                case EntityForm.Square:
                    return "Прямоугольник";
                case EntityForm.Triangle:
                    return "Треугольник";
                default:
                    return base.ToString();
            }
        }
    }

    class Circle : BaseEntityForm
    {
        readonly float radius;

        public float Radius() { return radius; }
        public Circle(float radius, string color) : base(EntityForm.Circle, color)
        {
            this.radius = radius;
            area = (float)(Math.PI * radius * radius); // catch overflow
        }
    }

    class Square : BaseEntityForm
    {
        readonly float width, height;

        public float Width() { return width; }
        public float Height() { return height; }
        public Square(float width, float height, string color) : base(EntityForm.Square, color)
        {
            this.width = width;
            this.height = height;
            area = (float)(width * height); // catch overflow
        }
    }

    class Triangle : BaseEntityForm
    {
        readonly float a, b, c;
        public float SideA() { return a; }
        public float SideB() { return b; }
        public float SideC() { return c; }
        public Triangle(float sideA, float sideB, float sideC, string color) : base(EntityForm.Triangle, color)
        {
            // допустим что выполняется правило: сумма двух любых сторон треугольника больше чем третья.
            a = sideA; b = sideB; c = sideC;
            area = (float)(0.125f * (sideB + sideC - sideA) * (sideA + sideC - sideB) * (sideA + sideB - sideC)); //catch overflow
        }
    }
}

