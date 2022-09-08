using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

    [HttpGet]
    public Person Get(){
        Person pessoa = new Person("denis", 48, "123456789");
        Contract novoContrato = new Contract("abc123", 50.45);

        pessoa.Contratos.Add(novoContrato);

        return pessoa;
    }

    [HttpPost]
    public Person Post([FromBody]Person pessoa){
        
        return pessoa;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute]int id, [FromBody]Person pessoa){
        Console.WriteLine(id);
        Console.WriteLine(pessoa);
        return "Dados do id " + id + " atualizados";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute]int id){
        return "Deletado pessoa de id " + id;
    }

}