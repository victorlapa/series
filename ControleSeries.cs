class ControleSeries
{
  Tela tela;
  List<Serie> bancoDados = new List<Serie>();
  int posicao;
  int idSerie;
  string? nomeSerie;

  public ControleSeries(Tela t)
  {
    this.tela = t;
    // cria uma primeira conta só pra ter alguma coisa 
    // no banco
    bancoDados.Add(new Serie("The 100", "Aventura", 10, new DateTime(2014, 03, 19)));
  }

  public void executarCRUD()
  {
    while (true)
    {
      // monta a tela do CRUD de contas
      this.tela.montarMoldura(10, 5, 70, 14);
      this.tela.montarLinhaHor(8, 10, 70);
      this.tela.centralizar(6, 10, 70, "CRUD de Contas");
      this.montarTelaSerie();

      // solicita o numero da conta
      Console.SetCursorPosition(21, 9);
      string idBusca = idSerie.ToString();

      idBusca = Console.ReadLine();
      if (idBusca == "") break;

      // procura no banco de dados se existe
      // o numero da conta informada
      bool achou = false;
      for (int x = 0; x < this.bancoDados.Count; x++)
      {
        if (this.bancoDados[x].id == this.idSerie)
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
        this.mostrarDadosConta();

        // pergunta para o usuario o que deseja fazer
        string resp = this.tela.perguntar(11, 13, "Deseja Alterar, Excluir ou Voltar (A/E/V): ");
        if (resp.ToUpper() == "A")
        {
          // o usuário deseja alterar 
          // (apenas o nome do titular)
          this.nomeSerie = this.tela.perguntar(11, 12, "Novo titular : ");

          // pergunta se o usuário confirma alteração
          this.tela.limparArea(11, 13, 69, 13);
          resp = this.tela.perguntar(11, 13, "Confirma alteração (S/N) : ");
          if (resp.ToUpper() == "S")
          {
            this.bancoDados[this.posicao].nome = this.nomeSerie;
          }
        }
        else if (resp.ToUpper() == "E")
        {
          // usuário deseja excluir a conta
          // (a conta e toda a sua movimentacao)
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
          this.nomeSerie = this.tela.perguntar(21, 10, "");

          this.tela.limparArea(11, 13, 69, 13);
          resp = this.tela.perguntar(11, 13, "Confirma cadastro (S/N) : ");
          if (resp.ToUpper() == "S")
          {
            this.bancoDados.Add(new Serie("The 100", "Aventura", 10, new DateTime(2014, 03, 19)));
          }
        }
      }
    }
  }

  public void montarTelaSerie()
  {
    Console.SetCursorPosition(11, 9);
    Console.Write("Nome  :");
    Console.SetCursorPosition(11, 10);
    Console.Write("Genero :");
    Console.SetCursorPosition(11, 11);
    Console.Write("Nota   :");
    Console.SetCursorPosition(11, 12);
    Console.Write("Data Lancamento   :");
  }

  public void mostrarDadosConta()
  {
    Console.SetCursorPosition(21, 10);
    Console.Write(
        this.bancoDados[0].nome);
    Console.SetCursorPosition(21, 11);
    Console.Write(
        this.bancoDados[0].nota);
  }
}