using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (int.Parse(opcaoUsuario) != 4)
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos){
                            if(!string.IsNullOrEmpty(a.Nome)){
                                Console.WriteLine();
                            Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}");
                            }       
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        int nrAlunos = 0;
                        decimal media = 0;
                        ConceitoEnum conceitoGeral;

                        for(int i=0; i < alunos.Length; i++){
                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal += alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        media = notaTotal / nrAlunos;

                        if(media <= 2){
                            conceitoGeral = ConceitoEnum.E;
                        }else if(media <= 4){
                            conceitoGeral = ConceitoEnum.D;
                        }else if(media <= 6){
                            conceitoGeral = ConceitoEnum.C;
                        }else if(media <= 8){
                            conceitoGeral = ConceitoEnum.B;
                        }else{
                            conceitoGeral = ConceitoEnum.A;
                        }

                        Console.WriteLine($"Média Geral: {media} - CONCEITO {conceitoGeral}");

                        break;                 
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir Novo Aluno");
            Console.WriteLine("2- Listar Alunos");
            Console.WriteLine("3- Calcular Média Geral");
            Console.WriteLine("4- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
