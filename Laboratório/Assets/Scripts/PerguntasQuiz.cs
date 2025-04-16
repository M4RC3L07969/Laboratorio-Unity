using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PerguntasQuiz : MonoBehaviour
{
    private String[] listaDePerguntas = new String[45] {"O que s�o �tomos e mol�culas?",
            "Qual a diferen�a entre subst�ncias puras e misturas?",
            "O que caracteriza uma mudan�a f�sica e uma mudan�a qu�mica?",
            "Quais s�o os estados f�sicos da mat�ria?",
            "O que � a tabela peri�dica e como ela est� organizada?",
            "O que s�o metais, ametais e gases nobres?",
            "Qual a diferen�a entre subst�ncias simples e compostas?",
            "O que s�o rea��es qu�micas? D� um exemplo.",
            "O que � um elemento qu�mico?",
            "O que s�o �cidos e bases?",
            "O que s�o liga��es i�nicas e covalentes?",
            "Como ocorre a liga��o met�lica?",
            "O que � eletronegatividade e como ela influencia as liga��es qu�micas?",
            "Qual a diferen�a entre rea��es endot�rmicas e exot�rmicas?",
            "O que s�o coeficientes estequiom�tricos?",
            "O que � um mol e qual sua rela��o com a constante de Avogadro?",
            "Como se classificam as fun��es inorg�nicas (�cidos, bases, sais e �xidos)?",
            "O que s�o solu��es e quais s�o suas classifica��es?",
            "Como calcular a concentra��o de uma solu��o?",
            "O que � a lei da conserva��o da massa de Lavoisier?",
            "Como balancear uma equa��o qu�mica?",
            "Qual a import�ncia do pH e como ele � calculado?",
            "O que s�o rea��es de oxida��o e redu��o?",
            "O que � cin�tica qu�mica e quais fatores influenciam a velocidade de uma rea��o?",
            "O que � catalisador e qual seu papel nas rea��es qu�micas?",
            "Como funcionam os equil�brios qu�micos?",
            "O que � a constante de equil�brio (Kc)?",
            "Como a press�o e a temperatura afetam um equil�brio qu�mico?",
            "O que diz o princ�pio de Le Chatelier?",
            "O que s�o rea��es revers�veis e irrevers�veis?",
            "O que � solubilidade e quais fatores a influenciam?",
            "O que � eletroqu�mica e como funcionam as pilhas eletroqu�micas?",
            "Qual a diferen�a entre eletr�lise �gnea e eletr�lise aquosa?",
            "O que � qu�mica org�nica e qual sua import�ncia?",
            "O que s�o hidrocarbonetos e como s�o classificados?",
            "O que s�o grupos funcionais na qu�mica org�nica?",
            "O que � isomeria e quais s�o seus tipos?",
            "Como funcionam as rea��es de substitui��o, adi��o e elimina��o?",
            "O que � polimeriza��o e quais s�o os principais tipos de pol�meros?",
            "O que s�o biomol�culas e qual sua import�ncia para a vida?",
            "O que � a radioatividade e como ela foi descoberta?",
            "Como funcionam as rea��es nucleares de fiss�o e fus�o?",
            "O que s�o os gases do efeito estufa e qual seu impacto ambiental?",
            "Como os combust�veis f�sseis afetam o meio ambiente?",
            "O que s�o energias renov�veis e como a qu�mica contribui para seu desenvolvimento?"};

    string[][] listaDeRespostas = new string[][]
{
    new string[]
    {
        "�tomos s�o as menores unidades de elementos qu�micos, compostos por pr�tons, n�utrons e el�trons. Mol�culas s�o formadas por �tomos ligados entre si, podendo ser compostos por �tomos do mesmo ou de diferentes elementos.",
        "�tomos s�o part�culas indivis�veis que formam as mol�culas. Mol�culas s�o �tomos que n�o podem ser divididos.",
        "�tomos s�o part�culas que se ligam a outros �tomos para formar mol�culas. Mol�culas podem existir sozinhas ou em grupos.",
        "�tomos e mol�culas s�o a mesma coisa, sendo apenas diferentes em tamanho."
    },
    new string[]
    {
        "Subst�ncias puras s�o compostas por apenas um tipo de �tomo ou mol�cula. As misturas s�o formadas por dois ou mais componentes diferentes.",
        "Subst�ncias puras podem ser compostas por v�rios tipos de mol�culas, enquanto misturas cont�m apenas um tipo de �tomo.",
        "As subst�ncias puras podem ser alteradas em suas propriedades, mas as misturas sempre mant�m as propriedades do material original.",
        "Subst�ncias puras podem ser separadas em misturas, mas misturas n�o podem ser formadas a partir de subst�ncias puras."
    },
    new string[]
    {
        "Mudan�as f�sicas alteram as caracter�sticas de uma subst�ncia sem modificar sua composi��o qu�mica. J� as mudan�as qu�micas alteram a estrutura molecular da subst�ncia, resultando em novos produtos.",
        "Mudan�as f�sicas resultam na forma��o de novas subst�ncias, enquanto mudan�as qu�micas n�o alteram a subst�ncia original.",
        "Mudan�as f�sicas n�o alteram a subst�ncia, mas mudan�as qu�micas alteram as propriedades f�sicas tamb�m.",
        "Mudan�as f�sicas envolvem apenas a altera��o de temperatura e press�o, enquanto mudan�as qu�micas ocorrem apenas em subst�ncias l�quidas."
    },
    new string[]
    {
        "Os estados f�sicos da mat�ria s�o s�lido, l�quido e gasoso. O plasma � considerado o quarto estado da mat�ria.",
        "Os estados f�sicos da mat�ria s�o s�lidos, l�quidos, gasosos e radioativos.",
        "Os estados f�sicos da mat�ria incluem apenas os s�lidos e l�quidos.",
        "Os estados da mat�ria n�o incluem o gasoso, pois as mol�culas sempre se encontram unidas."
    },
    new string[]
    {
        "A tabela peri�dica organiza os elementos qu�micos de acordo com suas propriedades e suas massas at�micas, com os elementos semelhantes dispostos em colunas chamadas grupos.",
        "A tabela peri�dica organiza os elementos qu�micos pela ordem de descoberta, sem levar em considera��o suas propriedades.",
        "A tabela peri�dica � organizada apenas pelos elementos met�licos e seus compostos.",
        "A tabela peri�dica � organizada por cor e formato das mol�culas."
    },
    new string[]
    {
        "Metais s�o bons condutores de eletricidade e calor, enquanto ametais s�o isolantes. Gases nobres s�o elementos est�veis, encontrados na �ltima coluna da tabela peri�dica.",
        "Metais s�o s�lidos que n�o conduzem eletricidade, ametais s�o l�quidos e gases nobres s�o altamente reativos.",
        "Metais e ametais possuem as mesmas propriedades e os gases nobres n�o fazem parte da tabela peri�dica.",
        "Metais s�o elementos radioativos, ametais s�o compostos org�nicos e gases nobres s�o compostos de hidrog�nio e oxig�nio."
    },
    new string[]
    {
        "Subst�ncias simples s�o formadas por �tomos de um �nico elemento, enquanto subst�ncias compostas s�o formadas por �tomos de dois ou mais elementos.",
        "Subst�ncias simples s�o compostas apenas por elementos met�licos, enquanto compostas podem ter apenas n�o metais.",
        "Subst�ncias simples t�m mais de um �tomo, enquanto compostas t�m apenas um.",
        "Subst�ncias simples s�o aquelas que n�o podem ser combinadas para formar compostos."
    },
    new string[]
    {
        "Rea��es qu�micas s�o processos em que os reagentes se transformam em produtos, com a quebra ou forma��o de novas liga��es. Exemplo: a queima de combust�vel.",
        "Rea��es qu�micas ocorrem apenas em subst�ncias l�quidas, sem a forma��o de novos compostos.",
        "Rea��es qu�micas s�o processos f�sicos em que os produtos mant�m as mesmas propriedades dos reagentes.",
        "Rea��es qu�micas n�o alteram a estrutura das mol�culas envolvidas, apenas as suas propriedades f�sicas."
    },
    new string[]
    {
        "Um elemento qu�mico � uma subst�ncia que n�o pode ser decomposta em subst�ncias mais simples. Cada elemento � definido pelo n�mero de pr�tons no n�cleo de seus �tomos.",
        "Um elemento qu�mico � um tipo de subst�ncia composta por dois ou mais �tomos.",
        "Elementos qu�micos s�o formados apenas por mol�culas que cont�m o mesmo n�mero de �tomos.",
        "Elementos qu�micos s�o subst�ncias que podem ser decompostas em outras subst�ncias mais simples."
    },
    new string[]
    {
        "�cidos s�o subst�ncias que liberam �ons de hidrog�nio (H+) em solu��o, enquanto bases liberam �ons hidr�xido (OH-).",
        "�cidos s�o subst�ncias que liberam �ons de oxig�nio (O-) em solu��o, enquanto bases liberam apenas �ons negativos.",
        "�cidos e bases s�o subst�ncias neutras e n�o reagem entre si.",
        "�cidos s�o subst�ncias que liberam �ons de hidrog�nio (H-) e bases liberam c�tions."
    },
    new string[]
    {
        "Liga��es i�nicas ocorrem entre metais e ametais, com transfer�ncia de el�trons. Liga��es covalentes ocorrem entre ametais, com o compartilhamento de el�trons.",
        "Liga��es i�nicas ocorrem entre dois ametais e envolvem o compartilhamento de el�trons.",
        "Liga��es covalentes ocorrem entre metais e ametais, e envolvem a troca de el�trons.",
        "Liga��es covalentes n�o envolvem �tomos, mas sim a uni�o de part�culas de diferentes subst�ncias."
    },
    new string[]
    {
        "A liga��o met�lica � formada por �tomos de metais que compartilham seus el�trons de forma livre, formando uma rede de c�tions.",
        "A liga��o met�lica � formada por �tomos n�o met�licos que se unem atrav�s de uma camada densa de el�trons.",
        "A liga��o met�lica ocorre apenas em compostos org�nicos.",
        "A liga��o met�lica � a intera��o entre pr�tons e el�trons em compostos gasosos."
    },
    new string[]
    {
        "Eletronegatividade � a tend�ncia de um �tomo atrair el�trons em uma liga��o qu�mica. Quanto maior a eletronegatividade, mais forte � a atra��o pelos el�trons compartilhados.",
        "Eletronegatividade � a capacidade de um �tomo doar el�trons em uma liga��o.",
        "Eletronegatividade � a tend�ncia de um �tomo repulsar outros �tomos, dificultando a forma��o de liga��es.",
        "Eletronegatividade � uma propriedade que s� afeta as rea��es qu�micas de �tomos met�licos."
    },
    new string[]
    {
        "Rea��es endot�rmicas absorvem calor do ambiente, enquanto rea��es exot�rmicas liberam calor.",
        "Rea��es endot�rmicas liberam calor, enquanto as exot�rmicas absorvem calor.",
        "As rea��es endot�rmicas e exot�rmicas s�o as mesmas, apenas com nomes diferentes.",
        "Rea��es endot�rmicas s�o rea��es que n�o alteram a temperatura do ambiente."
    },
    new string[]
    {
        "Coeficientes estequiom�tricos indicam a quantidade de reagentes e produtos em uma equa��o qu�mica balanceada, garantindo a conserva��o de �tomos.",
        "Coeficientes estequiom�tricos indicam a quantidade de energia necess�ria para uma rea��o ocorrer.",
        "Coeficientes estequiom�tricos indicam apenas a temperatura necess�ria para que a rea��o aconte�a.",
        "Coeficientes estequiom�tricos referem-se apenas � concentra��o de reagentes em uma rea��o."
    },
    new string[]
    {
        "Um mol � a quantidade de subst�ncia que cont�m o n�mero de Avogadro (aproximadamente 6,022 x 10^23 unidades), que corresponde a um n�mero fixo de entidades elementares.",
        "Um mol � a quantidade de uma subst�ncia que tem massa igual a 1 grama.",
        "Um mol � o n�mero de mol�culas de uma subst�ncia que interage em uma rea��o qu�mica.",
        "Um mol corresponde � quantidade de elementos em uma mol�cula de �gua."
    },
    new string[]
    {
        "As fun��es inorg�nicas s�o classificadas em �cidos, bases, sais e �xidos, de acordo com suas propriedades qu�micas e sua composi��o.",
        "As fun��es inorg�nicas s�o classificadas apenas em �cidos e bases.",
        "As fun��es inorg�nicas envolvem apenas a combina��o de gases.",
        "As fun��es inorg�nicas n�o incluem os �xidos ou sais em sua classifica��o."
    },
    new string[]
    {
        "Solu��es s�o misturas homog�neas compostas por um soluto e um solvente. Elas podem ser classificadas como saturadas ou insaturadas, dependendo da quantidade de soluto dissolvido.",
        "Solu��es s�o sempre compostos por apenas um tipo de soluto.",
        "Solu��es podem ser formadas apenas em estado s�lido.",
        "Solu��es s�o misturas onde os solutos podem ser facilmente separados por filtra��o."
    },
    new string[]
    {
        "A concentra��o de uma solu��o � calculada dividindo-se a quantidade de soluto pela quantidade de solu��o. Pode ser expressa em mol/L (molaridade), entre outras unidades.",
        "A concentra��o de uma solu��o � calculada dividindo-se a quantidade de solvente pela quantidade de soluto.",
        "A concentra��o de uma solu��o � sempre 1 mol/L, independentemente da quantidade de soluto.",
        "A concentra��o de uma solu��o depende apenas da temperatura e press�o."
    },
    new string[]
    {
        "A Lei da Conserva��o da Massa de Lavoisier afirma que a massa total dos reagentes em uma rea��o qu�mica � igual � massa total dos produtos.",
        "A Lei da Conserva��o da Massa de Lavoisier afirma que a massa dos produtos � sempre maior do que a dos reagentes.",
        "A Lei de Lavoisier afirma que a massa total � perdida em rea��es qu�micas.",
        "A Lei da Conserva��o da Massa de Lavoisier s� se aplica a rea��es que ocorrem a temperatura constante."
    },
    new string[]
    {
        "Balancear uma equa��o qu�mica envolve ajustar os coeficientes para garantir que o n�mero de �tomos de cada elemento seja o mesmo dos dois lados da equa��o.",
        "Balancear uma equa��o qu�mica envolve alterar os n�meros de �tomos, mas sem se preocupar com a quantidade de cada subst�ncia.",
        "Balancear uma equa��o qu�mica envolve apenas equilibrar as massas das subst�ncias.",
        "Balanceamento de equa��es qu�micas � feito alterando os valores das massas, mas n�o o n�mero de �tomos."
    },
    new string[]
    {
        "O pH � uma medida da acidez ou basicidade de uma solu��o. Ele � calculado com a f�rmula pH = -log[H+], onde [H+] representa a concentra��o de �ons de hidrog�nio na solu��o.",
        "O pH � calculado com base na concentra��o de mol�culas de oxig�nio em uma solu��o.",
        "O pH � uma medida de temperatura, n�o relacionada � concentra��o de �ons em uma solu��o.",
        "O pH � calculado com a f�rmula pH = -log[OH-], que representa a concentra��o de �ons hidr�xido."
    },
    new string[]
    {
        "Rea��es de oxida��o envolvem a perda de el�trons, enquanto rea��es de redu��o envolvem o ganho de el�trons.",
        "Rea��es de oxida��o e redu��o n�o envolvem el�trons, mas apenas varia��es nas temperaturas das subst�ncias.",
        "Rea��es de oxida��o e redu��o n�o afetam as liga��es qu�micas, apenas as propriedades f�sicas.",
        "Rea��es de oxida��o e redu��o ocorrem apenas com compostos org�nicos."
    },
    new string[]
    {
        "A cin�tica qu�mica estuda a velocidade das rea��es qu�micas e os fatores que influenciam essa velocidade, como temperatura, concentra��o dos reagentes e presen�a de catalisadores.",
        "A cin�tica qu�mica estuda apenas a forma��o de produtos, sem considerar a velocidade das rea��es.",
        "A cin�tica qu�mica trata da quantidade de energia liberada durante as rea��es, sem considerar os fatores que alteram a velocidade.",
        "A cin�tica qu�mica � relacionada apenas ao equil�brio das rea��es, n�o �s rea��es em si."
    },
    new string[]
    {
        "Catalisadores s�o subst�ncias que aceleram as rea��es qu�micas, proporcionando um caminho alternativo de menor energia de ativa��o, sem serem consumidos no processo.",
        "Catalisadores s�o subst�ncias que diminuem a velocidade das rea��es qu�micas, tornando-as mais est�veis.",
        "Catalisadores aumentam a quantidade de energia necess�ria para a rea��o ocorrer.",
        "Catalisadores reagem com os produtos, transformando-os em novas subst�ncias durante o processo."
    },
    new string[]
    {
        "Equil�brios qu�micos ocorrem quando as rea��es qu�micas revers�veis atingem uma situa��o onde as concentra��es dos reagentes e produtos permanecem constantes.",
        "Equil�brios qu�micos s�o situa��es em que as rea��es param de ocorrer, e n�o h� mais intera��o entre os reagentes.",
        "Equil�brios qu�micos s�o processos onde os reagentes se convertem completamente em produtos.",
        "Equil�brios qu�micos s� ocorrem em solu��es aquosas, e n�o em rea��es gasosas ou s�lidas."
    },
    new string[]
    {
        "A constante de equil�brio (Kc) � uma constante que descreve a rela��o entre as concentra��es dos produtos e reagentes em equil�brio, para uma rea��o espec�fica a uma temperatura constante.",
        "A constante de equil�brio (Kc) descreve a quantidade de calor liberado durante uma rea��o.",
        "A constante de equil�brio (Kc) refere-se apenas � quantidade de catalisadores presentes em uma rea��o.",
        "A constante de equil�brio (Kc) � determinada apenas pela press�o e n�o pela concentra��o dos reagentes."
    },
    new string[]
    {
        "A press�o e a temperatura afetam um equil�brio qu�mico, pois mudan�as nessas vari�veis podem favorecer a forma��o de produtos ou reagentes, alterando as concentra��es no equil�brio.",
        "A press�o e a temperatura n�o afetam o equil�brio qu�mico, pois os reagentes sempre se transformam em produtos na mesma propor��o.",
        "A press�o e a temperatura apenas afetam a quantidade de catalisadores em uma rea��o de equil�brio.",
        "A press�o e a temperatura alteram a velocidade de uma rea��o, mas n�o o equil�brio entre os reagentes e produtos."
    },
    new string[]
    {
        "O princ�pio de Le Chatelier afirma que, quando um sistema em equil�brio � perturbado, ele tende a se ajustar para minimizar a mudan�a e restabelecer o equil�brio.",
        "O princ�pio de Le Chatelier afirma que, quando um sistema em equil�brio � perturbado, ele tende a acelerar a rea��o at� que a mudan�a seja maximizada.",
        "O princ�pio de Le Chatelier s� se aplica a rea��es revers�veis e n�o a processos que envolvem catalisadores.",
        "O princ�pio de Le Chatelier n�o afeta o equil�brio entre os reagentes, apenas a concentra��o dos produtos."
    },
    new string[]
    {
        "Rea��es revers�veis s�o aquelas que podem ocorrer nos dois sentidos, enquanto rea��es irrevers�veis s�o aquelas que v�o de reagentes a produtos e n�o podem retornar.",
        "Rea��es revers�veis podem ocorrer apenas em solu��es l�quidas e nunca em estados s�lidos.",
        "Rea��es revers�veis e irrevers�veis s�o o mesmo tipo de rea��o, com apenas uma diferen�a na velocidade.",
        "Rea��es revers�veis s�o aquelas em que os produtos n�o podem se transformar novamente em reagentes."
    },
    new string[]
    {
        "Solubilidade � a capacidade de uma subst�ncia se dissolver em um solvente. Fatores como temperatura, press�o e natureza do solvente afetam a solubilidade.",
        "Solubilidade � uma propriedade constante e n�o � influenciada por temperatura ou press�o.",
        "Solubilidade depende apenas do tipo de solvente, independentemente das caracter�sticas da subst�ncia.",
        "Solubilidade � a quantidade de g�s que uma subst�ncia pode liberar na forma s�lida."
    },
    new string[]
    {
        "Eletroqu�mica � a �rea da qu�mica que estuda as rea��es que envolvem a transfer�ncia de el�trons, como as pilhas e as rea��es de eletr�lise.",
        "Eletroqu�mica estuda apenas as rea��es gasosas, sem envolvimento de eletricidade.",
        "Eletroqu�mica n�o se refere a pilhas ou rea��es redox, mas ao estudo de compostos com alta condutividade el�trica.",
        "Eletroqu�mica estuda apenas rea��es que ocorrem em temperaturas muito altas."
    },
    new string[]
    {
        "A eletr�lise �gnea ocorre quando compostos s�lidos fundidos s�o decompostos por corrente el�trica, enquanto a eletr�lise aquosa ocorre em solu��es l�quidas de compostos.",
        "A eletr�lise �gnea ocorre em solu��es aquosas, enquanto a eletr�lise aquosa � realizada em subst�ncias s�lidas.",
        "A eletr�lise �gnea n�o envolve corrente el�trica, mas apenas alta press�o.",
        "A eletr�lise aquosa envolve a decomposi��o de gases nobres, enquanto a �gnea envolve apenas metais."
    },
    new string[]
    {
        "A qu�mica org�nica estuda os compostos de carbono e suas rea��es, sendo essencial para a produ��o de pl�sticos, medicamentos, alimentos e combust�veis.",
        "A qu�mica org�nica estuda os compostos inorg�nicos e suas propriedades f�sicas.",
        "A qu�mica org�nica � a �rea que estuda apenas os �cidos e bases.",
        "A qu�mica org�nica se concentra apenas em subst�ncias s�lidas e n�o l�quidas ou gasosas."
    },
    new string[]
    {
        "Hidrocarbonetos s�o compostos formados exclusivamente por carbono e hidrog�nio. Eles s�o classificados como alcanos, alcenos, alcinos e arom�ticos, dependendo das liga��es entre os �tomos.",
        "Hidrocarbonetos s�o compostos formados apenas por carbono, oxig�nio e hidrog�nio.",
        "Hidrocarbonetos s�o compostos que cont�m apenas �tomos de carbono.",
        "Hidrocarbonetos s�o compostos encontrados exclusivamente em combust�veis f�sseis, sem outras fontes."
    },
    new string[]
    {
        "Grupos funcionais s�o grupos espec�ficos de �tomos em mol�culas org�nicas que determinam suas propriedades e reatividade, como os �cidos carbox�licos, �lcoois, �steres, etc.",
        "Grupos funcionais s�o partes de mol�culas que n�o influenciam suas rea��es qu�micas.",
        "Grupos funcionais s�o os compostos formados durante a rea��o de substitui��o.",
        "Grupos funcionais s�o apenas combina��es de �tomos de carbono em mol�culas."
    },
    new string[]
    {
        "Isomeria � a propriedade que permite a exist�ncia de compostos com a mesma f�rmula molecular, mas com arranjos diferentes de �tomos. Existem is�meros estruturais e espaciais.",
        "Isomeria � a diferen�a entre dois compostos com diferentes f�rmulas qu�micas, mas com propriedades f�sicas semelhantes.",
        "Isomeria ocorre apenas entre subst�ncias que t�m a mesma f�rmula estrutural.",
        "Isomeria � a forma��o de mol�culas com a mesma f�rmula, mas que n�o t�m propriedades qu�micas similares."
    },
    new string[]
    {
        "Rea��es de substitui��o, adi��o e elimina��o s�o tipos de rea��es org�nicas. Na substitui��o, um �tomo ou grupo � substitu�do; na adi��o, dois �tomos ou grupos s�o adicionados; na elimina��o, um grupo � removido.",
        "Rea��es de substitui��o e adi��o n�o envolvem a quebra de liga��es, enquanto rea��es de elimina��o n�o envolvem a forma��o de novas liga��es.",
        "Rea��es de substitui��o e elimina��o sempre envolvem a forma��o de compostos mais est�veis.",
        "Rea��es de substitui��o, adi��o e elimina��o n�o s�o comuns em rea��es org�nicas."
    },
    new string[]
    {
        "Polimeriza��o � o processo de forma��o de pol�meros a partir de mon�meros, podendo ser do tipo adi��o ou condensa��o.",
        "Polimeriza��o � o processo de decomposi��o de pol�meros em mon�meros.",
        "Polimeriza��o ocorre apenas em compostos de carbono, sem envolver outros �tomos.",
        "Polimeriza��o � a rea��o entre metais e �cidos, sem envolver mol�culas org�nicas."
    },
    new string[]
    {
        "Biomol�culas s�o mol�culas essenciais para os processos biol�gicos, como carboidratos, lip�dios, prote�nas e �cidos nucleicos. Elas s�o fundamentais para a vida.",
        "Biomol�culas s�o mol�culas formadas apenas por elementos met�licos, como ferro e cobre.",
        "Biomol�culas s�o compostos que se formam durante as rea��es de combust�o.",
        "Biomol�culas n�o s�o fundamentais para os seres vivos, mas s�o encontradas em subst�ncias sint�ticas."
    },
    new string[]
    {
        "Radioatividade � a emiss�o espont�nea de radia��o por �tomos inst�veis, como o ur�nio e o r�dio. Ela foi descoberta por Marie e Pierre Curie.",
        "Radioatividade � a radia��o emitida apenas por �tomos de oxig�nio.",
        "Radioatividade � a capacidade dos �tomos de emitir luz vis�vel.",
        "Radioatividade � um fen�meno que ocorre apenas em materiais s�lidos."
    },
    new string[]
    {
        "Fiss�o nuclear � o processo em que o n�cleo de um �tomo se divide, liberando energia, enquanto a fus�o nuclear � a jun��o de dois n�cleos para formar um mais pesado, tamb�m liberando energia.",
        "A fiss�o nuclear n�o libera energia, enquanto a fus�o � respons�vel pela produ��o de radia��o.",
        "A fiss�o nuclear � a jun��o de �tomos, e a fus�o � a divis�o dos �tomos.",
        "A fiss�o e fus�o nuclear n�o t�m rela��o com a libera��o de energia, mas apenas com a separa��o de �tomos."
    },
    new string[]
    {
        "Os gases do efeito estufa, como di�xido de carbono, metano e �xidos de nitrog�nio, contribuem para o aquecimento global ao prenderem calor na atmosfera.",
        "Os gases do efeito estufa s�o inofensivos, pois n�o alteram a temperatura do planeta.",
        "Os gases do efeito estufa s� afetam os oceanos e n�o t�m impacto sobre o clima.",
        "Gases do efeito estufa s�o formados por elementos como oxig�nio e nitrog�nio, que ajudam na resfriamento da atmosfera."
    },
    new string[]
    {
        "Combust�veis f�sseis, como petr�leo e carv�o, liberam gases de efeito estufa, como di�xido de carbono, que contribuem para o aquecimento global e mudan�as clim�ticas.",
        "Combust�veis f�sseis n�o afetam o meio ambiente, pois s�o compostos apenas por gases naturais.",
        "Combust�veis f�sseis liberam g�s oxig�nio, o que ajuda na preserva��o ambiental.",
        "Combust�veis f�sseis n�o contribuem para a polui��o, j� que n�o emitem subst�ncias t�xicas para a atmosfera."
    },
    new string[]
    {
        "Energias renov�veis s�o fontes de energia que podem ser reabastecidas naturalmente, como solar, e�lica e hidrel�trica. A qu�mica contribui para o desenvolvimento dessas fontes ao criar materiais eficientes para convers�o de energia.",
        "Energias renov�veis s�o fontes de energia derivadas de combust�veis f�sseis, como carv�o e petr�leo.",
        "Energias renov�veis n�o possuem impacto ambiental, pois s�o fontes de energia infinitas.",
        "Energias renov�veis n�o podem ser melhoradas pela qu�mica, pois envolvem apenas fontes naturais e n�o dependem de tecnologias."
    }
};

    private Random random;

    void Start()
    {
        random = new Random();


        // Seleciona uma pergunta aleat�ria
        int numeroAleatorio = random.Next(0, listaDePerguntas.Length);
        Debug.Log(listaDePerguntas[numeroAleatorio]);

        // Cria uma c�pia das respostas para a pergunta sorteada
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