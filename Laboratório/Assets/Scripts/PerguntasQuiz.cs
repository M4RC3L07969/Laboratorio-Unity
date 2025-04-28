using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PerguntasQuiz : MonoBehaviour
{
    private String[] listaDePerguntas = new String[45] {"O que são átomos e moléculas?",
            "Qual a diferença entre substâncias puras e misturas?",
            "O que caracteriza uma mudança física e uma mudança química?",
            "Quais são os estados físicos da matéria?",
            "O que é a tabela periódica e como ela está organizada?",
            "O que são metais, ametais e gases nobres?",
            "Qual a diferença entre substâncias simples e compostas?",
            "O que são reações químicas? Dê um exemplo.",
            "O que é um elemento químico?",
            "O que são ácidos e bases?",
            "O que são ligações iônicas e covalentes?",
            "Como ocorre a ligação metálica?",
            "O que é eletronegatividade e como ela influencia as ligações químicas?",
            "Qual a diferença entre reações endotérmicas e exotérmicas?",
            "O que são coeficientes estequiométricos?",
            "O que é um mol e qual sua relação com a constante de Avogadro?",
            "Como se classificam as funções inorgânicas (ácidos, bases, sais e óxidos)?",
            "O que são soluções e quais são suas classificações?",
            "Como calcular a concentração de uma solução?",
            "O que é a lei da conservação da massa de Lavoisier?",
            "Como balancear uma equação química?",
            "Qual a importância do pH e como ele é calculado?",
            "O que são reações de oxidação e redução?",
            "O que é cinética química e quais fatores influenciam a velocidade de uma reação?",
            "O que é catalisador e qual seu papel nas reações químicas?",
            "Como funcionam os equilíbrios químicos?",
            "O que é a constante de equilíbrio (Kc)?",
            "Como a pressão e a temperatura afetam um equilíbrio químico?",
            "O que diz o princípio de Le Chatelier?",
            "O que são reações reversíveis e irreversíveis?",
            "O que é solubilidade e quais fatores a influenciam?",
            "O que é eletroquímica e como funcionam as pilhas eletroquímicas?",
            "Qual a diferença entre eletrólise ígnea e eletrólise aquosa?",
            "O que é química orgânica e qual sua importância?",
            "O que são hidrocarbonetos e como são classificados?",
            "O que são grupos funcionais na química orgânica?",
            "O que é isomeria e quais são seus tipos?",
            "Como funcionam as reações de substituição, adição e eliminação?",
            "O que é polimerização e quais são os principais tipos de polímeros?",
            "O que são biomoléculas e qual sua importância para a vida?",
            "O que é a radioatividade e como ela foi descoberta?",
            "Como funcionam as reações nucleares de fissão e fusão?",
            "O que são os gases do efeito estufa e qual seu impacto ambiental?",
            "Como os combustíveis fósseis afetam o meio ambiente?",
            "O que são energias renováveis e como a química contribui para seu desenvolvimento?"};

    string[][] listaDeRespostas = new string[][]
{
    new string[]
    {
        "Átomos são as menores unidades de elementos químicos, compostos por prótons, nêutrons e elétrons. Moléculas são formadas por átomos ligados entre si, podendo ser compostos por átomos do mesmo ou de diferentes elementos.",
        "Átomos são partículas indivisíveis que formam as moléculas. Moléculas são átomos que não podem ser divididos.",
        "Átomos são partículas que se ligam a outros átomos para formar moléculas. Moléculas podem existir sozinhas ou em grupos.",
        "Átomos e moléculas são a mesma coisa, sendo apenas diferentes em tamanho."
    },
    new string[]
    {
        "Substâncias puras são compostas por apenas um tipo de átomo ou molécula. As misturas são formadas por dois ou mais componentes diferentes.",
        "Substâncias puras podem ser compostas por vários tipos de moléculas, enquanto misturas contêm apenas um tipo de átomo.",
        "As substâncias puras podem ser alteradas em suas propriedades, mas as misturas sempre mantêm as propriedades do material original.",
        "Substâncias puras podem ser separadas em misturas, mas misturas não podem ser formadas a partir de substâncias puras."
    },
    new string[]
    {
        "Mudanças físicas alteram as características de uma substância sem modificar sua composição química. Já as mudanças químicas alteram a estrutura molecular da substância, resultando em novos produtos.",
        "Mudanças físicas resultam na formação de novas substâncias, enquanto mudanças químicas não alteram a substância original.",
        "Mudanças físicas não alteram a substância, mas mudanças químicas alteram as propriedades físicas também.",
        "Mudanças físicas envolvem apenas a alteração de temperatura e pressão, enquanto mudanças químicas ocorrem apenas em substâncias líquidas."
    },
    new string[]
    {
        "Os estados físicos da matéria são sólido, líquido e gasoso. O plasma é considerado o quarto estado da matéria.",
        "Os estados físicos da matéria são sólidos, líquidos, gasosos e radioativos.",
        "Os estados físicos da matéria incluem apenas os sólidos e líquidos.",
        "Os estados da matéria não incluem o gasoso, pois as moléculas sempre se encontram unidas."
    },
    new string[]
    {
        "A tabela periódica organiza os elementos químicos de acordo com suas propriedades e suas massas atômicas, com os elementos semelhantes dispostos em colunas chamadas grupos.",
        "A tabela periódica organiza os elementos químicos pela ordem de descoberta, sem levar em consideração suas propriedades.",
        "A tabela periódica é organizada apenas pelos elementos metálicos e seus compostos.",
        "A tabela periódica é organizada por cor e formato das moléculas."
    },
    new string[]
    {
        "Metais são bons condutores de eletricidade e calor, enquanto ametais são isolantes. Gases nobres são elementos estáveis, encontrados na última coluna da tabela periódica.",
        "Metais são sólidos que não conduzem eletricidade, ametais são líquidos e gases nobres são altamente reativos.",
        "Metais e ametais possuem as mesmas propriedades e os gases nobres não fazem parte da tabela periódica.",
        "Metais são elementos radioativos, ametais são compostos orgânicos e gases nobres são compostos de hidrogênio e oxigênio."
    },
    new string[]
    {
        "Substâncias simples são formadas por átomos de um único elemento, enquanto substâncias compostas são formadas por átomos de dois ou mais elementos.",
        "Substâncias simples são compostas apenas por elementos metálicos, enquanto compostas podem ter apenas não metais.",
        "Substâncias simples têm mais de um átomo, enquanto compostas têm apenas um.",
        "Substâncias simples são aquelas que não podem ser combinadas para formar compostos."
    },
    new string[]
    {
        "Reações químicas são processos em que os reagentes se transformam em produtos, com a quebra ou formação de novas ligações. Exemplo: a queima de combustível.",
        "Reações químicas ocorrem apenas em substâncias líquidas, sem a formação de novos compostos.",
        "Reações químicas são processos físicos em que os produtos mantêm as mesmas propriedades dos reagentes.",
        "Reações químicas não alteram a estrutura das moléculas envolvidas, apenas as suas propriedades físicas."
    },
    new string[]
    {
        "Um elemento químico é uma substância que não pode ser decomposta em substâncias mais simples. Cada elemento é definido pelo número de prótons no núcleo de seus átomos.",
        "Um elemento químico é um tipo de substância composta por dois ou mais átomos.",
        "Elementos químicos são formados apenas por moléculas que contêm o mesmo número de átomos.",
        "Elementos químicos são substâncias que podem ser decompostas em outras substâncias mais simples."
    },
    new string[]
    {
        "Ácidos são substâncias que liberam íons de hidrogênio (H+) em solução, enquanto bases liberam íons hidróxido (OH-).",
        "Ácidos são substâncias que liberam íons de oxigênio (O-) em solução, enquanto bases liberam apenas íons negativos.",
        "Ácidos e bases são substâncias neutras e não reagem entre si.",
        "Ácidos são substâncias que liberam íons de hidrogênio (H-) e bases liberam cátions."
    },
    new string[]
    {
        "Ligações iônicas ocorrem entre metais e ametais, com transferência de elétrons. Ligações covalentes ocorrem entre ametais, com o compartilhamento de elétrons.",
        "Ligações iônicas ocorrem entre dois ametais e envolvem o compartilhamento de elétrons.",
        "Ligações covalentes ocorrem entre metais e ametais, e envolvem a troca de elétrons.",
        "Ligações covalentes não envolvem átomos, mas sim a união de partículas de diferentes substâncias."
    },
    new string[]
    {
        "A ligação metálica é formada por átomos de metais que compartilham seus elétrons de forma livre, formando uma rede de cátions.",
        "A ligação metálica é formada por átomos não metálicos que se unem através de uma camada densa de elétrons.",
        "A ligação metálica ocorre apenas em compostos orgânicos.",
        "A ligação metálica é a interação entre prótons e elétrons em compostos gasosos."
    },
    new string[]
    {
        "Eletronegatividade é a tendência de um átomo atrair elétrons em uma ligação química. Quanto maior a eletronegatividade, mais forte é a atração pelos elétrons compartilhados.",
        "Eletronegatividade é a capacidade de um átomo doar elétrons em uma ligação.",
        "Eletronegatividade é a tendência de um átomo repulsar outros átomos, dificultando a formação de ligações.",
        "Eletronegatividade é uma propriedade que só afeta as reações químicas de átomos metálicos."
    },
    new string[]
    {
        "Reações endotérmicas absorvem calor do ambiente, enquanto reações exotérmicas liberam calor.",
        "Reações endotérmicas liberam calor, enquanto as exotérmicas absorvem calor.",
        "As reações endotérmicas e exotérmicas são as mesmas, apenas com nomes diferentes.",
        "Reações endotérmicas são reações que não alteram a temperatura do ambiente."
    },
    new string[]
    {
        "Coeficientes estequiométricos indicam a quantidade de reagentes e produtos em uma equação química balanceada, garantindo a conservação de átomos.",
        "Coeficientes estequiométricos indicam a quantidade de energia necessária para uma reação ocorrer.",
        "Coeficientes estequiométricos indicam apenas a temperatura necessária para que a reação aconteça.",
        "Coeficientes estequiométricos referem-se apenas à concentração de reagentes em uma reação."
    },
    new string[]
    {
        "Um mol é a quantidade de substância que contém o número de Avogadro (aproximadamente 6,022 x 10^23 unidades), que corresponde a um número fixo de entidades elementares.",
        "Um mol é a quantidade de uma substância que tem massa igual a 1 grama.",
        "Um mol é o número de moléculas de uma substância que interage em uma reação química.",
        "Um mol corresponde à quantidade de elementos em uma molécula de água."
    },
    new string[]
    {
        "As funções inorgânicas são classificadas em ácidos, bases, sais e óxidos, de acordo com suas propriedades químicas e sua composição.",
        "As funções inorgânicas são classificadas apenas em ácidos e bases.",
        "As funções inorgânicas envolvem apenas a combinação de gases.",
        "As funções inorgânicas não incluem os óxidos ou sais em sua classificação."
    },
    new string[]
    {
        "Soluções são misturas homogêneas compostas por um soluto e um solvente. Elas podem ser classificadas como saturadas ou insaturadas, dependendo da quantidade de soluto dissolvido.",
        "Soluções são sempre compostos por apenas um tipo de soluto.",
        "Soluções podem ser formadas apenas em estado sólido.",
        "Soluções são misturas onde os solutos podem ser facilmente separados por filtração."
    },
    new string[]
    {
        "A concentração de uma solução é calculada dividindo-se a quantidade de soluto pela quantidade de solução. Pode ser expressa em mol/L (molaridade), entre outras unidades.",
        "A concentração de uma solução é calculada dividindo-se a quantidade de solvente pela quantidade de soluto.",
        "A concentração de uma solução é sempre 1 mol/L, independentemente da quantidade de soluto.",
        "A concentração de uma solução depende apenas da temperatura e pressão."
    },
    new string[]
    {
        "A Lei da Conservação da Massa de Lavoisier afirma que a massa total dos reagentes em uma reação química é igual à massa total dos produtos.",
        "A Lei da Conservação da Massa de Lavoisier afirma que a massa dos produtos é sempre maior do que a dos reagentes.",
        "A Lei de Lavoisier afirma que a massa total é perdida em reações químicas.",
        "A Lei da Conservação da Massa de Lavoisier só se aplica a reações que ocorrem a temperatura constante."
    },
    new string[]
    {
        "Balancear uma equação química envolve ajustar os coeficientes para garantir que o número de átomos de cada elemento seja o mesmo dos dois lados da equação.",
        "Balancear uma equação química envolve alterar os números de átomos, mas sem se preocupar com a quantidade de cada substância.",
        "Balancear uma equação química envolve apenas equilibrar as massas das substâncias.",
        "Balanceamento de equações químicas é feito alterando os valores das massas, mas não o número de átomos."
    },
    new string[]
    {
        "O pH é uma medida da acidez ou basicidade de uma solução. Ele é calculado com a fórmula pH = -log[H+], onde [H+] representa a concentração de íons de hidrogênio na solução.",
        "O pH é calculado com base na concentração de moléculas de oxigênio em uma solução.",
        "O pH é uma medida de temperatura, não relacionada à concentração de íons em uma solução.",
        "O pH é calculado com a fórmula pH = -log[OH-], que representa a concentração de íons hidróxido."
    },
    new string[]
    {
        "Reações de oxidação envolvem a perda de elétrons, enquanto reações de redução envolvem o ganho de elétrons.",
        "Reações de oxidação e redução não envolvem elétrons, mas apenas variações nas temperaturas das substâncias.",
        "Reações de oxidação e redução não afetam as ligações químicas, apenas as propriedades físicas.",
        "Reações de oxidação e redução ocorrem apenas com compostos orgânicos."
    },
    new string[]
    {
        "A cinética química estuda a velocidade das reações químicas e os fatores que influenciam essa velocidade, como temperatura, concentração dos reagentes e presença de catalisadores.",
        "A cinética química estuda apenas a formação de produtos, sem considerar a velocidade das reações.",
        "A cinética química trata da quantidade de energia liberada durante as reações, sem considerar os fatores que alteram a velocidade.",
        "A cinética química é relacionada apenas ao equilíbrio das reações, não às reações em si."
    },
    new string[]
    {
        "Catalisadores são substâncias que aceleram as reações químicas, proporcionando um caminho alternativo de menor energia de ativação, sem serem consumidos no processo.",
        "Catalisadores são substâncias que diminuem a velocidade das reações químicas, tornando-as mais estáveis.",
        "Catalisadores aumentam a quantidade de energia necessária para a reação ocorrer.",
        "Catalisadores reagem com os produtos, transformando-os em novas substâncias durante o processo."
    },
    new string[]
    {
        "Equilíbrios químicos ocorrem quando as reações químicas reversíveis atingem uma situação onde as concentrações dos reagentes e produtos permanecem constantes.",
        "Equilíbrios químicos são situações em que as reações param de ocorrer, e não há mais interação entre os reagentes.",
        "Equilíbrios químicos são processos onde os reagentes se convertem completamente em produtos.",
        "Equilíbrios químicos só ocorrem em soluções aquosas, e não em reações gasosas ou sólidas."
    },
    new string[]
    {
        "A constante de equilíbrio (Kc) é uma constante que descreve a relação entre as concentrações dos produtos e reagentes em equilíbrio, para uma reação específica a uma temperatura constante.",
        "A constante de equilíbrio (Kc) descreve a quantidade de calor liberado durante uma reação.",
        "A constante de equilíbrio (Kc) refere-se apenas à quantidade de catalisadores presentes em uma reação.",
        "A constante de equilíbrio (Kc) é determinada apenas pela pressão e não pela concentração dos reagentes."
    },
    new string[]
    {
        "A pressão e a temperatura afetam um equilíbrio químico, pois mudanças nessas variáveis podem favorecer a formação de produtos ou reagentes, alterando as concentrações no equilíbrio.",
        "A pressão e a temperatura não afetam o equilíbrio químico, pois os reagentes sempre se transformam em produtos na mesma proporção.",
        "A pressão e a temperatura apenas afetam a quantidade de catalisadores em uma reação de equilíbrio.",
        "A pressão e a temperatura alteram a velocidade de uma reação, mas não o equilíbrio entre os reagentes e produtos."
    },
    new string[]
    {
        "O princípio de Le Chatelier afirma que, quando um sistema em equilíbrio é perturbado, ele tende a se ajustar para minimizar a mudança e restabelecer o equilíbrio.",
        "O princípio de Le Chatelier afirma que, quando um sistema em equilíbrio é perturbado, ele tende a acelerar a reação até que a mudança seja maximizada.",
        "O princípio de Le Chatelier só se aplica a reações reversíveis e não a processos que envolvem catalisadores.",
        "O princípio de Le Chatelier não afeta o equilíbrio entre os reagentes, apenas a concentração dos produtos."
    },
    new string[]
    {
        "Reações reversíveis são aquelas que podem ocorrer nos dois sentidos, enquanto reações irreversíveis são aquelas que vão de reagentes a produtos e não podem retornar.",
        "Reações reversíveis podem ocorrer apenas em soluções líquidas e nunca em estados sólidos.",
        "Reações reversíveis e irreversíveis são o mesmo tipo de reação, com apenas uma diferença na velocidade.",
        "Reações reversíveis são aquelas em que os produtos não podem se transformar novamente em reagentes."
    },
    new string[]
    {
        "Solubilidade é a capacidade de uma substância se dissolver em um solvente. Fatores como temperatura, pressão e natureza do solvente afetam a solubilidade.",
        "Solubilidade é uma propriedade constante e não é influenciada por temperatura ou pressão.",
        "Solubilidade depende apenas do tipo de solvente, independentemente das características da substância.",
        "Solubilidade é a quantidade de gás que uma substância pode liberar na forma sólida."
    },
    new string[]
    {
        "Eletroquímica é a área da química que estuda as reações que envolvem a transferência de elétrons, como as pilhas e as reações de eletrólise.",
        "Eletroquímica estuda apenas as reações gasosas, sem envolvimento de eletricidade.",
        "Eletroquímica não se refere a pilhas ou reações redox, mas ao estudo de compostos com alta condutividade elétrica.",
        "Eletroquímica estuda apenas reações que ocorrem em temperaturas muito altas."
    },
    new string[]
    {
        "A eletrólise ígnea ocorre quando compostos sólidos fundidos são decompostos por corrente elétrica, enquanto a eletrólise aquosa ocorre em soluções líquidas de compostos.",
        "A eletrólise ígnea ocorre em soluções aquosas, enquanto a eletrólise aquosa é realizada em substâncias sólidas.",
        "A eletrólise ígnea não envolve corrente elétrica, mas apenas alta pressão.",
        "A eletrólise aquosa envolve a decomposição de gases nobres, enquanto a ígnea envolve apenas metais."
    },
    new string[]
    {
        "A química orgânica estuda os compostos de carbono e suas reações, sendo essencial para a produção de plásticos, medicamentos, alimentos e combustíveis.",
        "A química orgânica estuda os compostos inorgânicos e suas propriedades físicas.",
        "A química orgânica é a área que estuda apenas os ácidos e bases.",
        "A química orgânica se concentra apenas em substâncias sólidas e não líquidas ou gasosas."
    },
    new string[]
    {
        "Hidrocarbonetos são compostos formados exclusivamente por carbono e hidrogênio. Eles são classificados como alcanos, alcenos, alcinos e aromáticos, dependendo das ligações entre os átomos.",
        "Hidrocarbonetos são compostos formados apenas por carbono, oxigênio e hidrogênio.",
        "Hidrocarbonetos são compostos que contêm apenas átomos de carbono.",
        "Hidrocarbonetos são compostos encontrados exclusivamente em combustíveis fósseis, sem outras fontes."
    },
    new string[]
    {
        "Grupos funcionais são grupos específicos de átomos em moléculas orgânicas que determinam suas propriedades e reatividade, como os ácidos carboxílicos, álcoois, ésteres, etc.",
        "Grupos funcionais são partes de moléculas que não influenciam suas reações químicas.",
        "Grupos funcionais são os compostos formados durante a reação de substituição.",
        "Grupos funcionais são apenas combinações de átomos de carbono em moléculas."
    },
    new string[]
    {
        "Isomeria é a propriedade que permite a existência de compostos com a mesma fórmula molecular, mas com arranjos diferentes de átomos. Existem isômeros estruturais e espaciais.",
        "Isomeria é a diferença entre dois compostos com diferentes fórmulas químicas, mas com propriedades físicas semelhantes.",
        "Isomeria ocorre apenas entre substâncias que têm a mesma fórmula estrutural.",
        "Isomeria é a formação de moléculas com a mesma fórmula, mas que não têm propriedades químicas similares."
    },
    new string[]
    {
        "Reações de substituição, adição e eliminação são tipos de reações orgânicas. Na substituição, um átomo ou grupo é substituído; na adição, dois átomos ou grupos são adicionados; na eliminação, um grupo é removido.",
        "Reações de substituição e adição não envolvem a quebra de ligações, enquanto reações de eliminação não envolvem a formação de novas ligações.",
        "Reações de substituição e eliminação sempre envolvem a formação de compostos mais estáveis.",
        "Reações de substituição, adição e eliminação não são comuns em reações orgânicas."
    },
    new string[]
    {
        "Polimerização é o processo de formação de polímeros a partir de monômeros, podendo ser do tipo adição ou condensação.",
        "Polimerização é o processo de decomposição de polímeros em monômeros.",
        "Polimerização ocorre apenas em compostos de carbono, sem envolver outros átomos.",
        "Polimerização é a reação entre metais e ácidos, sem envolver moléculas orgânicas."
    },
    new string[]
    {
        "Biomoléculas são moléculas essenciais para os processos biológicos, como carboidratos, lipídios, proteínas e ácidos nucleicos. Elas são fundamentais para a vida.",
        "Biomoléculas são moléculas formadas apenas por elementos metálicos, como ferro e cobre.",
        "Biomoléculas são compostos que se formam durante as reações de combustão.",
        "Biomoléculas não são fundamentais para os seres vivos, mas são encontradas em substâncias sintéticas."
    },
    new string[]
    {
        "Radioatividade é a emissão espontânea de radiação por átomos instáveis, como o urânio e o rádio. Ela foi descoberta por Marie e Pierre Curie.",
        "Radioatividade é a radiação emitida apenas por átomos de oxigênio.",
        "Radioatividade é a capacidade dos átomos de emitir luz visível.",
        "Radioatividade é um fenômeno que ocorre apenas em materiais sólidos."
    },
    new string[]
    {
        "Fissão nuclear é o processo em que o núcleo de um átomo se divide, liberando energia, enquanto a fusão nuclear é a junção de dois núcleos para formar um mais pesado, também liberando energia.",
        "A fissão nuclear não libera energia, enquanto a fusão é responsável pela produção de radiação.",
        "A fissão nuclear é a junção de átomos, e a fusão é a divisão dos átomos.",
        "A fissão e fusão nuclear não têm relação com a liberação de energia, mas apenas com a separação de átomos."
    },
    new string[]
    {
        "Os gases do efeito estufa, como dióxido de carbono, metano e óxidos de nitrogênio, contribuem para o aquecimento global ao prenderem calor na atmosfera.",
        "Os gases do efeito estufa são inofensivos, pois não alteram a temperatura do planeta.",
        "Os gases do efeito estufa só afetam os oceanos e não têm impacto sobre o clima.",
        "Gases do efeito estufa são formados por elementos como oxigênio e nitrogênio, que ajudam na resfriamento da atmosfera."
    },
    new string[]
    {
        "Combustíveis fósseis, como petróleo e carvão, liberam gases de efeito estufa, como dióxido de carbono, que contribuem para o aquecimento global e mudanças climáticas.",
        "Combustíveis fósseis não afetam o meio ambiente, pois são compostos apenas por gases naturais.",
        "Combustíveis fósseis liberam gás oxigênio, o que ajuda na preservação ambiental.",
        "Combustíveis fósseis não contribuem para a poluição, já que não emitem substâncias tóxicas para a atmosfera."
    },
    new string[]
    {
        "Energias renováveis são fontes de energia que podem ser reabastecidas naturalmente, como solar, eólica e hidrelétrica. A química contribui para o desenvolvimento dessas fontes ao criar materiais eficientes para conversão de energia.",
        "Energias renováveis são fontes de energia derivadas de combustíveis fósseis, como carvão e petróleo.",
        "Energias renováveis não possuem impacto ambiental, pois são fontes de energia infinitas.",
        "Energias renováveis não podem ser melhoradas pela química, pois envolvem apenas fontes naturais e não dependem de tecnologias."
    }
};

    private Random random;

    void Start()
    {
        random = new Random();


        // Seleciona uma pergunta aleatória
        int numeroAleatorio = random.Next(0, listaDePerguntas.Length);
        Debug.Log(listaDePerguntas[numeroAleatorio]);

        // Cria uma cópia das respostas para a pergunta sorteada
        string[] respostas = (string[])listaDeRespostas[numeroAleatorio].Clone();

        // Embaralha as respostas utilizando o algoritmo de Fisher-Yates
        for (int i = respostas.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            string temp = respostas[i];
            respostas[i] = respostas[j];
            respostas[j] = temp;
        }

        // Exibe as respostas embaralhadas
        foreach (string resposta in respostas)
        {
            Debug.Log(resposta);
        }
    }
}