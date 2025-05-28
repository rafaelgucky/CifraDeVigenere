/*

0 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25
a  b  c  d  e  f  g  h  i  j  k  l  m  n  o  p  q  r  s  t  u  v  w  x  y  z 

Texto: Segurança da informação
Chave: Uniasselvi

             18      20
Caso 1: letra S chave U
          12
Resultado: m

              04      13
Caso 2: letra E chave n
          17
Resultado: r

Possíveis formas de criação:

1 - Criar a tabela e executar uma simples consulta
2 - Fazer tudo no código - melhor aceita



Análise crítica

1 - Encontrei uma lógica, o resultado é a soma (considerando número máximo 25/26) do número da letra 
da palavra com o número da letra do chave

"mroujsrnv lu vvfgjqlxii"

*/

using PrivateLibrary;

string word = string.Empty;
string key = string.Empty;
string result = string.Empty;
bool encript = false;

Dictionary<char, int> words = new Dictionary<char, int>()
{
    {'a', 0}, {'b', 1}, {'c', 2}, {'d', 3}, {'e', 4}, {'f', 5}, {'g', 6}, {'h', 7},{'i', 8},
    {'j', 9}, {'k', 10}, {'l', 11}, {'m', 12}, {'n', 13}, {'o', 14}, {'p', 15}, {'q', 16},
    {'r', 17}, {'s', 18}, {'t', 19}, {'u', 20}, {'v', 21}, {'w', 22}, {'x', 23}, {'y', 24}, {'z', 25}
};

word = PrivateScreen.ReadString("Escreva a palavra: ");
key = PrivateScreen.ReadString("Informe a chave: ");


Console.WriteLine("1 - Cifrar");
Console.WriteLine("2 - Decifrar");
encript = PrivateScreen.ReadInt(1, 2, "Digite a opção: ") == 1 ? true : false;

int counter = 0;

for (int i = 0; i < word.Length; i++)
{
    if (word[i] == ' ')
    {
        result += ' ';
        continue;
    }

    int sum = 0;
    if (encript) sum = words[word[i]] + words[key[counter]] > 25 ? words[word[i]] + words[key[counter]] - 26 : words[word[i]] + words[key[counter]];
    else {sum = words[word[i]] - words[key[counter]] < 0 ? 26 - (words[key[counter]] - words[word[i]]) : words[word[i]] - words[key[counter]];}

    foreach (KeyValuePair<char, int> pair in words)
    {
        if (pair.Value == sum)
        {
            result += pair.Key;
        }
    }
    if (++counter >= key.Length)
    {
        counter = 0;
    }
}

Console.WriteLine(result);