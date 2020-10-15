using System;

namespace Exercicio6
{
    public class Cat
    {
        // //////////////////////////////////////////////////////////////// //
        // Propriedades static do gato, partilhadas por todas as instâncias //
        // //////////////////////////////////////////////////////////////// //

        // Energia máxima
        public static int MaxEnergy { get; set; } = 100;

        // Energia recuperada ao dormir
        public static int EnergyGainAfterSleep { get; set; } = 20;

        // Energia perdida ao brincar
        public static int EnergyLossAfterPlay { get; set; } = 15;

        // Energia perdida ao miar
        public static int EnergyLossAfterMeow { get; set; } = 5;

        // ////////////////////////////// //
        // Variáveis de instância do gato //
        // ////////////////////////////// //

        // Energia, entre 0 e maxEnergy
        private int energy;

        // Nível de alimentação
        private Feed feedStatus;

        // Gerador de números aleatórios
        private Random random;

        // Possíveis valores para a enumeração Feed
        private Feed[] possibleFeedStatus;

        // Possíveis valores para a enumeração Mood
        private Mood[] possibleMoods;

        // //////////////////// //
        // Propriedades do gato //
        // //////////////////// //

        // Nome do gato, propriedade auto-implementada só de leitura
        public string Name { get; }

        // Propriedade pública que representa a energia, de leitura pública e
        // escrita privada. Requer variável de suporte (energy), pois o set
        // garante que a energia fica entre 0 e maxEnergy. Ou seja, esta
        // propriedade não pode ser auto-implementada.
        public int Energy
        {
            get => energy;
            private set
            {
                energy = value;
                if (energy < 0) energy = 0;
                else if (energy > MaxEnergy) energy = MaxEnergy;
            }
        }

        // Nível de alimentação, propriedade auto-implementada de leitura
        // pública e escrita privada
        // Propriedade pública que representa o estado de alimentação, de
        // leitura pública e escrita privada. Requer variável de suporte
        // (feedStatus), pois o set garante que o estado fica entre os valores
        // válidos da sua enumeração. Ou seja, esta propriedade não pode ser
        // auto-implementada.
        public Feed FeedStatus
        {
            get => feedStatus;
            private set
            {
                feedStatus = value;
                if (feedStatus < Feed.Starving)
                    feedStatus = Feed.Starving;
                else if (feedStatus > Feed.AboutToExplode)
                    feedStatus = Feed.AboutToExplode;
            }
        }

        // Disposição do gato, propriedade auto-implementada de leitura
        // pública e escrita privada
        public Mood MoodStatus  { get; private set; }

        // //////////////////// //
        // Construtores do gato //
        // //////////////////// //

        // Construtor privado que inicializa o estado comum aos outros dois
        // construtores públicos, evitando repetição de código
        // Só pode ser chamado pelos outros dois construtores e não diretamente,
        // uma vez que é privado
        private Cat()
        {
            // Instanciar e guardar um gerador de números aleatórios
            random = new Random();

            // Obter possíveis valores da enumeração Feed
            // - Enum é a classe base para todas as enums no C# e contém alguns
            //   métodos úteis, como é o caso do método GetValues()
            // - O método GetValues() devolve um array contendo os valores
            //   possíveis da enum indicado no parâmetro
            // - É preciso fazer cast do array devolvido para o tipo que
            //   queremos, neste caso Feed[]
            possibleFeedStatus = (Feed[])Enum.GetValues(typeof(Feed));

            // Obter possíveis valores para a enumeração Mood usando a mesma
            // lógica
            possibleMoods = (Mood[])Enum.GetValues(typeof(Mood));
        }

        // Construtor que aceita todo o estado do gato através dos seus
        // parâmetros. Chama o construtor privado para este inicializar o
        // estado comum do gato (e.g. gerador de números aleatórios).
        public Cat(string name, int energy, Feed feedStatus, Mood moodStatus)
            : this()
        {
            // Guardar nome do gato na propriedade
            Name = name;

            // Guardar energia na propriedade (esta garante que a energia fica
            // entre 0 e maxEnergy)
            Energy = energy;

            // Guardar valores de nível de alimentação e disposição nas
            // respetivas variáveis de instância
            FeedStatus = feedStatus;
            MoodStatus = moodStatus;
        }

        // Construtor que apenas aceita o nome do gato, definindo aleatoriamente
        // o restante estado. Chama o construtor privado para este inicializar o
        // estado comum do gato (e.g. gerador de números aleatórios).
        public Cat(string name) : this()
        {
            // Guardar o nome do gato na propriedade
            Name = name;

            // Obter valor aleatório para a energia entre 0 e 100 e guardá-lo
            energy = random.Next(MaxEnergy + 1);

            // Obter valor aleatório para o estado de alimentação e guardá-lo
            FeedStatus =
                possibleFeedStatus[random.Next(possibleFeedStatus.Length)];

            // Obter valor aleatório para o Mood e guardá-lo
            MoodStatus =
                possibleMoods[random.Next(possibleMoods.Length)];
        }

        // /////////////////////////////////////////// //
        // Ações do gato, definidas pelos seus métodos //
        // /////////////////////////////////////////// //

        // Comer
        public void Eat()
        {
            // Aumentar o estado de alimentação do gato. Ao usarmos uma
            // propriedade, o set da mesma garante que este valor fica sempre
            // dentro dos valores aceitáveis da enumeração
            FeedStatus++;
        }

        // Dormir
        public void Sleep()
        {
            // Aumentar a energia do gato ao dormir. Uma vez que agora usamos
            // uma propriedade, é garantido que o valor da mesma fica entre 0
            // e maxEnergy
            Energy += EnergyGainAfterSleep;

            // Diminuir o estado de alimentação do gato. Ao usarmos uma
            // propriedade, o set da mesma garante que este valor fica sempre
            // dentro dos valores aceitáveis da enumeração
            FeedStatus--;

            // A disposição do gato ao acordar é aleatória
            MoodStatus = possibleMoods[random.Next(possibleMoods.Length)];
        }

        // Brincar
        public void Play()
        {
            // Gato perde energia ao brincar. Uma vez que agora usamos uma
            // propriedade, é garantido que o valor da mesma fica entre 0
            // e maxEnergy
            Energy -= EnergyLossAfterPlay;

            // Gato fica feliz ao brincar
            MoodStatus = Mood.Happy;
        }

        // Miar
        public void Meow()
        {
            // Gato mia na consola. E se quiséssemos reutilizar esta classe no
            // Unity, como faríamos? Fará sentido meter um WriteLine() numa
            // ação do gato?
            Console.WriteLine($"{Name} says \"Meow\"!");

            // Gato perde energia ao miar. Uma vez que agora usamos uma
            // propriedade, é garantido que o valor da mesma fica entre 0
            // e maxEnergy
            Energy -= EnergyLossAfterMeow;
        }
    }
}
