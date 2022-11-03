Tela tela = new Tela();
ControleSeries controle = new ControleSeries(tela);

string opcao;
List<string> menuPrincipal = new List<string>();

menuPrincipal.Add("1 - Procurar series");
menuPrincipal.Add("2 - Exibir series");
menuPrincipal.Add("0 - Sair");

tela.configurarTela();

while (true)
{
  opcao = tela.mostrarMenu(menuPrincipal, 3, 3);

  if (opcao == "0") break;
  if (opcao == "1") controle.executarCRUD();
  if (opcao == "2") controle.exibirSeries();
}
Console.Clear();