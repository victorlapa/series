class Tela
{
  ConsoleColor corTexto, corFundo;

  public Tela(ConsoleColor ct = ConsoleColor.White,
                ConsoleColor cf = ConsoleColor.Black)
  {
    this.corFundo = cf;
    this.corTexto = ct;

    this.configurarTela();
  }

  public void configurarTela()
  {
    Console.BackgroundColor = this.corFundo;
    Console.ForegroundColor = this.corTexto;
    Console.Clear();
  }

  public void limparArea()
  {
    Console.Clear();
  }


  public void montarLinhaHor(int lin, int ci, int cf)
  {
    int col;
    // traça a linha
    for (col = ci; col <= cf; col++)
    {
      Console.SetCursorPosition(col, lin);
      Console.Write("-");
    }
    // arruma as pontas
    Console.SetCursorPosition(ci, lin);
    Console.Write("+");
    Console.SetCursorPosition(cf, lin);
    Console.Write("+");
  }


  public void centralizar(int lin, int ci, int cf, string msg)
  {
    int col;
    col = ci + ((cf - ci) / 2);
    Console.SetCursorPosition(col, lin);
    Console.Write(msg);
  }


  public string mostrarMenu(List<string> menu, int ci, int li)
  {
    int cf, lf, x;
    string op;

    // calcula a coluna final e linha final
    cf = ci + menu[0].Length + 1;
    lf = li + menu.Count() + 2;

    // monta a moldura do menu

    // mostra as opções do menu
    for (x = 0; x < menu.Count(); x++)
    {
      Console.WriteLine(menu[x]);
    }
    Console.WriteLine("Opção : ");
    op = Console.ReadLine();
    return op;
  }


  public string perguntar(string perg)
  {
    string resp = "S";
    Console.WriteLine(perg);
    if (resp is not null)
    {
      resp = Console.ReadLine();
      return resp;
    }
    else
    {
      return "Resposta vazia.";
    }
  }

  public int perguntarInt(string perg)
  {
    int resp = -1000;
    Console.WriteLine(perg);
    while (resp < 0 || resp > 10)
    {
      resp = int.Parse(Console.ReadLine());
    }
    return resp;
  }
}