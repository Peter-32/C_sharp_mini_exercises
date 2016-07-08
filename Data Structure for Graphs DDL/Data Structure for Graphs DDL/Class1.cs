using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Data_Structure_for_Graphs_DDL
{
    //// TO DO:
    // Create a method that takes user input and it passes commands to the controller
    // test the user input
    // add simple rendering view
    // set up access rights, maybe local or something
    // make into a ddl file       

    class Program
    {
        static void Main(string[] args)
        {
            PromptInput.mainLoop();
            Console.ReadKey();
        }
    }

    public static class PromptInput
    {
        private static string line = "";
        private static bool exit = false;

        // the main loop
        public static void mainLoop()
        {
            do
            {
                // get input from the user
                //InputPile.enableTransport();
                //TransportForInputToController transport = new TransportForInputToController();
                //transport.beginTransport();
                Console.WriteLine("Please issue a command for the graph input pile.");
                line = Console.ReadLine();
                sendToGraphController(line);
                updateExit(line);
            } while (!exit);
        }

        // issues the request to the graphing ddl
        public static void sendToGraphController(string input)
        {
            Data_Structure_for_Graphs_DDL.Controller.executeRequests(input);
        }

        public static void updateExit(string line)
        {
            if (line == "exit" || line == "quit")
                exit = true;
            else
                exit = false;
        }
    }

    /*
public static class InputPile
{
    public static TransportForInputToController transport = new TransportForInputToController();
    public static List<string> requests
    {
        get;
        set;
    } = new List<string>();
    public static int nextIdxForExecution
    {
        get;
        set;
    } = 0;
    public static int numUnreadRequests = 0;

    // A foreign library supplies a request
    public static void issueRequest(string request)
    {            
        requests.Add(request);
        numUnreadRequests++;
    }
   // gives a request
    public static string getNextRequest()
    {
        string request = requests[nextIdxForExecution];
        nextIdxForExecution++;
        numUnreadRequests--;
        return request;
    }
    // Internally removes an entry from the list
    // Always removes the next request for execution
    public static void disposeOfRequests()
    {
        requests.Clear();
        nextIdxForExecution = 0;
        numUnreadRequests = 0;
    }

    public static void enableTransport()
    {
        transport.beginTransport();
    }

    public static void disableTransport()
    {
        transport.endTransport();
    }
}

// This class will transport input from the input pile to the controller
// this transport can be turned on and off at the input pile
public class TransportForInputToController
{
    private System.Threading.Timer timer;
    private string request;

    public void beginTransport()
    {
        //_timer = new Timer(makeTrip, null, 1000, Timeout.Infinite ); ////////// Ticks once in 1 second
    }

    public void endTransport()
    {
        timer.Dispose();
    }

    private void makeTrip(Object state)
    {
        if (InputPile.numUnreadRequests == 0)  // Check if a trip is needed
            return;
        // The list name is called "requests". 
        request = InputPile.getNextRequest();
        // this will hand the request over to the controller for immediate execution
        Controller.executeRequests(request);
        _timer.Change(1000, Timeout.Infinite); // no concurrency; starts again only once everything before is completed
    }
}
*/

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
            deleteNode(node);
            createNode(key, xLocation, yLocation);
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
            deleteEdge(edge);
            createEdge(key, description, node1, node2);
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
        public static List<Edge> selectLinkedEdges(Node queryNode)
        {
            return Model.dictionary[queryNode];
        }

        public static List<Node> selectNearestLinkedNodes(Node queryNode)
        {
            List<Node> nodes = new List<Node>();
            foreach (var edge in selectLinkedEdges(queryNode))
            {
                if (edge.node1 != queryNode) // then it is a new node
                    nodes.Add(edge.node1);
                if (edge.node2 != queryNode) // then it is a new node
                    nodes.Add(edge.node2);
            }
            return nodes.Distinct().ToList(); // remove any duplication, then return the node list
        }

        // executes the request that comes from the transport
        public static void executeRequests(string input)
        {
            Console.WriteLine(String.Concat("The controller got your request: ", input));
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



