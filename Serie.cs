class Serie
{
  public static int qtdAdicionadas = 1;
  public int id;
  public string nome;
  public string genero;
  public int nota;
  public DateTime dataAdicionada;


  public Serie(string nome, string genero, int nota)
  {
    this.id = qtdAdicionadas;
    this.nome = nome;
    this.genero = genero;
    this.nota = nota;
    this.dataAdicionada = DateTime.Now;

    qtdAdicionadas++;
  }
}