using System;
using System.Collections.Generic;
using System.Linq;

namespace HuffmanCoding
{
    class Node
    {
        public char Character { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string inputText = "Le Thi Huyen Trang"; 

            Dictionary<char, int> charFrequencies = new Dictionary<char, int>();
            foreach (char c in inputText)
            {
                if (charFrequencies.ContainsKey(c))
                    charFrequencies[c]++;
                else
                    charFrequencies[c] = 1;
            }

            List<Node> nodes = charFrequencies.Select(pair => new Node { Character = pair.Key, Frequency = pair.Value }).ToList();

            while (nodes.Count > 1)
            {
                nodes.Sort((a, b) => a.Frequency.CompareTo(b.Frequency));
                Node newNode = new Node
                {
                    Character = '\0',
                    Frequency = nodes[0].Frequency + nodes[1].Frequency,
                    Left = nodes[0],
                    Right = nodes[1]
                };
                nodes.RemoveRange(0, 2);
                nodes.Add(newNode);
            }

            Node root = nodes[0];
            Dictionary<char, string> encodingTable = new Dictionary<char, string>();
            BuildEncodingTable(root, "", encodingTable);

            Console.WriteLine("Character\tFrequency\tHuffman Code");
            foreach (var pair in charFrequencies)
            {
                Console.WriteLine($"{pair.Key}\t\t{pair.Value}\t\t{encodingTable[pair.Key]}");
            }
        }

        static void BuildEncodingTable(Node node, string code, Dictionary<char, string> encodingTable)
        {
            if (node.Left == null && node.Right == null)
            {
                encodingTable[node.Character] = code;
                return;
            }
            BuildEncodingTable(node.Left, code + "0", encodingTable);
            BuildEncodingTable(node.Right, code + "1", encodingTable);
        }
    }
}
