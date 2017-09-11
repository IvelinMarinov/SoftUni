﻿using System;

public    class Tiger : Felime
    {
        public Tiger(string animalName, string animalType, double animalWeight, string livingRegion) 
        : base(animalName, animalType, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(Food food)
        {
        if (food.GetType().Name == "Meat")
        {
            this.FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.AnimalType}s are not eating that type of food!");
        }
    }
    }