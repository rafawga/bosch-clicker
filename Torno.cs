public class Torno : Maquina
{
    public Torno()
    {
        preco = 100;
        pps = 1;
        max = 100;
        pontoAtual = 0;
        nome = "Torno CNC";
        codigo = ConsoleKey.D1;
        time = new DateTime();
        full = false;
    }

}