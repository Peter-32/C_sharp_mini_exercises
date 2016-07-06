using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//// TO DO:
// Create example nodes & edges
// Create a method that takes user input and it passes commands to the controller
// test the user input
// add simple rendering view
// set up access rights, maybe local or something
// make into a ddl file
namespace Data_Structure_for_Graphs
{
    public class Program
    {
        // Nodes can be independent from edges
        // Edges are required to attach to nodes
        static void Main(string[] args)
        {
            Controller.createNode("Carl", 0, 0);
            Controller.createNode("James", 1, 0);
            Controller.createNode("Tom", 1, 1);
            Controller.createNode("Janet", 2, 1);
            //Controller.
            Console.ReadKey();
        }
    }

    public static class Switch
    {
        public static bool on
        {
            get;
            set;
        } = true;
    }

    public static class InputPile
    {
        public static void issueRequest(string request)
        {
            requests.Add(request);
        }

        public static List<string> requests
        {
            get;
            set;
        } = new List<string>();
    }

    public static class Controller
    {
        //// METHODS

        // CRUD Node
        public static void createNode(string key, int xLocation, int yLocation)
        {
            Node.Create(key, xLocation, yLocation);
        }

        public static Node selectNode(string searchKey)
        {
            foreach (var element in Model.nodeList)
            {
                if (element.key == searchKey)
                    return element;
            }
            Console.WriteLine("Tried to select a node but no such node exists");
            return null;
        }

        public static void modifyNode(Node node, string key, int xLocation, int yLocation)
        {
            node.key = key;
            node.xLocation = xLocation;
            node.yLocation = yLocation;
        }

        public static void deleteNode(Node node)
        {
            Model.dictionary.Remove(node);
            Model.nodeList.Remove(node);
        }

        // CRUD Edge
        public static void createEdge(string key, string description, Node node1, Node node2)
        {
            Edge.Create(key, description, node1, node2);
        }

        public static Edge selectEdge(string searchKey)
        {
            foreach (var element in Model.edgeList)
            {
                if (element.key == searchKey)
                    return element;
            }
            Console.WriteLine("Tried to select an edge but no such edge exists");
            return null;
        }

        public static void modifyEdge(Edge edge, string key, string description, Node node1, Node node2)
        {
            edge.description = description;
            edge.key = key;
            edge.node1 = node1;
            edge.node2 = node2;
        }

        public static void deleteEdge(Edge edge)
        {
            Model.dictionary[edge.node1].Remove(edge);
            Model.dictionary[edge.node2].Remove(edge);
            Model.edgeList.Remove(edge);
        }

        // Validation methods
        public static bool isUniqueNodeKey(string checkKey)
        {
            int nodeListLength = Model.nodeList.Count();
            for (var i = 0; i < nodeListLength; i++)
            {
                if (checkKey == Model.nodeList[i].key)
                    return false;
            }
            return true;
        }
        public static bool isUniqueEdgeKey(string checkKey)
        {
            int edgeListLength = Model.edgeList.Count();
            for (var i = 0; i < edgeListLength; i++)
            {
                if (checkKey == Model.edgeList[i].key)
                    return false;
            }
            return true;
        }

        // Graph associations, what is attached to each other
        public static List<Edge> selectEdges(Node queryNode)
        {
            return Model.dictionary[queryNode];
        }
        
        public static List<Node> selectNearestNodes(Node queryNode)
        {
            List<Node> nodes = new List<Node>();
            foreach (var edge in Model.dictionary[queryNode])
            {
                if (edge.node1 != queryNode) // then it is a new node
                    nodes.Add(edge.node1);
                if (edge.node2 != queryNode) // then it is a new node
                    nodes.Add(edge.node1);
            }
            return nodes.Distinct().ToList(); // remove any duplication, then return the node list
        }
    }

    public static class Model
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
    }

    public class Node
    {
        // CONSTRUCTORS
        private Node(string key, int xLocation, int yLocation)
        {
            this.key = key;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
        }

        public static void Create(string key, int xLocation, int yLocation)
        {
            if (Controller.isUniqueNodeKey(key))
            {
                Node newNode = new Node(key, xLocation, yLocation);
                // The graphing controller needs to update the node list
                Model.nodeList.Add(newNode);
                // The graphing controller needs to update its dictionary
                Model.dictionary.Add(newNode, new List<Edge>());
                return;
            }
            else
            {
                Console.WriteLine("Failed to create node.  Not a unique key.");
                return;
            }
        }
        // PROPERTIES
        public string key
        {
            get;
            set;
        }
        
        public int xLocation
        {
            get;
            set;
        }

        public int yLocation
        {
            get;
            set;
        }

        // METHODS
        public override string ToString()
        {
            return String.Concat("Node ", key, " - At location (", xLocation, ",", yLocation, ")");
        }
    }

    public class Edge
    {
        // CONSTRUCTORS
        private Edge(string key, string description, Node node1, Node node2)
        {
            this.description = description;
            this.key = key;
            this.node1 = node1;
            this.node2 = node2;
        }

        public static void Create(string key, string description, Node node1, Node node2)
        {
            if (Controller.isUniqueEdgeKey(key))
            {
                Edge newEdge = new Edge(key, description, node1, node2);
                // The graphing controller needs to update the edge list
                Model.edgeList.Add(newEdge);
                // The graphing controller needs to update its dictionary twice
                Model.dictionary[node1].Add(newEdge);
                Model.dictionary[node2].Add(newEdge);

                return;
            }
            else
            {
                Console.WriteLine("Failed to create edge.  Not a unique key.");
                return;
            }
        }

        // PROPERTIES
        public string description
        {
            get;
            set;
        }
        public string key
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
            return String.Concat("Edge ", key, " - ", description);
        }

    }
}