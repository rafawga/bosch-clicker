public class Game
{
    public int pontos { get; set; }
    public int level  { get; set; } = 1;

    public void click() 
        => pontos = pontos + (level);

  
    public void verifyLevel(int ponteiroMinhasMaquinas){
        level = ponteiroMinhasMaquinas + 1;

    }

    public void printInstruçoes()
    {
        System.Console.WriteLine("Pressione [space] para farmar 1 bico");
        System.Console.WriteLine("Pressione [P] para abrir a loja de máquinas");
        System.Console.WriteLine("Pressione [I] para ver seu inventário de máquinas");
        System.Console.WriteLine("Pressione [C] para coletar bicos da máquina");
    }
}