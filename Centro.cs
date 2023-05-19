public class Centro : Maquina
{
    public Centro()
    {
        preco = 500;
        pps = 5;
        max = 500;
        pontoAtual = 0;
        nome = "Centro CNC";
        codigo = ConsoleKey.D2;
        time = new DateTime();
        full = false;
    }
}
