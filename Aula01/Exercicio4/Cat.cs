using System;

namespace Exercicio4
{
    public class Cat
    {
        // ////////////////// //
        // Constantes do gato //
        // ////////////////// //

        // Energia máxima
        private const int maxEnergy = 100;

        // Energia recuperada ao dormir
        private const int energyGainAfterSleep = 20;

        // Energia perdida ao brincar
        private const int energyLossAfterPlay = 15;

        // Energia perdida ao miar
        private const int energyLossAfterMeow = 5;

        // ////////////////////////////////////////////////////////// //
        // Estado do gato, definido pelas suas variáveis de instância //
        // ////////////////////////////////////////////////////////// //

        // Nome
        private string name;

        // Energia, entre 0 e maxEnergy
        private int energy;

        // Nível de alimentação
        private Feed feedStatus;

        // Disposição do gato
        private Mood moodStatus;

        // //////////////////// //
        // Construtores do gato //
        // //////////////////// //

        // Construtor que aceita todo o estado do gato através dos seus
        // parâmetros
        public Cat(string name, int energy, Feed feedStatus, Mood moodStatus)
        {
            // Guardar nome do gato
            this.name = name;

            // Guardar energia na variável de instância, garantindo que fica
            // entre 0 e maxEnergy
            this.energy = energy;
            if (this.energy < 0) this.energy = 0;
            else if (this.energy > maxEnergy) energy = maxEnergy;

            // Guardar valores de nível de alimentação e disposição nas
            // respetivas variáveis de instância
            this.feedStatus = feedStatus;
            this.moodStatus = moodStatus;
        }

        // Construtor que apenas aceita o nome do gato, definindo aleatoriamente
        // o restante estado
        public Cat(string name)
        {
            // Declarar e instanciar um gerador de números aleatórios
            Random random = new Random();

            // Obter possíveis valores da enumeração Feed
            // - Enum é a classe base para todas as enums no C# e contém alguns
            //   métodos úteis, como é o caso do método GetValues()
            // - O método GetValues() devolve um array contendo os valores
            //   possíveis da enum indicado no parâmetro
            // - É preciso fazer cast do array devolvido para o tipo que
            //   queremos, neste caso Feed[]
            Feed[] possibleFeedStatus = (Feed[])Enum.GetValues(typeof(Feed));

            // Obter possíveis valores para a enumeração Mood usando a mesma
            // lógica
            Mood[] possibleMoodStatus = (Mood[])Enum.GetValues(typeof(Mood));

            // Guardar o nome do gato
            this.name = name;

            // Obter valor aleatório para o estado de alimentação e guardá-lo
            feedStatus =
                possibleFeedStatus[random.Next(possibleFeedStatus.Length)];

            // Obter valor aleatório para o Mood e guardá-lo
            moodStatus =
                possibleMoodStatus[random.Next(possibleMoodStatus.Length)];

            // Obter valor aleatório para a energia entre 0 e 100 e guardá-lo
            energy = random.Next(maxEnergy + 1);
        }

        // /////////////////////////////////////////////////////////////// //
        // Getters do gato, métodos só para obter o estado interno do gato //
        // /////////////////////////////////////////////////////////////// //

        // Devolve o nome do gato
        public string GetName() => name;

        // Devolve energia do gato
        public int GetEnergy() =>  energy;

        // Devolve nível de alimentação do gato
        public Feed GetFeed() => feedStatus;

        // Devolve disposição do gato
        public Mood GetMood() => moodStatus;

        // /////////////////////////////////////////////////////////////////////// //
        // Ações do gato, definidas pelos seus métodos (além de getters e setters) //
        // /////////////////////////////////////////////////////////////////////// //

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
            energy += energyGainAfterSleep;
            if (energy > maxEnergy) energy = maxEnergy;

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
            energy -= energyLossAfterPlay;
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
            energy -= energyLossAfterMeow;
            if (energy < 0) energy = 0;
        }

    }
}
