

instalar wamp, instalar o workbench -feito

criar bd -feito


SerieDeIngresso{
id :int
serie :varchar(3)
}

Endereco{
id :int,
cep :varchar (8) //nao é primario pq pode repetir,
rua :varchar (120)
numeroDaResidencia :int
complemento :varchar (50)
bairro :varchar (100)
cidade :varchar (30) //São José do Vale do Rio Preto ,30char
estado :varchar (25)

 

}

Mae{

nome :varchar(100 caracteres)
cpf :varchar(11)(CPF válido)
dataPreferencialPagamento (para pagamento da mensalidade (Data válida))


}

Aluno
{

nome :varchar (100),
datanascimento (formato dd/mm/aaaa),
idSerieDeIngresso :int,
IdEndereco :int
idMae :int
}





----requisitos funcionais

O usuário deve poder criar, editar e deletar alunos com as seguintes informações:
O usuário deve poder ver todos os alunos cadastrados.


criar interfaces
criar classes -feito
criar dtos -feito
criar viewmodels


Por algum motivo não consigo cadastrar ou editar a SerieDeIngressos, erro no modelo
é como s o model na View não estivesse a obter os dados e vai para a DAO em branco


Validar o CPF, CPF não deve ser repetido

