using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Data_Structure_for_Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            PromptInput.mainLoop();
            // Console.ReadKey();
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
                Console.WriteLine("Please issue a command for execution.  Type commands to see the commands.");
                line = Console.ReadLine();

                // execute the request
                Controller.executeRequests(line);
                // check if exit or quit were chosen.
                updateExit(line);
            } while (!exit);
        }

        public static void updateExit(string line)
        {
            if (line == "exit" || line == "quit")
                exit = true;
            else
                exit = false;
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

        // stores the location of the letters of the alphabet on a keyboard
        // top left corners of each key
        public static Dictionary<char, Tuple<int, int>> dictionaryKeyboardXYLocation = new Dictionary<char, Tuple<int, int>>
        {
 {'q', Tuple.Create(0, 6) },
            {'w', Tuple.Create(2, 6) },
            {'e', Tuple.Create(4, 6) },
            {'r', Tuple.Create(6, 6) },
            {'t', Tuple.Create(8, 6) },
            {'y', Tuple.Create(10, 6) },
            {'u', Tuple.Create(12, 6) },
            {'i', Tuple.Create(14, 6) },
            {'o', Tuple.Create(16, 6) },
            {'p', Tuple.Create(18, 6) },
            {'a', Tuple.Create(1, 4) },
            {'s', Tuple.Create(3, 4) },
            {'d', Tuple.Create(5, 4) },
            {'f', Tuple.Create(7, 4) },
            {'g', Tuple.Create(9, 4) },
            {'h', Tuple.Create(11, 4) },
            {'j', Tuple.Create(13, 4) },
            {'k', Tuple.Create(15, 4) },
            {'l', Tuple.Create(17, 4) },
            {'z', Tuple.Create(2, 2) },
            {'x', Tuple.Create(4, 2) },
            {'c', Tuple.Create(6, 2) },
            {'v', Tuple.Create(8, 2) },
            {'b', Tuple.Create(10, 2) },
            {'n', Tuple.Create(12, 2) },
            {'m', Tuple.Create(14, 2) }
        };


    }


    // unimplemented 
    public static class View
    {

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
            string line = "";
            // See if the user wants to create nodes.  Each letter on the keyboard has a name (ie. a, b, o) and an (X,Y) location.
            // Each letter the user types can create a node.
            if (System.Text.RegularExpressions.Regex.IsMatch(input, "create nodes", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                while (true)
                {
                    Console.WriteLine("Please type the letters a to z to create your nodes");
                    line = Console.ReadLine().ToLower();
                    if (isStringAllAlphabeticalChars(line))
                        break;
                }
                // create a node for each letter in the line
                foreach (char letter in line)
                {
                    createNode(letter.ToString(), Model.dictionaryKeyboardXYLocation[letter].Item1, Model.dictionaryKeyboardXYLocation[letter].Item2);
                }
            }

            // Check to see if the user wants to connect nodes with edges
            if (System.Text.RegularExpressions.Regex.IsMatch(input, "create edges", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                // if there are an odd number of edge choices or if they don't match a node they will be ignored
                while (true)
                {
                    Console.WriteLine("Please type the letters a to z to create your edges");
                    line = Console.ReadLine().ToLower();
                    if (isStringAllAlphabeticalChars(line))
                        break;
                }
                // create a node for each letter in the line
                int lineLength = line.Length;
                for (var i = 1; i < lineLength; i += 2)
                {
                    // check if the nodes are created before connecting the edges
                    if (selectNode(line[i - 1].ToString()) != null && selectNode(line[i].ToString()) != null)
                    {
                        createEdge(String.Concat(line[i - 1].ToString(), line[i].ToString()), "",
                            selectNode(line[i - 1].ToString()), selectNode(line[i].ToString()));
                    }
                }
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(input, "print graph", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                Console.WriteLine("The node list is:");
                Model.nodeList.ForEach(Console.WriteLine);

                Console.WriteLine("The edge list is:");
                Model.edgeList.ForEach(Console.WriteLine);
            }

            //if (input == "comands")
            if (System.Text.RegularExpressions.Regex.IsMatch(input, "commands", System.Text.RegularExpressions.RegexOptions.IgnoreCase))            
            {
                Console.WriteLine("The commands are");
                Console.WriteLine("create nodes");
                Console.WriteLine("create edges");
                Console.WriteLine("print graph");
                Console.WriteLine("quit");
                Console.WriteLine("exit");
            }
        }

        public static bool isStringAllAlphabeticalChars(string str)
        {
            Regex rgx = new Regex("^[A-Za-z]+$");
            return rgx.IsMatch(str);
        }

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



















// Delete this:

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
