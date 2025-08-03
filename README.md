# DIO - Trilha .NET - Explorando a linguagem C#
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de explorando a linguagem C#, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema de hospedagem, que será usado para realizar uma reserva em um hotel. Você precisará usar a classe Pessoa, que representa o hóspede, a classe Suíte, e a classe Reserva, que fará um relacionamento entre ambos.

O seu programa deverá cálcular corretamente os valores dos métodos da classe Reserva, que precisará trazer a quantidade de hóspedes e o valor da diária, concedendo um desconto de 10% para caso a reserva seja para um período maior que 10 dias.

## Regras e validações
1. Não deve ser possível realizar uma reserva de uma suíte com capacidade menor do que a quantidade de hóspedes. Exemplo: Se é uma suíte capaz de hospedar 2 pessoas, então ao passar 3 hóspedes deverá retornar uma exception.
2. O método ObterQuantidadeHospedes da classe Reserva deverá retornar a quantidade total de hóspedes, enquanto que o método CalcularValorDiaria deverá retornar o valor da diária (Dias reservados x valor da diária).
3. Caso seja feita uma reserva igual ou maior que 10 dias, deverá ser concedido um desconto de 10% no valor da diária.


![Diagrama de classe estacionamento](diagrama_classe_hotel.png)

## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.

# Minha solução do desafio 🎉

O interessante nos code challenges da dio é que, por serem simples, nos dão espaço para implementar soluções que vão além das solicitadas. E foi o que fiz neste desafio. 

É claro que não saí tentando implementar mil e uma coisas logo de cara! 🫠

Decidi que, já que queria fazer uma solução diferente da proposta, o melhor workflow seria trabalhar em outra branch do repositório. Não comprometendo, então, o código original. Por isso, neste repositório, você vai encontrar duas branches: a main e a sandbox-solution.

## A trajetória para a solução

Primeiro, assisti aos vídeos, li o material complementar, fiz o fork e dei uma olhada no código. Então, desloguei do computador (até porque já estava tarde) e fui trabalhar no meu Projeto-de-Lego-das-férias™ enquanto deixava esse assunto rodando em segundo plano no meu cérebro.

Um dos meus mentores de programação me ensinou que primeiro fazemos a solução mais simples possível e depois vamos incrementando-a.

Esse foi o raciocínio que adotei neste desafio!

No dia seguinte, voltei, com a cabeça fresca e resolvi o desafio requerido - tirei todos os TODO's da frente. Com tudo  funcionando, sincronizei a branch da solução (sandbox-solution) com o GitHub. 

Deste modo, o programa estava pronto para refatoração.

## Refatorando o código 🙃

Comecei, listando as novas funcionalidades que queria que o programa tivesse, eliminei as que eu não saberia implementar e, então, fui implementando as novas. 

Uma vez implementadas e devidamente testadas, parti para uma segunda etapa de refatoração: a criação de um menu (utilizei o menu de um dos programas que feitos durante o bootacamp da dio e alterei para as especifidades da minha solução).

Durante os testes depois de aplicar o menu para interação como o usuário, começaram a surgir elas, as tão temidas, as exceções! Afinal de contas, não é possível prever todas as situações pelas quais seu programa pode passar 😦

## Funcionamento do programa ⚙️⚙️⚙️ e explicando as validações ✅

1) O usuário será recebido por um menu de boas-vindas que questiona de quantos dias será a estadia

+ Esse campo passa por uma validação com do-while e TryParse que valida se foi inserido um número e se esse número é maior que zero.

Após inserida uma quantidade válida de dias, o programa, internamente cadastra a classe reserva com o número de dias inserido pelo usuário.

2) Então, exibe um menu com 5 opções de suítes e pede que o usuário escolha uma opção: 
    
    AS SUÍTES DISPONÍVEIS SÃO:

    Opção A) Suíte Single, 1 pessoa, Preço: R$ 50,00

    Opção B) Suíte Double, 2 pessoas, Preço: R$ 100,00

    Opção C) Suíte Triple, 3 pessoas, Preço: R$ 150,00

    Opção D) Suíte Master, 5 pessoas, Preço: R$ 250,00

    Opção E) Suíte Personalizada, até 10 pessoas, Preço: R$ 500,00

    ESCOLHA SUA SUÍTE:

+ Neste caso, foi feito um laço while para que o usuário insira a opção correta da suíte e o menu é reexibido toda vez que uma opção incorreta é digitada.
2) 1) Caso o usuário escolha a opção E, da Suíte Personalizada, deverá inserir o número de hóspedes para seguinte avalidação: deve ser um número, não pode ser menor que zero nem maior que a capacidade da suíte. Essa validação foi feita usando laço do-while e TryParse.

Escolhida uma suíte, o programa, internamente, faz o cadastro da suíte na classe reserva e quebra o laço do menu.

3) Em seguida, o programa confirma a suíte escolhida e abre os campos para inserção de Nome e Sobrenome dos hóspedes, de acordo com a capacidade de cada suíte (ou de acordo com a quantidade de hóspedes inseridos na opção E).

+ Neste campo, não há nenhum tipo de validação e o programa aceita valores nulos - uma vez que a propriedade Nullable deste projeto (no .csproj) veio disabled e eu a mantive desta maneira.

O programa cadastra os nomes inseridos na lista hospedes e cadastra os hóspedes na classe reserva, internamente.

4) Por fim, a reserva é confirmada e os nomes dos hóspedes são reexibidos na tela, juntamente com as informações de quantidades de hóspedes, através do método ObterQuantidadeHospedes() e o valor da estadia, através do método CalcularValorDiaria() 

## Importante 

A implementação da minha solução invalidou o lançamento da exception solicitada no enunciado, pois foram criadas safeguards para impedir que o usuário fizesse a entrada mais hóspedes do que uma suíte comporta.

Mas, a exception foi lançada corretamente na classe Reserva, método CadastrarHospedes():

    ```csharp

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        // Verificar se a a suíte acomoda os hóspedes
        if (Suite.Capacidade >= hospedes.Count)
        {
            Hospedes = hospedes;
        }
        else
        {
            // Retorna uma exception caso contrário
            throw new Exception("A suíte não acomoda mais hóspedes do que sua capacidade");
        }
    }
    
    ```

