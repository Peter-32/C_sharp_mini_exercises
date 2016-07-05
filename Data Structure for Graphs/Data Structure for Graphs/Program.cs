using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//// TO DO:
// verify everything is looking okay
// refactor
// Create insertion, deletion, modification abilities in the controller
// Think of methods to add (Primarily to the controller
// Add method: hasRelationship(node1, node2)
// Update ToString methods
// Create example nodes & edges
// Create a method that takes user input and it passes commands to the controller













namespace Data_Structure_for_Graphs
{
    public class Program
    {
        // Nodes can be independent from edges
        // Edges are required to attach to nodes
        static void Main(string[] args)
        {
            Dictionary<Node, List<Edge>> dictionary = new Dictionary<Node, List<Edge>>();
            Node node1Test = new Node("test", 0);
            Node node2Test = new Node("test2", 0);
            dictionary.Add(node1Test, new List<Edge>());
            Edge edge1Test = new Edge("testing dictionary", 1, node1Test, node2Test);
            dictionary[node1Test].Add(edge1Test);
            dictionary[node1Test].Add(edge1Test);
            dictionary[node1Test].ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }

    // You should be able to modify, insert, delete nodes and edges
    public static class GraphingFactory
    { 
        public static Node createNode(string value, int location)
        {
            Node newNode = new Node(value, location);
            // The graphing controller needs to update the node list
            GraphingController.nodeList.Add(newNode);
            // The graphing controller needs to update its dictionary
            GraphingController.dictionary.Add(newNode, new List<Edge>());
            return newNode;
        }

        public static Edge createEdge(string description, double value, Node node1, Node node2)
        {
            Edge newEdge = new Edge(description, value, node1, node2);
            // The graphing controller needs to update the edge list
            GraphingController.edgeList.Add(newEdge);
            // The graphing controller needs to update its dictionary twice
            GraphingController.dictionary[node1].Add(newEdge);
            GraphingController.dictionary[node2].Add(newEdge);
            return newEdge;
        }
    }

    public static class GraphingController
    {
        // PROPERTIES

        // Dictionary: For a node (key), what edges are attached to it (value)?
        public static Dictionary<Node, List<Edge>> dictionary = new Dictionary<Node, List<Edge>>();

        // Keeps the memory location of each node in a list
        public static List<Node> nodeList
        {
            get;
            set;
        } = new List<Node>();

        // Keeps the memory location of each edge in a list
        public static List<Edge> edgeList
        {
            get;
            set;
        } = new List<Edge>();

        // METHODS

    }

    public class Node
    {
        // CONSTRUCTORS
        public Node(string value, int location)
        {
            this.value = value;
            this.location = location;
        }

        // PROPERTIES
        public string value
        {
            get;
            set;
        }
        /* public List<Edge> edgeList
        {
            get;
            set;
        } */
        public int location
        {
            get;
            set;
        }

        // METHODS
        public override string ToString()
        {
            return value + " " + location;
        }
    }

    public class Edge
    {
        // CONSTRUCTORS
        public Edge(string description, double value, Node node1, Node node2)
        {
            this.description = description;
            this.value = value;
            this.node1 = node1;
            this.node2 = node2;
        }

        // PROPERTIES
        public string description
        {
            get;
            set;
        }
        public double value
        {
            get;
            set;
        }
        public Node node1
        {
            get;
            set;
        }
        public Node node2
        {
            get;
            set;
        }

        // METHODS
        public override string ToString()
        {
            return description + " " + value;
        }

    }
}