Game jogo = new Game();
Maquina[] maquinasLoja = new Maquina[5];
maquinasLoja[0] = new Torno();
maquinasLoja[1] = new Centro();
maquinasLoja[2] = new Furadeira();
Maquina[] minhasMaquinas = new Maquina[100];
int ponteiroMinhasMaquinas = 0;

void Coletar(ref Maquina[] minhasMaquinas, ref Game jogo)
{
    int somaPontos = 0;
    if (ponteiroMinhasMaquinas == 0)
    {
        System.Console.WriteLine("Você ainda não possui máquinas, procure a loja do seu zé!");
    }

    else
    {
        Console.Clear();
        System.Console.WriteLine("Coletando...");
        

        for (int i = 0; i < ponteiroMinhasMaquinas; i++)
        {
            Thread.Sleep(400);
            TimeSpan diferenca = DateTime.Now - (minhasMaquinas[i].time);
            int segundosInt = Convert.ToInt32(diferenca.TotalSeconds) * minhasMaquinas[i].pps;
            if (segundosInt >= minhasMaquinas[i].max){
                segundosInt = minhasMaquinas[i].max;
            }

            System.Console.WriteLine($"Máquina {minhasMaquinas[i].nome} coletou {segundosInt} ");
            somaPontos += minhasMaquinas[i].pontoAtual;
            minhasMaquinas[i].pontoAtual = 0;
            minhasMaquinas[i].time = DateTime.Now;
            minhasMaquinas[i].full = false;
        }

        jogo.pontos += somaPontos;
        Thread.Sleep(1500);
        Console.Clear();
        jogo.verifyLevel(ponteiroMinhasMaquinas);
        PrintGame(jogo, minhasMaquinas);
        return;

    }
}

void attPoints(ref Maquina[] minhasMaquinas, ref Game jogo)
{
    for (int i = 0; i < ponteiroMinhasMaquinas; i++)
    {
        TimeSpan diferenca = DateTime.Now - (minhasMaquinas[i].time);
        int segundosInt = Convert.ToInt32(diferenca.TotalSeconds) * minhasMaquinas[i].pps;
        if (segundosInt >= minhasMaquinas[i].max){
            minhasMaquinas[i].pontoAtual = minhasMaquinas[i].max;
            minhasMaquinas[i].full = true;}
        else{
            minhasMaquinas[i].pontoAtual = segundosInt;
        }
    }
}

void PrintGame(Game jogo, Maquina[] minhasMaquinas)
{
    System.Console.WriteLine($"Click Level: [{jogo.level}]");
    System.Console.WriteLine("Bicos Produzidos: " + jogo.pontos + "$");
    System.Console.WriteLine();
    System.Console.WriteLine("Seu inventário: ");
    if (ponteiroMinhasMaquinas == 0)
    {
        System.Console.WriteLine("Você ainda não possui máquinas, procure a loja do seu zé!");
    }
    else
    {
        for (int i = 0; i < ponteiroMinhasMaquinas; i++)
        {
            if (minhasMaquinas[i].full == false)
             System.Console.WriteLine($"{minhasMaquinas[i].nome}: {minhasMaquinas[i].pontoAtual}$ ");
            else
             System.Console.WriteLine($"{minhasMaquinas[i].nome}: {minhasMaquinas[i].pontoAtual}$ (FULL) Pressione [C] para coletar");

        }

    }
    System.Console.WriteLine();
    System.Console.WriteLine("[L] loja  [C] coletar");







}

Console.WriteLine("=-=-=- Bem Vindo ao Bosch Clicker -=-=-=");
System.Console.WriteLine("Instruções iniciais: ");
System.Console.WriteLine("Pressione [space] para farmar 1 bico");
System.Console.WriteLine("Pressione [L] para abrir a loja de máquinas");
System.Console.WriteLine("Pressione [C] para coletar bicos da máquina");

