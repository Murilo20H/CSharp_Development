using System;

class Program
{
    const int TAMANHO_TABULEIRO = 3;
    static char[,] localEscolhido = new char[TAMANHO_TABULEIRO, TAMANHO_TABULEIRO];
    static bool jogoEncerrado = false;
    static char opcaoJogador = 'X';
    static string linhaDigitada;
    static string colunaDigitada;
    static int linhaEscolhida;
    static int colunaEscolhida;
    static char vencedor = ' ';
    static bool primeiraVez = true;
    static bool digitouErrado = false;
    static int quantidadeJogadas = 0;
    static void Main(string[] args)
    {
        localEscolhido[0, 0] = ' ';
        localEscolhido[0, 1] = ' ';
        localEscolhido[0, 2] = ' ';
        localEscolhido[1, 0] = ' ';
        localEscolhido[1, 1] = ' ';
        localEscolhido[1, 2] = ' ';
        localEscolhido[2, 0] = ' ';
        localEscolhido[2, 1] = ' ';
        localEscolhido[2, 2] = ' ';

        InicializarJogo();
    }

    public static void InicializarJogo()
    {
        MostrarTabuleiro();
        AcaoJogador();
    }

    public static void MostrarTabuleiro()
    {
        Console.Write("\n     A   B   C\n   -------------\n");
        Console.Write($"1  | {localEscolhido[0, 0]} | {localEscolhido[0, 1]} | {localEscolhido[0, 2]} |\n");
        Console.Write("   -------------\n");
        Console.Write($"2  | {localEscolhido[1, 0]} | {localEscolhido[1, 1]} | {localEscolhido[1, 2]} |\n");
        Console.Write("   -------------\n");
        Console.Write($"3  | {localEscolhido[2, 0]} | {localEscolhido[2, 1]} | {localEscolhido[2, 2]} |\n");
        Console.Write("   -------------\n");
    }

    public static void AcaoJogador()
    {
        if (primeiraVez == true)
        {
            Console.Write("Você usará X ou O: ");
            opcaoJogador = char.Parse(Console.ReadLine());
            primeiraVez = false;
            if (opcaoJogador == 'x')
            {
                opcaoJogador = 'X';
            }
            else if (opcaoJogador == 'o')
            {
                opcaoJogador = 'O';
            }
            else if (opcaoJogador != 'X' || opcaoJogador != 'x' || opcaoJogador != 'O' || opcaoJogador != 'o')
            {
                opcaoJogador = 'X';
            }
        }

        Console.Write("Em qual linha você irá jogar (1, 2, 3): ");
        linhaDigitada = Console.ReadLine();

        Console.Write("Em qual coluna você irá jogar (A, B, C): ");
        colunaDigitada = Console.ReadLine();


        if (linhaDigitada == "1")
        {
            linhaEscolhida = 0;
        }
        else if (linhaDigitada == "2")
        {
            linhaEscolhida = 1;
        }
        else if (linhaDigitada == "3")
        {
            linhaEscolhida = 2;
        }
        else
        {
            Console.Write("\nVocê digitou uma linha inexistente, digite novamente:\n");
            digitouErrado = true;
        }


        if (colunaDigitada == "A" || colunaDigitada == "a")
        {
            colunaEscolhida = 0;
        }
        else if (colunaDigitada == "B" || colunaDigitada == "b")
        {
            colunaEscolhida = 1;
        }
        else if (colunaDigitada == "C" || colunaDigitada == "c")
        {
            colunaEscolhida = 2;
        }
        else
        {
            Console.Write("\nVocê digitou uma coluna inexistente, digite novamente:\n");
            digitouErrado = true;
        }


        if (digitouErrado)
        {
            digitouErrado = false;
            VerificarFinalizado();
            MostrarTabuleiro();
            AcaoJogador();
            VerificarFinalizado();
        }

        for (int linha = 0; linha < TAMANHO_TABULEIRO; linha++)
        {
            for (int coluna = 0; coluna < TAMANHO_TABULEIRO; coluna++)
            {
                if (linha == linhaEscolhida && coluna == colunaEscolhida && localEscolhido[linha, coluna] == ' ')
                {
                    localEscolhido[linha, coluna] = opcaoJogador;
                    quantidadeJogadas++;

                    if (opcaoJogador == 'O')
                    {
                        opcaoJogador = 'X';
                    }
                    else if (opcaoJogador == 'X')
                    {
                        opcaoJogador = 'O';
                    }
                }
                else if (linha == linhaEscolhida && coluna == colunaEscolhida && localEscolhido[linha, coluna] != ' ')
                {
                    Console.Write("Local já escolhido, escolha novamente:\n");
                }
            }
        }
        VerificarFinalizado();
    }

