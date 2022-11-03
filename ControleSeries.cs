class ControleSeries
{
  Tela tela;
  List<Serie> bancoDados = new List<Serie>();
  int posicao;
  int idSerie;
  int notaSerie;
  string? nomeSerie;

  public ControleSeries(Tela t)
  {
    this.tela = t;
    // cria uma primeira conta só pra ter alguma coisa 
    // no banco
    bancoDados.Add(new Serie("The 100", "Aventura", 10));
  }

  public void mostrarDadosSerie()
  {
    Console.WriteLine(
        "Id: " + this.bancoDados[this.posicao].id);
    Console.WriteLine(
        "Nome: " + this.bancoDados[this.posicao].nome);
    Console.WriteLine(
        "Genero: " + this.bancoDados[this.posicao].genero);
    Console.WriteLine(
        "Nota: " + this.bancoDados[this.posicao].nota);
  }

  public void montarTelaSerie()
  {
    Console.WriteLine("Insira o nome da serie  :");
  }

  public void executarCRUD()
  {
    while (true)
    {
      this.montarTelaSerie();

      this.nomeSerie = Console.ReadLine();

      if (nomeSerie == "") break;

      bool achou = false;

      for (int x = 0; x < this.bancoDados.Count; x++)
      {
        if (this.bancoDados[x].nome == nomeSerie)
        {
          achou = true;
          this.posicao = x;
          break;
        }
      }

      // mostra os dados da conta, caso tenha encontrado
      // ou mostra a mensagem de conta não encontrada
      if (achou)
      {
        // achou a conta e vai mostrar os dados
        this.mostrarDadosSerie();

        // pergunta para o usuario o que deseja fazer
        string resp = this.tela.perguntar(11, 13, "Deseja Alterar, Excluir ou Voltar (A/E/V): ");

        Console.Clear();

        if (resp.ToUpper() == "A")
        {
          // o usuário deseja alterar 
          // (apenas o nome do titular)
          this.nomeSerie = this.tela.perguntar(11, 12, "Novo nome : ");

          this.notaSerie = this.tela.perguntarInt(11, 12, "Nova nota (0/10) : ");

          string generoSerie = this.tela.perguntar(11, 12, "Genero serie");

          Console.WriteLine("Confirma alteração (S/N) : ");
          resp = Console.ReadLine();

          if (resp == null) break;

          if (resp.ToUpper() == "S")
          {
            this.bancoDados[this.posicao].nome = this.nomeSerie;
            this.bancoDados[this.posicao].nota = this.notaSerie;
            this.bancoDados[this.posicao].genero = generoSerie;
          }
        }
        else if (resp.ToUpper() == "E")
        {
          // usuário deseja excluir a conta
          // (a ` e toda a sua movimentacao)
          this.tela.limparArea(11, 13, 69, 13);
          resp = this.tela.perguntar(11, 13, "Confirma exclusão (S/N) : ");
          if (resp.ToUpper() == "S")
          {
            this.bancoDados.RemoveAt(this.posicao);
          }

        }
      }
      else
      {
        // não achou a conta, mostra a mensagem
        // e pergunta se deseja cadastrar uma nova
        // conta
        string resp = this.tela.perguntar(11, 13,
           "Conta não existe. Deseja cadastrar (S/N) : ");
        if (resp.ToUpper() == "S")
        {
          Console.WriteLine("Insira nome da serie");
          this.nomeSerie = Console.ReadLine();

          Console.WriteLine("Insira genero da serie");
          string generoSerie = Console.ReadLine();

          Console.WriteLine("Insira nota da serie");
          this.notaSerie = int.Parse(Console.ReadLine());

          Console.Clear();

          resp = this.tela.perguntar(11, 13, "Confirma cadastro (S/N) : ");
          if (resp.ToUpper() == "S")
          {
            this.bancoDados.Add(new Serie(nomeSerie, generoSerie, notaSerie));

            Console.WriteLine("Conta criada com sucesso.");
          }
        }
      }
    }
  }

  public void exibirSeries()
  {
    for (int i = 0; i < bancoDados.Count(); i++)
    {
      Console.WriteLine(bancoDados[i].nome);
    }
  }
}