while (true)
{
    ConsoleKeyInfo key = Console.ReadKey(true);
    attPoints(ref minhasMaquinas, ref jogo);
    int pontos = -1;

    if (pontos != jogo.pontos)
        Console.Clear();
        jogo.verifyLevel(ponteiroMinhasMaquinas);
        PrintGame(jogo, minhasMaquinas);
        

    int pontosMaquina = 0;

    if (ponteiroMinhasMaquinas > 0 && minhasMaquinas[0].pontoAtual != pontosMaquina){
        Console.Clear();
        jogo.verifyLevel(ponteiroMinhasMaquinas);
        PrintGame(jogo, minhasMaquinas);
        pontosMaquina = minhasMaquinas[0].pontoAtual;
    } 
   

    if (key.Key == ConsoleKey.Spacebar)
        jogo.click();

    else if (key.Key == ConsoleKey.C)
        Coletar(ref minhasMaquinas, ref jogo);

    else if (key.Key == ConsoleKey.L)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=-=-=- Loja do Seu zé -=-=-=");
            System.Console.WriteLine($"Seu money: {jogo.pontos}");
            for (int i = 0; i < maquinasLoja.Length; i++)
            {
                if (maquinasLoja[i] is null)
                    break;

                System.Console.WriteLine();
                System.Console.WriteLine($"Máquina: {maquinasLoja[i].nome}");
                System.Console.WriteLine($"Preço: {maquinasLoja[i].preco}");
                System.Console.WriteLine($"Pontos Por Segundo: {maquinasLoja[i].pps}");
                System.Console.WriteLine($"Capacidade Máxima: {maquinasLoja[i].max}");
                System.Console.WriteLine($"Botão de Compra: [{i + 1}]");

            }
             System.Console.WriteLine();
             System.Console.WriteLine("Pressione [L] para sair da Loja");

            ConsoleKeyInfo Key = Console.ReadKey(true);
            if (Key.Key == ConsoleKey.L)
            {
                Console.Clear();
                jogo.verifyLevel(ponteiroMinhasMaquinas);
                PrintGame(jogo, minhasMaquinas);
                break;
            }

            for (int i = 0; i < maquinasLoja.Length; i++)
            {
                if (Key.Key == maquinasLoja[i].codigo)
                {
                    if (jogo.pontos >= maquinasLoja[i].preco)
                    {

                        switch (maquinasLoja[i].codigo)
                        {
                            case ConsoleKey.D1:
                                minhasMaquinas[ponteiroMinhasMaquinas] = new Torno();
                                break;
                            case ConsoleKey.D2:
                                minhasMaquinas[ponteiroMinhasMaquinas] = new Centro();
                                break;
                            case ConsoleKey.D3:
                                minhasMaquinas[ponteiroMinhasMaquinas] = new Furadeira();
                                break;
                            default:
                                break;
                        }

                        minhasMaquinas[ponteiroMinhasMaquinas].time = DateTime.Now;
                        ponteiroMinhasMaquinas++;
                        jogo.pontos = jogo.pontos - maquinasLoja[i].preco;
                        System.Console.WriteLine();
                        Console.Clear();
                        System.Console.WriteLine("**************************************************************");
                        System.Console.WriteLine($"Compra do {maquinasLoja[i].nome} realizada com sucesso.");
                        System.Console.WriteLine("**************************************************************");
                        Thread.Sleep(1000);
                        Console.Clear();
                        jogo.verifyLevel(ponteiroMinhasMaquinas);
                        PrintGame(jogo, minhasMaquinas);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("**************************************************************");
                        System.Console.WriteLine("Você não possui Bico Ejetores o Suficiente, volte mais tarde");
                        System.Console.WriteLine("**************************************************************"); Thread.Sleep(2000);
                        Console.Clear();
                        jogo.verifyLevel(ponteiroMinhasMaquinas);
                        PrintGame(jogo, minhasMaquinas);
                        break;
                    }
                }

            }

        }
    }
}

