using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieStructure
{
    // Trie'deki her bir düğümü temsil eden sınıf
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; } // Alt düğümleri saklamak için bir sözlük
        public bool IsEndOfWord { get; set; } // Bir kelimenin sonunu belirten flag

        // Constructor
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            IsEndOfWord = false;
        }
    }

    // Trie yapısını uygulayan sınıf
    public class Trie
    {
        private TrieNode root;

        // Trie sınıfı oluşturulduğunda kök düğümü başlatır.
        public Trie()
        {
            root = new TrieNode();
        }

        // Trie'ye kelime ekler.
        public void Insert(string word)
        {
            TrieNode node = root;
            foreach (char character in word)
            {
                if (!node.Children.ContainsKey(character))
                {
                    // Düğümü oluştur ve Trie'ye ekle.
                    node.Children[character] = new TrieNode();
                }
                node = node.Children[character];
            }
            node.IsEndOfWord = true; // Kelimenin sonu burada.
        }

        // Trie'de kelime arar.
        public bool Search(string word)
        {
            TrieNode node = root;
            foreach (char character in word)
            {
                if (!node.Children.ContainsKey(character))
                {
                    // Karakter bulunamazsa kelime yoktur.
                    return false;
                }
                node = node.Children[character];
            }
            return node.IsEndOfWord; // Kelime bulundu mu kontrol edilir.
        }
    }

    class Program
    {
        static void Main()
        {
            Trie trie = new Trie();
            trie.Insert("data");
            trie.Insert("structures");
            //trie.Insert("projesi"); olmadığı için false gelecek

            // Kelimeleri arama
            Console.WriteLine(trie.Search("data"));         // True
            Console.WriteLine(trie.Search("structures"));     // True
            Console.WriteLine(trie.Search("projesi"));       // False
        }
    }
}