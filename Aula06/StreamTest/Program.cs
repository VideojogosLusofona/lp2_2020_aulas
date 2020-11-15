using System;
using System.IO;
using System.IO.Compression;

namespace StreamTest
{
    class Program
    {
        // Ficheiro onde guardar dados
        private string ficheiro;

        // Programa começa aqui
        static void Main(string[] args)
        {
            // Criar uma instância de Program para não estarmos sempre a usar
            // métodos de teste static
            Program p = new Program();

            // Executar o programa, embora preparado para tratar alguma
            // excepção que possa ocorrer
            try
            {
                // Executar programa
                p.Executar();
            }
            catch (Exception e)
            {
                // Pelos vistos aconteceu um problema, dizer qual
                Console.WriteLine($"Ocorreu o seguinte erro: {e}");
            }
            finally
            {
                // Dizer obrigado, quer tenha havido uma excepção ou não
                Console.WriteLine("Obrigado por ter utilizado este programa!");
            }
        }

        // Inicializa uma nova instância da classe Program
        private Program()
        {
            // Definir nome ("dados.txt.gz") e localização ("My Documents") do
            // ficheiro onde guardar os dados comprimidos
            ficheiro = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "dados.txt.gz");
        }

        // Este método começa a execução do programa de
        // compressão/descompressão
        private void Executar()
        {
            // String onde colocar resposta do utilizador
            string resposta;

            // Perguntar ao utilizador se quer comprimir ou descomprimir
            Console.Write("(C)omprimir ou (D)escomprimir? ");
            resposta = Console.ReadLine().ToLower();

            // Verificar resposta do utilizador
            switch (resposta)
            {
                // Comprimir
                case "c": Comprime(); break;
                // Descomprimir
                case "d": Descomprime(); break;
                // Resposta desconhecida, lançar excepção
                default:
                    throw new FormatException(
                        $"Resposta inválida '{resposta}', apenas 'c' ou 'd'");
            }
        }

        // Comprimir um texto para dentro de um ficheiro
        private void Comprime()
        {

            // Linhas de texto inseridas pelo utilizador
            string line;

            // Criar um ficheiro em modo escrita
            FileStream fs = new FileStream(
                ficheiro, FileMode.Create, FileAccess.Write);
            // Decorar o ficheiro com um compressor para o formato GZip
            GZipStream gzs = new GZipStream(fs, CompressionLevel.Optimal);
            // Adaptar o compressor para escrita em modo de texto
            StreamWriter sw = new StreamWriter(gzs);

            // Pedir ao utilizador para inserir várias linhas de texto que
            // serão guardadas no ficheiro comprimido
            Console.WriteLine("Insere várias linhas de texto "
                + "(linha vazia termina inserção):");

            while ((line = Console.ReadLine()).Length > 0)
            {
                sw.WriteLine(line);
            }

            // Fechar ficheiro
            sw.Close();
        }

        // Descomprimir texto no ficheiro e mostrar no ecrã
        private void Descomprime()
        {
            throw new NotImplementedException(
                "Descompressão não implementada");
        }
    }
}