    public static void VerificarFinalizado()
    {
        if (localEscolhido[0, 0] != ' ' && localEscolhido[0, 1] != ' ' && localEscolhido[0, 2] != ' ')
        {
            if (localEscolhido[0, 0] == 'X' && localEscolhido[0, 1] == 'X' && localEscolhido[0, 2] == 'X')
            {
                jogoEncerrado = true;
                vencedor = 'X';
            }
            else if (localEscolhido[0, 0] == 'O' && localEscolhido[0, 1] == 'O' && localEscolhido[0, 2] == 'O')
            {
                jogoEncerrado = true;
                vencedor = 'O';
            }
        }

        if (localEscolhido[1, 0] != ' ' && localEscolhido[1, 1] != ' ' && localEscolhido[1, 2] != ' ')
        {
            if (localEscolhido[1, 0] == 'X' && localEscolhido[1, 1] == 'X' && localEscolhido[1, 2] == 'X')
            {
                jogoEncerrado = true;
                vencedor = 'X';
            }
            else if (localEscolhido[1, 0] == 'O' && localEscolhido[1, 1] == 'O' && localEscolhido[1, 2] == 'O')
            {
                jogoEncerrado = true;
                vencedor = 'O';
            }
        }

        if (localEscolhido[2, 0] != ' ' && localEscolhido[2, 1] != ' ' && localEscolhido[2, 2] != ' ')
        {
            if (localEscolhido[2, 0] == 'X' && localEscolhido[2, 1] == 'X' && localEscolhido[2, 2] == 'X')
            {
                jogoEncerrado = true;
                vencedor = 'X';
            }
            else if (localEscolhido[2, 0] == 'O' && localEscolhido[2, 1] == 'O' && localEscolhido[2, 2] == 'O')
            {
                jogoEncerrado = true;
                vencedor = 'O';
            }
        }

        if (localEscolhido[0, 0] != ' ' && localEscolhido[1, 0] != ' ' && localEscolhido[2, 0] != ' ')
        {
            if (localEscolhido[0, 0] == 'X' && localEscolhido[1, 0] == 'X' && localEscolhido[2, 0] == 'X')
            {
                jogoEncerrado = true;
                vencedor = 'X';
            }
            else if (localEscolhido[0, 0] == 'O' && localEscolhido[1, 0] == 'O' && localEscolhido[2, 0] == 'O')
            {
                jogoEncerrado = true;
                vencedor = 'O';
            }
        }

        if (localEscolhido[0, 1] != ' ' && localEscolhido[1, 1] != ' ' && localEscolhido[2, 1] != ' ')
        {
            if (localEscolhido[0, 1] == 'X' && localEscolhido[1, 1] == 'X' && localEscolhido[2, 1] == 'X')
            {
                jogoEncerrado = true;
                vencedor = 'X';
            }
            else if (localEscolhido[0, 0] == 'O' && localEscolhido[0, 1] == 'O' && localEscolhido[2, 1] == 'O')
            {
                jogoEncerrado = true;
                vencedor = 'O';
            }
        }

        if (localEscolhido[0, 2] != ' ' && localEscolhido[1, 2] != ' ' && localEscolhido[2, 2] != ' ')
        {
            if (localEscolhido[0, 2] == 'X' && localEscolhido[1, 2] == 'X' && localEscolhido[2, 2] == 'X')
            {
                jogoEncerrado = true;
                vencedor = 'X';
            }
            else if (localEscolhido[0, 2] == 'O' && localEscolhido[1, 2] == 'O' && localEscolhido[2, 2] == 'O')
            {
                jogoEncerrado = true;
                vencedor = 'O';
            }
        }

        if (localEscolhido[0, 0] != ' ' && localEscolhido[1, 1] != ' ' && localEscolhido[2, 2] != ' ')
        {
            if (localEscolhido[0, 0] == 'X' && localEscolhido[1, 1] == 'X' && localEscolhido[2, 2] == 'X')
            {
                jogoEncerrado = true;
                vencedor = 'X';
            }
            else if (localEscolhido[0, 0] == 'O' && localEscolhido[1, 1] == 'O' && localEscolhido[2, 2] == 'O')
            {
                jogoEncerrado = true;
                vencedor = 'O';
            }
        }

        if (localEscolhido[0, 2] != ' ' && localEscolhido[1, 1] != ' ' && localEscolhido[2, 0] != ' ')
        {
            if (localEscolhido[0, 2] == 'X' && localEscolhido[1, 1] == 'X' && localEscolhido[2, 0] == 'X')
            {
                jogoEncerrado = true;
                vencedor = 'X';
            }
            else if (localEscolhido[0, 2] == 'O' && localEscolhido[1, 1] == 'O' && localEscolhido[2, 0] == 'O')
            {
                jogoEncerrado = true;
                vencedor = 'O';
            }
        }

        if (jogoEncerrado == true)
        {
            Console.Clear();
            MostrarTabuleiro();
            Console.Write("O jogo terminou, o vencedor foi o jogador do " + vencedor + "!");
            Environment.Exit(0);
        }
        else if (quantidadeJogadas == 9)
        {
            Console.Clear();
            MostrarTabuleiro();
            Console.Write("O jogo terminou, deu empate!");
            Environment.Exit(0);
        }
        else
        {
            MostrarTabuleiro();
            AcaoJogador();
        }
    }
}