using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure_for_Graphs
{
    public class Program
    {
        // Nodes can be independent from edges
        // Edges are required to attach to nodes
        static void Main(string[] args)
        {


            /* GraphingController.nodeList.Add(GraphingFactory.createNode("Who is the culprit?", 0));
            GraphingController.nodeList.Add(GraphingFactory.createNode("James", 1));
            GraphingController.nodeList.Add(GraphingFactory.createNode("Charlie", 1));
            GraphingController.nodeList.Add(GraphingFactory.createNode("Ryan", 1));
            GraphingController.edgeList.Add(GraphingFactory.createEdge("The culprit might be punctual", .25, nodeList[0], nodeList[1]));
            GraphingController.edgeList.Add(GraphingFactory.createEdge("The culprit might be punctual", .50, nodeList[0], nodeList[2]));
            GraphingController.edgeList.Add(GraphingFactory.createEdge("The culprit might be punctual", .25, nodeList[0], nodeList[3])); */
            Console.ReadKey();
        }
    }

    // You should be able to modify, insert, delete nodes and edges
    public static class GraphingFactory
    { 
        public static Node createNode(string value, int location)
        {
            Node newNode = new Node(value, location);
            GraphingController.dictionary.Add(newNode, new List<Edge>());
            return newNode;
        }

        public static Edge createEdge(string description, double value, Node node1, Node node2)
        {
            Edge newEdge = new Edge(description, value, node1, node2);
            GraphingController.dictionary[node1].Add(newEdge);
            return newEdge;
        }
    }

    public static class GraphingController
    {
        // PROPERTIES

        // For a node (key), what edges are attached to it (value)?
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

        //////////////////////////// Add methods; insert, modify, delete.  For delete node, remove the node from the node list.  Remove the edges attached to it.
        // when removing edges, remove the reference to those edges in the node's edgeList

        /* public void delete()
        {
            node1.edgeList.Remove(this);
            node2.edgeList.Remove(this);
            GraphingController.
        } */


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
            node1.edgeList.Add(this);
            node2.edgeList.Add(this);
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

    }
}