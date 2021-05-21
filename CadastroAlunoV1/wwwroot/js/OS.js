

function buscaLista(cliId) {
    if (cliId) {
        j = { ClienteId: cliId }
        $.ajax({
            url: '/OS/PopulaProjetos',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(j)//passa o ID do cliente pra action
        }).done(function (response) {//executa a função abaixo quando receber a resposta do controller
            var dropdown = document.getElementById("dropProjetosCliente");//seleciona o dropdownlist
            var dropdownOS = document.getElementById("dropProjetosOS");
            $(dropdown).empty();//zera as opções caso o metodo seja chamado novamente
            $(dropdownOS).empty();
            //var option = document.createElement('option');//cria nova option
            //option.text = "Selecione...";//adiciona o valor padrão
            //option.value = "";//define valor vazio pra opção padrao
            //dropdown.add(option, 0)//adiciona a opção ao dropdown
            //dropdown.selectedOption = ""; //deixa essa como a opção selecionada (apenas para novos registros)
            var inicio = new Number(dropdown.options.length)//define a posição inicial para inserir as opções abaixo
            response.forEach(//para cada item da resposta do contorller(lista de opcoes)
                function (element, index, array) {
                    var option = document.createElement('option');//cria opcao
                    option.text = element.nomeProjeto;//atribui texto igual a da opção recebida(nome)
                    option.value = element.id;//atribui valor igual da opção recebida(id)
                    dropdown.add(option, inicio)//adiciona ao dropdown
                })
        })
    }
}
