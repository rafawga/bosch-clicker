public class Furadeira : Maquina
{
    public Furadeira()
    {
        preco = 1000;
        pps = 10;
        max = 1000;
        pontoAtual = 0;
        nome = "Furadeira";
        codigo = ConsoleKey.D3;
        time = new DateTime();
        full = false;
    }

}