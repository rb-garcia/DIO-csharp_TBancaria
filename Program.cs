using System;

namespace DIOTBancaria
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Clear();
                        ListarContas();
                        break;
                    case "2":
                        Console.Clear();
                        InserirConta();
                        break;
                    case "3":
                        Console.Clear();
                        Transferir();
                        break;
                    case "4":
                        Console.Clear();
                        Sacar();
                        break;
                    case "5":
                        Console.Clear();
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar o App!!!");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = Convert.ToDouble(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = Convert.ToDouble(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = Convert.ToDouble(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string? entradaNome = Console.ReadLine();
            if (entradaNome == null)
            {
                entradaNome = "Nome Desconhecido";
            }

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = Convert.ToDouble(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ----------------");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair da Aplicação");
            Console.WriteLine();

            string? opcaoUsuario = Convert.ToString(Console.ReadLine());
            if (opcaoUsuario != null)
                return opcaoUsuario.ToUpper();
            else
                return "0";            
        }
    }
}