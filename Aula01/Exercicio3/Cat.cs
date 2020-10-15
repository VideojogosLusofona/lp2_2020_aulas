using System;

namespace Exercicio3
{
    public class Cat
    {
        // ////////////////////////////////////////////////////////// //
        // Estado do gato, definido pelas suas variáveis de instância //
        // ////////////////////////////////////////////////////////// //

        // Nome
        private readonly string name;

        // Energia, entre 0 e 100
        private int energy;

        // Nível de alimentação
        private Feed feedStatus;

        // Disposição do gato
        private Mood moodStatus;

        // /////////////////////////////////////////// //
        // Ações do gato, definidas pelos seus métodos //
        // /////////////////////////////////////////// //

        // Comer
        public void Eat()
        {
            // Aumentar estado de alimentação do gato apenas se o mesmo não
            // estiver prestes a explodir
            if (feedStatus < Feed.AboutToExplode)
            {
               feedStatus++;
            }
        }

        // Dormir
        public void Sleep()
        {
            // Aumentar a energia do gato ao dormir, garantindo que a mesma não
            // passa dos 100
            energy += 20;
            if (energy > 100) energy = 100;

            // Gato fica com mais fome do que tinha dantes (a não ser que já
            // estivesse esfomeado)
            if (feedStatus > Feed.Starving)
            {
               feedStatus--;
            }

            // A disposição do gato ao acordar é rabugento
            // Seria mais interessante ser aleatória, veremos no próximo
            // exercício
            moodStatus = Mood.Grumpy;
        }

        // Brincar
        public void Play()
        {
            // Gato perde energia ao brincar, mas não pode ficar menor que zero
            energy -= 15;
            if (energy < 0) energy = 0;

            // Gato fica feliz ao brincar
            moodStatus = Mood.Happy;
        }

        // Miar
        public void Meow()
        {
            // Gato mia na consola. E se quiséssemos reutilizar esta classe no
            // Unity, como faríamos?
            Console.WriteLine("Meow!");

            // Gato perde energia ao miar, mas não pode ficar menor que zero
            energy -= 5;
            if (energy < 0) energy = 0;
        }
    }
}
