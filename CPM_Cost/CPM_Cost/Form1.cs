using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPM_Cost
{
    public partial class Form1 : Form
    {

        public static int currentID = 1;
        public List<Node> nodeList;

        public List<Action> actionList;
        public List<int> actionIdList;

        public List<int> idList;

        public int globalExtraTime = 0;
        public int lowestCritTime = 0;

        public double operationsCost = 0;

        //------------------------------------------------------------------------------------ ComboBoxItem class

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString() {
                return Text;
            }
        }

        //------------------------------------------------------------------------------------ Node class

        public class Node : IComparable<Node>
        {
            public int ID;

            public int tn;
            public int tgr;
            public double kn;
            public double kgr;

            public List<int> next;
            public List<int> prev;

            public double K;
            public int deltaT;

            public double Kp;

            public bool isOnCriticalPath;
            public int timeReserve;

            public Node() {
                ID = -1;

                tn = -1;
                tgr = -1;
                kn = -1;
                kgr = -1;

                K = -1;
                Kp = 0;
                deltaT = -1;

                isOnCriticalPath = false;
                timeReserve = -1;

                next = new List<int>();
                prev= new List<int>();
            }

            public void Calculate() {
                deltaT = tn - tgr;
                Kp = K * deltaT;
            }

            public int CompareTo( Node other ) {
                return this.K.CompareTo( other.K );
            }
        }

        //------------------------------------------------------------------------------------ Action class

        public class Action{
            public int ID;

            public int startTime;
            public int endTime;
            public int extraTime;

            public List<int> prev;
            public List<int> next;

            public bool isOnCriticalPath;

            public Action(int _ID, int _startTime, int _endTime) {
                ID = _ID;
                startTime = _startTime;
                endTime = _endTime;

                isOnCriticalPath = false;

                prev = new List<int>();
                next = new List<int>();
            }
        }

        //------------------------------------------------------------------------------------ Form Init

        public Form1() {
            InitializeComponent();
            nodeList = new List<Node>();
            actionList = new List<Action>();

            actionIdList = new List<int>();
            idList = new List<int>();

            saveButton.Enabled = false;
        }

        //------------------------------------------------------------------------------------  Form Events

        private void addButton_Click( object sender, EventArgs e ) {
            Node node = new Node();
            node.ID = currentID;
            nodeList.Add( node );

            ComboBoxItem item = new ComboBoxItem();
            item.Text = "Czynność " + currentID;
            item.Value = node;

            currentID++;

            pointsList.Items.Add(item);
            actionLabel.Text = "NEW NODE ADDED!";

            if(!pointsList.Enabled) {
                pointsList.Enabled = true;
                calculateButton.Enabled = true;
                saveButton.Enabled = true;
                Debug.WriteLine( "----------------------------------------------------------------------------");
                Debug.WriteLine( "-------------------------- CPM COST PROGRAM START --------------------------" );
                Debug.WriteLine( "----------------------------------------------------------------------------\n" );
            }
        }

        //------------------------------------------------------------------------------------  List of items

        private void pointsList_SelectedIndexChanged( object sender, EventArgs e ) {
            Node tmpNode = (Node)((ComboBoxItem)pointsList.SelectedItem).Value;

            clearFields();

            idField.Text = tmpNode.ID.ToString();
            tnField.Text = tmpNode.tn.ToString();
            tgrField.Text = tmpNode.tgr.ToString();
            knField.Text = tmpNode.kn.ToString();
            kgrField.Text = tmpNode.kgr.ToString();

            for(int i=0 ; i < tmpNode.next.ToArray().Length; i++ ) {
                nextField.Text += tmpNode.next[i].ToString()+";";
            }

            for( int i = 0 ;i < tmpNode.prev.ToArray().Length ;i++ ) {
                prevField.Text += tmpNode.prev[i].ToString() + ";";
            }

            actionLabel.Text = "SHOWING NODE (" + tmpNode.ID + ")";
        }

        //------------------------------------------------------------------------------------ SaveButton

        private void saveButton_Click( object sender, EventArgs e ) {
            if(idField.Text != "" && 
                tnField.Text != "" && 
                tgrField.Text != "" && 
                knField.Text != "" &&
                kgrField.Text != "") 
                {

                Node tmpNode = nodeList[Int32.Parse(idField.Text) - 1];

                tmpNode.kgr = Int32.Parse( kgrField.Text );
                tmpNode.kn = Int32.Parse( knField.Text );
                tmpNode.tn = Int32.Parse( tnField.Text );
                tmpNode.tgr = Int32.Parse( tgrField.Text );

                tmpNode.next.Clear();
                tmpNode.prev.Clear();

                if(nextField.Text != "") {
                    List<string> array = nextField.Text.ToString().Split( ';' ).ToList();
                    List<string> arrayPrev = prevField.Text.ToString().Split( ';' ).ToList();

                    for( int i = 0 ;i < array.Count ;i++ ) {
                        if(array[i] != "") {
                            tmpNode.next.Add( Int32.Parse( array[i] ) );
                        }                       
                    }

                    for( int i = 0 ;i < arrayPrev.Count ;i++ ) {
                        if( arrayPrev[i] != "" ) {
                            tmpNode.prev.Add( Int32.Parse( arrayPrev[i] ) );
                        }
                    }
                }

                clearFields();
                actionLabel.Text = "NODE SAVED!";
            } else {
                if(nodeList.Count == 0) {
                    actionLabel.Text = "ADD SOME NODES!";
                } else {
                    actionLabel.Text = "FILL IN ALL FIELDS!";
                }
            }
        }

        //------------------------------------------------------------------------------------ ClearFields

        void clearFields() {
            idField.Text = "";

            kgrField.Text = "";
            knField.Text = "";
            tgrField.Text = "";
            tnField.Text = "";

            nextField.Text = "";
            prevField.Text = "";
        }

        //------------------------------------------------------------------------------------ CalculateButton

        private void calculateButton_Click( object sender, EventArgs e ) {

            ResetAllNodesAndActions();

            for( int i = 0 ;i < nodeList.Count ;i++ ) {
                for(int j=0 ; j< nodeList[i].next.Count ; j++ ) {
                    if( !duplicateExist( nodeList[i].next[j], idList )) {
                        idList.Add( nodeList[i].next[j] );
                    }                        
                }
            }

            //Calculations methods
            CreateActions();
            CalculateStartTimes();
            CalculateEndTimes();
            CalculateExtraTimes();
            CalculateCostsGradients();

            setNodesData();
            CalculateCritTime();
            CalculateGlobalExtraTime();

            normalTimeField.Text = "Time: [ " + actionList[actionList.Count - 1].endTime + " ]";

            //showActions();

            //Main function
            CostAlgorythm();
            
            //Methods for debugging
            //showActions();
            //showNodes();
            //Debug.WriteLine("");
            //showGradients();
            //Debug.WriteLine( "" );
            //showCriticalPath();

            //ShowCritTime();
            //ShowGlobalExtraTime();
            ShowSolution();

            solutionField.Text = critPathToString();
            timeField.Text = "Shorting operation time: [ " + GetTimeOnCritPath() + " ]";
            costField.Text = "Shorting cost: [ " + operationsCost + " ]";
            Debug.WriteLine( "\n----------------------------------------------------------------------------\n" );
        }

        //------------------------------------------------------------------------------------  COST ALGORYTHM
  
        public void ShowSolution() {
            if(GetTimeOnNormalPath() == GetTimeOnCritPath()) {

                showNodes();
                Debug.WriteLine("");

                Debug.WriteLine( "\n======================" );
                Debug.WriteLine( "Total time [ " + GetTimeOnCritPath() + " ]" );
                Debug.WriteLine( "Total cost [ " + operationsCost + " ]" );
                Debug.WriteLine( "======================" );
            } else {
                Debug.WriteLine( "\n============================" );
                Debug.WriteLine( "[ ERROR DURING CALCULATIONS ]" );
                Debug.WriteLine( "Total crit time [ " + GetTimeOnCritPath() + " ]" );
                Debug.WriteLine( "Total norm time [ " + GetTimeOnNormalPath() + " ]" );
                Debug.WriteLine( "Total cost [ " + operationsCost + " ]" );
                Debug.WriteLine( "============================" );

                showNodes();
            }
        }

        public void CostAlgorythm() {

            int timeOnCritPath = GetTimeOnCritPath();

            nodeList.Sort();

            foreach(Node n in nodeList) {
                if(n.isOnCriticalPath && n.K > 0 && n.deltaT > 0) {
                    if(n.deltaT <= globalExtraTime) {
                        globalExtraTime -= n.deltaT;
                        operationsCost += n.deltaT * n.K;
                        n.Kp = n.deltaT * n.K;
                        n.tn -= n.deltaT;
                        n.deltaT = n.tn - n.tgr;
                    } else {
                        operationsCost += globalExtraTime * n.K;
                        n.Kp = globalExtraTime * n.K;
                        n.tn -= globalExtraTime;
                        n.deltaT = n.tn - n.tgr;
                        globalExtraTime -= globalExtraTime;
                    }
                }
            }

            timeOnCritPath = GetTimeOnCritPath();
            globalExtraTime = timeOnCritPath - lowestCritTime;
            //lowestCritTime = timeOnCritPath;

            int extraTimeOnNormalPath = globalExtraTime;
            int extraTimeOnCritPath = globalExtraTime;

            foreach(Node n in nodeList) {
                if( n.isOnCriticalPath && extraTimeOnCritPath > 0 && n.K > 0 && GetTimeOnCritPath() != lowestCritTime) {
                    if( n.K > 0 && n.deltaT > 0 ) {
                        if( n.deltaT <= extraTimeOnCritPath ) {
                            n.tn -= n.deltaT;
                            operationsCost += n.K * n.deltaT;
                            n.deltaT = n.tn - n.tgr;
                            extraTimeOnCritPath -= n.deltaT;
                        } else {
                            n.tn -= extraTimeOnCritPath;
                            operationsCost += n.K * extraTimeOnCritPath;
                            n.deltaT = n.tn - n.tgr;
                            extraTimeOnCritPath -= extraTimeOnCritPath;
                        }
                    }
                } 
                else if( (!n.isOnCriticalPath) && (extraTimeOnNormalPath > 0) && (GetTimeOnNormalPath() != lowestCritTime)) {
                    if( n.K > 0 && n.deltaT > 0 ) {
                        if( n.deltaT <= extraTimeOnNormalPath ) {
                            n.tn -= n.deltaT;
                            operationsCost += n.K * n.deltaT;
                            extraTimeOnNormalPath -= n.deltaT;
                            n.deltaT = n.tn - n.tgr;
                        } else {
                            n.tn -= extraTimeOnNormalPath;
                            operationsCost += n.K * extraTimeOnNormalPath;
                            extraTimeOnNormalPath -= extraTimeOnNormalPath;
                            n.deltaT = n.tn - n.tgr;
                        }
                    }
                }
            }

            timeOnCritPath = GetTimeOnCritPath();
        }

        public int GetTimeOnCritPath() {
            int time = 0;

            foreach(Node n in nodeList) {
                if( n.isOnCriticalPath ) {
                    time += n.tn;
                }
            }

            return time;
        }

        public int GetTimeOnNormalPath() {
            int time = 0;

            foreach( Node n in nodeList ) {
                if( !n.isOnCriticalPath ) {
                    time += n.tn;
                }
            }

            return time;
        }

        //------------------------------------------------------------------------------------ Calculate crit time

        public void CalculateCritTime() {

            int time = 0;

            for(int i=0 ; i<nodeList.Count ; i++ ) {
                if( nodeList[i].isOnCriticalPath )
                    time += nodeList[i].tgr;
            }

            lowestCritTime = time;
        }

        public void ShowCritTime() {
            Debug.WriteLine("CritTime[ " + lowestCritTime + " ]");
        }

        //------------------------------------------------------------------------------------ Calculate global extra time

        public void CalculateGlobalExtraTime() {
            int onCrit = 0;
            int onNotCrit = 0;

            for( int i = 0 ;i < nodeList.Count ;i++ ) {
                if( nodeList[i].isOnCriticalPath )
                    onCrit += nodeList[i].tn;
                else
                    onNotCrit += nodeList[i].tn;
            }

            globalExtraTime = onCrit - onNotCrit;
        }

        public void ShowGlobalExtraTime() {
            Debug.WriteLine( "ExtraTime[ " + globalExtraTime + " ]" );
        }

        //------------------------------------------------------------------------------------ Show idList
        public void showIdList() {
            Debug.WriteLine( "----------------------------------------- ID LIST" );
            for(int i=0 ; i< idList.Count ; i++ ) {
                Debug.WriteLine("ID: " + idList[i]);
            }
        }

        //------------------------------------------------------------------------------------ Show gradients

        public void showGradients() {
            Debug.WriteLine( "======================" );
            Debug.WriteLine( "        COST GRADIENTS" );
            Debug.WriteLine( "======================" );
            for(int i=0 ; i<nodeList.Count ; i++ ) {
                if(nodeList[i].isOnCriticalPath) {
                    string text = "[ " + nodeList[i].prev[0] + ", " + nodeList[i].next[0] + " ], S: " + nodeList[i].K;
                    Debug.WriteLine( text );
                }
            }
            Debug.WriteLine( "======================" );
        }

        //------------------------------------------------------------------------------------ Show actions

        public void showNodes() {
            Debug.WriteLine( "////////////////////////////////////////// NODES" );
            Debug.WriteLine( "| ID | CP | K | delta t | Kp |" );

            for(int i=0 ; i<nodeList.Count ; i++ ) {
                string nodeRow = "";

                if(nodeList[i].isOnCriticalPath) {
                    nodeRow +=
                    "[" + nodeList[i].prev[0] + "," + nodeList[i].next[0] + "] | " +
                    "X" + " | " +
                    nodeList[i].K + " | " +
                    nodeList[i].deltaT + " | " +
                    nodeList[i].Kp + " |";
                } else {
                    nodeRow +=
                    "[" + nodeList[i].prev[0] + "," + nodeList[i].next[0] + "] | " +
                    " " + " | " +
                    nodeList[i].K + " | " +
                    nodeList[i].deltaT + " | " +
                    nodeList[i].Kp + " |";
                }

                Debug.WriteLine(nodeRow);
            }
        }

        //------------------------------------------------------------------------------------ Show actions

        public void showActions() {
            for(int i=0 ; i<actionList.Count ; i++ ) {
                Debug.WriteLine( "/////////////////////////////////////////[ ACTION " + (i+1) + "]" );
                Debug.WriteLine( "..................... TIMES" );
                Debug.WriteLine( "start[ " + actionList[i].startTime + " ]" );
                Debug.WriteLine( "end  [ " + actionList[i].endTime + " ]");
                Debug.WriteLine( "extra[ " + actionList[i].extraTime + " ]");
                Debug.WriteLine( "............... CONNECTIONS" );
                Debug.WriteLine( "Prevs[ " + actionList[i].prev.Count + " ]" );
                Debug.WriteLine( "Nexts[ " + actionList[i].next.Count + " ]" );
            }
        }

        //------------------------------------------------------------------------------------ Show critical path

        public void showCriticalPath() {
            List<int> cp = getCriticalPath();
            string text = "";
            string cpNodes = "";

            text += "| " + cp[0] + " | ";
            for(int i=1 ; i<cp.Count ; i++ ) {
                text += cp[i] + " | ";
            }

            Debug.WriteLine( "======================" );
            Debug.WriteLine( "         CRITICAL PATH" );
            Debug.WriteLine( "======================" );

            Debug.WriteLine(text);

            for( int i = 0 ;i < nodeList.Count ;i++ ) {
                if( nodeList[i].isOnCriticalPath ) {
                   cpNodes += "[ " + nodeList[i].prev[0] + "," + nodeList[i].next[0] + " ]";
                }
            }
            Debug.WriteLine( "----------------------" );

            Debug.WriteLine(cpNodes);

            Debug.WriteLine( "======================" );
        }

        //------------------------------------------------------------------------------------ Critical Path to string

        public string critPathToString() {
            List<int> cp = getCriticalPath();
            string crit = "CRITICAL PATH: ";

            for( int i = 0 ;i < nodeList.Count ;i++ ) {
                if( nodeList[i].isOnCriticalPath ) {
                    crit += "[ " + nodeList[i].prev[0] + "," + nodeList[i].next[0] + " ]";
                }
            }

            return crit;
        }

        //------------------------------------------------------------------------------------ Reset

            //Resetuje wszystko do 0, bez usuwania danych wprowadzonych przez użytkownika
        public void ResetAllNodesAndActions() {
            Debug.WriteLine( "======================" );
            Debug.WriteLine("Clearing idList ...");
            idList.Clear();
            idList.Add( 1 );

            Debug.WriteLine( "Clearing actions ..." );
            actionList.Clear();

            Debug.WriteLine( "Clearing nodes ..." );
            for(int i=0 ; i< nodeList.Count ; i++ ) {
                nodeList[i].K = -1;
                nodeList[i].isOnCriticalPath = false;
            }
            Debug.WriteLine( "======================\n" );
        }

        //------------------------------------------------------------------------------------ Create actions

        public void CreateActions() {
            for(int i=0 ; i<idList.Count ; i++ ) {
                actionList.Add( new Action(idList[i], 0, 99999999) );
            }

            for(int i=0 ; i<nodeList.Count ; i++ ) {
                for(int j=0 ; j< nodeList[i].next.Count ; j++ ) {
                    actionList[nodeList[i].next[j]-1].prev.Add( nodeList[i].prev[j] );
                }
            }

            for( int i = 0 ;i < nodeList.Count ;i++ ) {
                for( int j = 0 ;j < nodeList[i].prev.Count ;j++ ) {
                    actionList[nodeList[i].prev[j] - 1].next.Add( nodeList[i].next[j] );
                }
            }
        }

        //------------------------------------------------------------------------------------ Calculate cost gradients

        public void CalculateCostsGradients() {
            for(int i=0 ; i<nodeList.Count ; i++ ) {
                nodeList[i].K = (nodeList[i].kgr - nodeList[i].kn) /( nodeList[i].tn - nodeList[i].tgr );
            }
        }

        //------------------------------------------------------------------------------------ Calculate start times

        public void CalculateStartTimes() {
            int maxTime = 0;
            int newStartTime = 0;

            for(int i=1 ; i<actionList.Count ; i++ ) {
                newStartTime = 0;
                for(int j=0 ; j<actionList[i].prev.Count ; j++ ) {
                    List<int> p = new List<int>();
                    List<int> n = new List<int>();

                    p.Clear();
                    n.Clear();

                    maxTime = 0;

                    p.Add( actionList[i].prev[j] );
                    n.Add( actionList[i].ID );

                    if(findNode(p,n) > maxTime) {
                        maxTime = findNode( p, n );
                    }

                    int tmpTime = maxTime + getPrevStartTime( actionList[i].prev[j] );

                    if(tmpTime > newStartTime) {
                        newStartTime = tmpTime;
                    }
                }

                actionList[i].startTime = newStartTime;
            }
        }

        //------------------------------------------------------------------------------------ Calculate end times

        public void CalculateEndTimes() {
            int newEndTime = 100000;

            actionList[actionList.Count - 1].endTime = actionList[actionList.Count - 1].startTime;

            for(int i=actionList.Count-1 ; i>=0 ; i-- ) {
                int previousAction = 0;

                for(int j=0 ; j<actionList[i].prev.Count ; j++ ) {
                    List<int> p = new List<int>();
                    List<int> n = new List<int>();

                    p.Clear();
                    n.Clear();

                    p.Add( actionList[i].prev[j] );
                    n.Add( actionList[i].ID );

                    int min = actionList[i].endTime - findNode( p, n );

                    previousAction = actionList[i].prev[j] - 1;

                    if( actionList[previousAction].endTime > min ) {
                        actionList[previousAction].endTime = min;
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------ Calculate extra times

        public void CalculateExtraTimes() {
            for(int i=0 ; i<actionList.Count ; i++ ) {
                actionList[i].extraTime = actionList[i].endTime - actionList[i].startTime;
            }

            for(int i=0 ; i<nodeList.Count ; i++ ) {
                int nextEndTime = findAction( nodeList[i].next[0] ).endTime;
                int prevEndTime = findAction( nodeList[i].prev[0] ).endTime;
                int difference = nextEndTime - nodeList[i].tn;

                nodeList[i].timeReserve = difference;

                if(difference <= prevEndTime && findAction(nodeList[i].prev[0]).extraTime == 0 && findAction(nodeList[i].next[0]).extraTime == 0) {
                    nodeList[i].isOnCriticalPath = true;
                    findAction( nodeList[i].next[0] ).isOnCriticalPath = true;
                    findAction( nodeList[i].prev[0] ).isOnCriticalPath = true;
                }
            }
        }

        //------------------------------------------------------------------------------------ Get previous start time

        public int getPrevStartTime(int prevID ) {
            for(int i=0 ; i<actionList.Count ; i++) {
                if( actionList[i].ID == prevID )
                    return actionList[i].startTime;
            }

            return 0;
        }

        //------------------------------------------------------------------------------------ Finde a node

        /// FOR FINDING A NODE TN VALUE
        public int findNode(List<int> prev, List<int> next) {
            for(int i=0 ; i<nodeList.Count ; i++ ) {
                if( compareLists(prev, nodeList[i].prev) && compareLists(next, nodeList[i].next)) {
                    return nodeList[i].tn;
               }
            }
            return 0;
        }

        /// FOR FINDING A NODE ID WITH PREV AND NEXT
        public int findNodeID( int prev, int next ) {
            for( int i = 0 ;i < nodeList.Count ;i++ ) {
                if( nodeList[i].prev[0] == prev && nodeList[i].next[0] == next ) {
                    return i;
                }
            }
            return -1;
        }

        public Action findAction(int ID) {
            for(int i=0 ; i<actionList.Count ; i++ ) {
                if(actionList[i].ID == ID) {
                    return actionList[i];
                }
            }

            return null;
        }

        //------------------------------------------------------------------------------------ Set Nodes Data (Kp, deltaT)

        public void setNodesData() {
            for(int i=0 ; i<nodeList.Count ; i++ ) {
                //if( nodeList[i].isOnCriticalPath )
                    nodeList[i].Calculate();
            }
        }

        //------------------------------------------------------------------------------------ Get Critical Path

        public List<int> getCriticalPath() {
            List<int> criticalPath = new List<int>();

            for(int i=0 ; i<actionList.Count ; i++ ) {
                if(actionList[i].extraTime == 0) {
                    criticalPath.Add(actionList[i].ID);
                }
            }

            return criticalPath;
        }

        //------------------------------------------------------------------------------------ Compare 2 lists

        public bool compareLists(List<int> l1, List<int> l2) {
            if(l1.Count != l2.Count) {
                Debug.WriteLine("Listy maja rozna wielkosc!");
                return false;
            } else {
                int good = 0;

                for( int i = 0 ;i < l1.Count ;i++ ) {
                    if( l1[i] == l2[i] )
                        good++;
                }

                if( good == l1.Count )
                    return true;
            }

            return false;
        }

        //------------------------------------------------------------------------------------ Check duplicates

        public bool duplicateExist(int number, List<int> list) {
            bool test = false;

            for( int k = 0 ;k < list.Count ;k++ ) {
                if( list[k] == number )
                    test = true;
            }

            return test; //nie ma duplikatow
        }
    }
}
