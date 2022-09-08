using System.Collections.Generic;

namespace src.Models;

public class Person
{
    public Person()
    {
        this.Nome = "template";
        this.Idade = 0;
        this.Contratos = new List<Contract>();
        this.Ativado = true;

    }

    public Person(string Nome, int Idade, string Cpf){
         this.Nome = Nome;
         this.Idade = Idade;
         this.Cpf = Cpf;
         this.Contratos = new List<Contract>();
         this.Ativado = true;
    }


    public int Id { get; set; }
    public string Nome {get; set;}

    public int Idade { get; set; }

    public string? Cpf { get; set; }
    public bool Ativado { get; set; }
    public List<Contract> Contratos { get; set; }

}