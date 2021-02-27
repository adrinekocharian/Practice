using System;
using System.Collections.Generic;

namespace CastTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Mammal m1 = new Cat();
            Cat cat1 = new Cat();
            Cat c3 = (Cat) m1;
            Cat c4 = (Cat)m1;
            Cat d6 = (Cat)new Mammal();

            Mammal mammal = new Mammal();
            Cat cat = new Cat();
            Mammal m2 = cat;
            Mammal mmm = (Cat)m1;

            if (mammal is Cat)
            {
                Cat c = (Cat)mammal;
            }

            mammal = cat; // up-casting
            Mammal m = (Mammal)new Cat();
            Cat cat2 = (Cat)m; // down-casting

            Dog dog = new Dog();
            Lion lion = new Lion();
            FeedAnimal(cat2);

            //cat.Eat();

            //Fish fish = new Fish();
            //FeedAnimal(fish);

            //Console.WriteLine("Hello World!");
            //int[] array = new int[] { 5, 3, 4, 68, 9, 2, 8 };
            //var lastEl = array[3..5]; // [ ) 

            //List<int> list = new List<int>() { 5, 3, 45, 7};
            //var a = list[^1];
            
            //Console.WriteLine(lastEl);
            Console.ReadLine();
        }

        static void FeedAnimal(Mammal animal)
        {
            var isCat = animal is Cat;
            var cat = animal as Cat;
            var dog = animal as Dog;
            var lion = animal as Lion;
            
            if (cat != null)
            {
                cat.Meow();
            }

            if (dog != null)
            {
                dog.Bark();
            }

            //if (animal is Cat c)
            //{
            //    c.Meow();
            //}

            //if (animal is Dog d)
            //{
            //    d.Bark();
            //}
            animal.Eat();
        }
    }
}

/*
 * Object
 class Base {}                       class Mammal{}
 class Derived : Base{}              class Cat : Mammal{}
 
 
 */
