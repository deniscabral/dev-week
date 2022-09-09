using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Models;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private DatabaseContext _repository { get; set; }

    public PersonController(DatabaseContext context)
    {
        this._repository = context;
    }

    [HttpGet]
    public List<Person> Get(){

        return _repository.Pessoas.Include( p => p.Contratos).ToList();
    }

    //public Person Get(){
        //Person pessoa = new Person("denis", 48, "123456789");
        //Contract novoContrato = new Contract("abc123", 50.45);

       //pessoa.Contratos.Add(novoContrato);
       
        //return pessoa;
    //}

    [HttpPost]
    public Person Post([FromBody]Person pessoa){
        _repository.Pessoas.Add(pessoa);
        _repository.SaveChanges();
        return pessoa;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute]int id, [FromBody]Person pessoa){
        _repository.Pessoas.Update(pessoa);
        _repository.SaveChanges();

        //Console.WriteLine(id);
        //Console.WriteLine(pessoa);
        return "Dados do id " + id + " atualizados";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute]int id){
        return "Deletado pessoa de id " + id;
    }

}