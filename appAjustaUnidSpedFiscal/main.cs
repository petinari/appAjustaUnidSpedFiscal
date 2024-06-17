using System.Collections.Generic;

class TestClass
{
    static void Main(string[] args)
    {
        //le o input do arquivo txt
        Console.WriteLine("Digite o caminho do arquivo txt: ");

        

        string caminho = Console.ReadLine();

        //remove as aspas do caminho
        caminho = caminho.Replace("\"", "");
        
        var arquivo = new List<String>(System.IO.File.ReadLines(caminho));


        var _0200List = new List<String>();
        var _C170List = new List<String>();
        int erros = 0;

        foreach (string line in arquivo)
        {
            if (line.Contains("|0200|"))
            {
                _0200List.Add(line);
            }
            if (line.Contains("|C170|"))
            {
                _C170List.Add(line);
            }
        }
        foreach (var item0200 in _0200List)
        {
            var linha0200 = item0200.Split('|');
            int index = 0;
            foreach (var itemC170 in _C170List)
            {
                var linhaC170 = itemC170.Split('|');
                if (linha0200[2] == linhaC170[3])
                {
                    if (linha0200[6] != linhaC170[6])
                    {
                        List<String> linhaC170Novo = new List<String>(linhaC170);
                        linhaC170Novo[6] = linha0200[6];
                        var indexC170 = arquivo.IndexOf(itemC170);
                        arquivo[indexC170] = String.Join("|", linhaC170Novo);
                        erros++;
                    }
                }
                index++;
            }
        }
        Console.WriteLine(erros);
        System.IO.File.WriteAllLines(caminho, arquivo);
    }
}