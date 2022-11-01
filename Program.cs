Tela tela = new Tela();
ControleSeries contas = new ControleSeries(tela);

string opcao;
List<string> menuPrincipal = new List<string>();

menuPrincipal.Add("1 - Series");
menuPrincipal.Add("0 - Sair");

tela.configurarTela();

while (true)
{
  tela.montarTelaSistema();
  opcao = tela.mostrarMenu(menuPrincipal, 3, 3);

  if (opcao == "0") break;
  if (opcao == "1") contas.executarCRUD();
}
//tela.montarMoldura(5,5,40,10);
//tela.montarMoldura(10,7,50,20);
Console.Clear();