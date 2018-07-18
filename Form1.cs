using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Memory_Allocator
{
    public partial class MemAllc : Form
    {
        public MemAllc()
        {
            InitializeComponent();
        }

        int ind = 0;
        public static int showed = 0;
        bool ProcessClicked = false;
        bool HolesClicked = false;
        List<int> HoleIndex = new List<int>();
        string memory = null;
        Memory m = new Memory();

        Graphics g;
        Rectangle r;
        
        void Allocating(List<int> ProcessesSize, List<int> HolesSize, List<int> StartingAddress, List<int> ProcessAddress, int MemorySize, int ProcessRows, int HolesRows, int checked1, int checked2, List<int> HoleIndex)
        {
            for (int i = 0; i < ProcessRows; i++)
            {
                int SizeParsed;
                string proc = Convert.ToString(ProcessTable.Rows[i].Cells[0].Value);
                if (proc == "")
                { MessageBox.Show("Please Enter the size of process P" + (i).ToString()); break; }
                else if (!int.TryParse(proc, out SizeParsed) || Convert.ToInt32(proc) <= 0)
                { MessageBox.Show("Please Enter a valid size of process P" + (i).ToString()); break; }
                else
                {
                    if (Convert.ToInt32(proc) > MemorySize)
                    { MessageBox.Show("The Size of the process P" + (i).ToString() + " can't be larger than the memory size"); break; }
                    else
                    {
                        ProcessesSize.Add(Convert.ToInt32(proc));
                        checked1--;
                    }
                }
            }

            for (int i = 0; i < HolesRows; i++)
            {
                int SizeParsed;
                int AddressParsed;
                string Hole = Convert.ToString(HolesTable.Rows[i].Cells[0].Value);
                string Address = Convert.ToString(HolesTable.Rows[i].Cells[1].Value);

                if (Hole == "")
                { MessageBox.Show("Please Enter the size of Hole H" + (i).ToString()); break; }
                else if (!int.TryParse(Hole, out SizeParsed) || Convert.ToInt32(Hole) <= 0)
                { MessageBox.Show("Please Enter a valid size of hole H" + (i).ToString()); break; }
                else
                {
                    if (Convert.ToInt32(Hole) > MemorySize)
                    { MessageBox.Show("The Size of the Hole H" + (i).ToString() + " can't be larger than the memory size"); break; }
                    else
                    {

                        HolesSize.Add(Convert.ToInt32(Hole));
                        checked2--;
                    }
                }

                if (Address == "")
                    MessageBox.Show("Please Enter the starting address of Hole H" + (i).ToString());
                else if (!int.TryParse(Address, out AddressParsed) || Convert.ToInt32(Address) < 0)
                    MessageBox.Show("Please Enter a valid Starting Address of hole H" + (i).ToString());
                else
                {
                    if (Convert.ToInt32(Address) > MemorySize)
                    { MessageBox.Show("The Starting address of the hole H" + (i).ToString() + " can't be larger than the memory size"); break; }
                    else if (Convert.ToInt32(Address) + HolesSize[i] > MemorySize)
                    { MessageBox.Show("The Starting address of the hole H" + (i).ToString() + " plus its size can't be larger than the memory size"); break; }
                    else
                    {
                        int TemprorAdd = Convert.ToInt32(Address);

                        int flag = 0;
                        int ConflictedHole = 0;

                        if (i > 0)
                            for (int j = 0; j < i; j++)
                            {

                                if (((TemprorAdd+HolesSize[i]) > StartingAddress[j] && TemprorAdd < (StartingAddress[j] + HolesSize[j])) || TemprorAdd == StartingAddress[j])
                                {
                                    flag = 1;
                                    ConflictedHole = j;
                                    break;
                                }
                            }
                        if (flag == 0)
                        {

                            StartingAddress.Add(TemprorAdd);
                            checked2--;
                        }
                        else
                        {
                            MessageBox.Show("There will be a conflict between hole H" + (i).ToString() + " and hole H" + (ConflictedHole).ToString());
                            break;
                        }
                    }
                }


            }


                if (AllocAlgorithm.Text == "First Fit")
                {
                    if (checked1 == 0 && checked2 == 0)
                    {
                        AllocAlgorithm.Enabled = false;
                        for (int i = 0; i < HolesRows; i++)
                        {
                            if (i > 0)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    if (StartingAddress[i] == (StartingAddress[j] + HolesSize[j]))
                                    {
                                        HolesSize[j] += HolesSize[i];
                                        HolesSize.RemoveAt(i);
                                        StartingAddress.RemoveAt(i);
                                        i--;
                                        HolesRows--;
                                         break;
                                    }
                                }
                            }
                        }
                        NewProcess.Enabled = true;
                        if (showed == 0)
                        {
                            m = new Memory();
                            m.Show();     
                            showed = 1;
                        }
                        int x = Convert.ToInt32(memory);
                        g = m.CreateGraphics();
                        
                        r = new Rectangle(170, 15, 175, 400);

                        g.DrawRectangle(new Pen(Brushes.Black, 2), r);                        
                        g.FillRectangle(new SolidBrush(Color.Silver), r); 

                        g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(20,20,10,10));
                        g.FillRectangle(new SolidBrush(Color.Silver), new Rectangle(20, 20, 10, 10));
                        g.DrawString("Reserved", new Font("Arial", 8), Brushes.Black, new Point(35, 18));

                        g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(20, 40, 10, 10));
                        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(20, 40, 10, 10));
                        g.DrawString("Free Space", new Font("Arial", 8), Brushes.Black, new Point(35, 38));

                        g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(20, 60, 10, 10));
                        g.FillRectangle(new SolidBrush(Color.SkyBlue), new Rectangle(20, 60, 10, 10));
                        g.DrawString("Allocated", new Font("Arial", 8), Brushes.Black, new Point(35, 58));
                        
                        g.DrawString("0", new Font("Arial", 10), Brushes.Black, new Point(154, 8));
                        g.DrawString(memory, new Font("Arial", 10), Brushes.Black, new Point(160 - ((memory.ToString().Length) * 7), 405));
                        
                        for (int i = 0; i < HolesRows; i++)
                        {
                            
                            int HoleAddress = ((StartingAddress[i] * 400) / x) + 15;
                            int HoleSizeAddress = (((HolesSize[i]+StartingAddress[i]) * 400) / x)+15;
                            r = new Rectangle(170, HoleAddress, 175, HoleSizeAddress - HoleAddress);
                            g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                            g.FillRectangle(new SolidBrush(Color.White), r);
                            g.DrawString(StartingAddress[i].ToString(), new Font("Arial", 10), Brushes.Black, new Point(160 - ((StartingAddress[i].ToString().Length) * 7), HoleAddress - 7));
                            g.DrawString(HolesSize[i].ToString() + "KB", new Font("Arial", 8), Brushes.Black, new Point(240, ((HoleAddress + HoleSizeAddress)/2)-5));
                            

                        }
                        ind = 0;
                        int allocFlag = 0;
                        for (int i = 0; i < ProcessRows; i++)
                        {
                           

                            if ((ProcessTable.Rows[i].Cells[1].Value != "De-Allocated"))
                            {

                                int flag = 0;
                                for (int j = 0; j < HolesRows; j++)
                                {

                                    if (ProcessTable.Rows[i].Cells[1].Value == "Allocated" && ProcessesSize[i] <= HolesSize[HoleIndex[ind]] )
                                    {
                                      
                                        flag = 1;
                                        
                                        HolesSize[HoleIndex[ind]] = HolesSize[HoleIndex[ind]] - ProcessesSize[i];
                                        int HoleAddress = ((StartingAddress[HoleIndex[ind]] * 400) / x) + 15;
                                        int ProcessSizeAddress = (((ProcessesSize[i] + StartingAddress[HoleIndex[ind]]) * 400) / x) + 15;
                                        ProcessAddress.Add(StartingAddress[HoleIndex[ind]]);
                                        StartingAddress[HoleIndex[ind]] += ProcessesSize[i];
                                        r = new Rectangle(170, HoleAddress, 175, ProcessSizeAddress - HoleAddress);
                                        g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                                        g.FillRectangle(new SolidBrush(Color.SkyBlue), r);
                                        g.DrawString("P" + i.ToString(), new Font("Arial", 8), Brushes.Black, new Point(245, ((HoleAddress + ProcessSizeAddress) / 2) - 5));
                                        if (HolesSize[HoleIndex[ind]] > 0)
                                        {
                                            HoleAddress = ((StartingAddress[HoleIndex[ind]] * 400) / x) + 15;
                                            int HoleSizeAddress = (((HolesSize[HoleIndex[ind]] + StartingAddress[HoleIndex[ind]]) * 400) / x) + 15;
                                            r = new Rectangle(170, HoleAddress, 175, HoleSizeAddress - HoleAddress);
                                            g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                                            g.FillRectangle(new SolidBrush(Color.White), r);
                                            g.DrawString(HolesSize[HoleIndex[ind]].ToString() + "KB", new Font("Arial", 8), Brushes.Black, new Point(240, ((HoleAddress + HoleSizeAddress) / 2) - 5));
                                        }

                                        ind++;
                                        break;
                                    }
                                    else if (ProcessesSize[i] <= HolesSize[j])
                                    {
                                        if (i != ProcessRows - 1)
                                            ind++;
                                        flag = 1;
                                        HoleIndex.Add(j);
                                        HolesSize[j] = HolesSize[j] - ProcessesSize[i];
                                        int HoleAddress = ((StartingAddress[j] * 400) / x) + 15;
                                        int ProcessSizeAddress = (((ProcessesSize[i] + StartingAddress[j]) * 400) / x) + 15;
                                        ProcessAddress.Add(StartingAddress[j]);
                                        StartingAddress[j] += ProcessesSize[i];
                                        r = new Rectangle(170, HoleAddress, 175, ProcessSizeAddress - HoleAddress);
                                        g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                                        g.FillRectangle(new SolidBrush(Color.SkyBlue), r);
                                        g.DrawString("P" + i.ToString(), new Font("Arial", 8), Brushes.Black, new Point(245, ((HoleAddress + ProcessSizeAddress) / 2) - 5));
                                        if (HolesSize[j] > 0)
                                        {
                                            HoleAddress = ((StartingAddress[j] * 400) / x) + 15;
                                            int HoleSizeAddress = (((HolesSize[j] + StartingAddress[j]) * 400) / x) + 15;
                                            r = new Rectangle(170, HoleAddress, 175, HoleSizeAddress - HoleAddress);
                                            g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                                            g.FillRectangle(new SolidBrush(Color.White), r);
                                            g.DrawString(HolesSize[j].ToString() + "KB", new Font("Arial", 8), Brushes.Black, new Point(240, ((HoleAddress + HoleSizeAddress) / 2) - 5));
                                        }
                                        break;
                                    }

                                }
                                if (flag == 1)
                                {

                                    int flag2 = 0;
                                    for (int k = 0; k < DeAlloc.Items.Count; k++)
                                    {
                                        if (DeAlloc.Items[k].ToString() == "P" + i.ToString())
                                        { flag2 = 1; break; }
                                    }
                                    if (flag2 == 0)
                                        DeAlloc.Items.Add("P" + i.ToString());
                                    ProcessTable.Rows[i].Cells[1].Value = "Allocated";
                                }
                                else
                                    ProcessTable.Rows[i].Cells[1].Value = "Waiting";
                            }
                            else
                                ind++;
                           

                        }

                    }
                }
                else if (AllocAlgorithm.Text == "Best Fit")
                {
                    if (checked1 == 0 && checked2 == 0)
                    {
                        AllocAlgorithm.Enabled = false;
                        for (int i = 0; i < HolesRows; i++)
                        {
                            if (i > 0)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    if (StartingAddress[i] == (StartingAddress[j] + HolesSize[j]))
                                    {
                                        HolesSize[j] += HolesSize[i];
                                        HolesSize.RemoveAt(i);
                                        StartingAddress.RemoveAt(i);
                                        i--;
                                        HolesRows--;
                                        break;
                                    }
                                }
                            }
                        }
                        NewProcess.Enabled = true;

                        if (showed == 0)
                        {
                            m = new Memory();
                            m.Show();
                            showed = 1;
                        }
                        

                        int x = Convert.ToInt32(memory);
                        g = m.CreateGraphics();
                        r = new Rectangle(170, 15, 175, 400);

                        g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                        g.FillRectangle(new SolidBrush(Color.Silver), r);

                        g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(20, 20, 10, 10));
                        g.FillRectangle(new SolidBrush(Color.Silver), new Rectangle(20, 20, 10, 10));
                        g.DrawString("Reserved", new Font("Arial", 8), Brushes.Black, new Point(35, 18));

                        g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(20, 40, 10, 10));
                        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(20, 40, 10, 10));
                        g.DrawString("Free Space", new Font("Arial", 8), Brushes.Black, new Point(35, 38));

                        g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(20, 60, 10, 10));
                        g.FillRectangle(new SolidBrush(Color.SkyBlue), new Rectangle(20, 60, 10, 10));
                        g.DrawString("Allocated", new Font("Arial", 8), Brushes.Black, new Point(35, 58));

                        g.DrawString("0", new Font("Arial", 10), Brushes.Black, new Point(154, 8));
                        g.DrawString(memory, new Font("Arial", 10), Brushes.Black, new Point(160 - ((memory.ToString().Length) * 7), 405));
                        for (int i = 0; i < HolesRows; i++)
                        {

                            int HoleAddress = ((StartingAddress[i] * 400) / x) + 15;
                            int HoleSizeAddress = (((HolesSize[i] + StartingAddress[i]) * 400) / x) + 15;
                            r = new Rectangle(170, HoleAddress, 175, HoleSizeAddress - HoleAddress);
                            g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                            g.FillRectangle(new SolidBrush(Color.White), r);
                            g.DrawString(StartingAddress[i].ToString(), new Font("Arial", 10), Brushes.Black, new Point(160 - ((StartingAddress[i].ToString().Length) * 7), HoleAddress - 7));
                            g.DrawString(HolesSize[i].ToString() + "KB", new Font("Arial", 8), Brushes.Black, new Point(240, ((HoleAddress + HoleSizeAddress) / 2) - 5));


                        }
                        
                        ind = 0;
                        
                        for (int i = 0; i < ProcessRows; i++)
                        {
                           

                            if ((ProcessTable.Rows[i].Cells[1].Value != "Allocated")) 
                            {
                                Sort_Holes(HolesSize, StartingAddress, HolesRows);
                            }
                            if ((ProcessTable.Rows[i].Cells[1].Value != "De-Allocated"))
                            {
                                int flag = 0;

                                for (int j = 0; j < HolesRows; j++)
                                {

                                    if (ProcessTable.Rows[i].Cells[1].Value == "Allocated" && ProcessesSize[i] <= HolesSize[HoleIndex[ind]] )
                                    {

                                        flag = 1;

                                        HolesSize[HoleIndex[ind]] = HolesSize[HoleIndex[ind]] - ProcessesSize[i];
                                        int HoleAddress = ((StartingAddress[HoleIndex[ind]] * 400) / x) + 15;
                                        int ProcessSizeAddress = (((ProcessesSize[i] + StartingAddress[HoleIndex[ind]]) * 400) / x) + 15;
                                        ProcessAddress.Add(StartingAddress[HoleIndex[ind]]);
                                        StartingAddress[HoleIndex[ind]] += ProcessesSize[i];
                                        r = new Rectangle(170, HoleAddress, 175, ProcessSizeAddress - HoleAddress);
                                        g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                                        g.FillRectangle(new SolidBrush(Color.SkyBlue), r);
                                        g.DrawString("P" + i.ToString(), new Font("Arial", 8), Brushes.Black, new Point(245, ((HoleAddress + ProcessSizeAddress) / 2) - 5));
                                        if (HolesSize[HoleIndex[ind]] > 0)
                                        {
                                            HoleAddress = ((StartingAddress[HoleIndex[ind]] * 400) / x) + 15;
                                            int HoleSizeAddress = (((HolesSize[HoleIndex[ind]] + StartingAddress[HoleIndex[ind]]) * 400) / x) + 15;
                                            r = new Rectangle(170, HoleAddress, 175, HoleSizeAddress - HoleAddress);
                                            g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                                            g.FillRectangle(new SolidBrush(Color.White), r);
                                            g.DrawString(HolesSize[HoleIndex[ind]].ToString() + "KB", new Font("Arial", 8), Brushes.Black, new Point(240, ((HoleAddress + HoleSizeAddress) / 2) - 5));
                                        }

                                        ind++;
                                        break;
                                    }
                                    else if (ProcessesSize[i] <= HolesSize[j])
                                    {

                                        if (i != ProcessRows - 1)
                                            ind++;
                                        flag = 1;
                                        HoleIndex.Add(j);

                                        DeAlloc.Items.Add("P" + i.ToString());
                                        HolesSize[j] = HolesSize[j] - ProcessesSize[i];
                                        int HoleAddress = ((StartingAddress[j] * 400) / x) + 15;
                                        int ProcessSizeAddress = (((ProcessesSize[i] + StartingAddress[j]) * 400) / x) + 15;
                                        ProcessAddress.Add(StartingAddress[j]);
                                        StartingAddress[j] += ProcessesSize[i];
                                        r = new Rectangle(170, HoleAddress, 175, ProcessSizeAddress - HoleAddress);
                                        g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                                        g.FillRectangle(new SolidBrush(Color.SkyBlue), r);
                                        g.DrawString("P" + i.ToString(), new Font("Arial", 8), Brushes.Black, new Point(245, ((HoleAddress + ProcessSizeAddress) / 2) - 5));
                                        if (HolesSize[j] > 0)
                                        {
                                            HoleAddress = ((StartingAddress[j] * 400) / x) + 15;
                                            int HoleSizeAddress = (((HolesSize[j] + StartingAddress[j]) * 400) / x) + 15;
                                            r = new Rectangle(170, HoleAddress, 175, HoleSizeAddress - HoleAddress);
                                            g.DrawRectangle(new Pen(Brushes.Black, 2), r);
                                            g.FillRectangle(new SolidBrush(Color.White), r);
                                            g.DrawString(HolesSize[j].ToString() + "KB", new Font("Arial", 8), Brushes.Black, new Point(240, ((HoleAddress + HoleSizeAddress) / 2) - 5));
                                        }
                                        break;
                                    }

                                }
                                if (flag == 1)
                                {

                                    int flag2 = 0;
                                    for (int k = 0; k < DeAlloc.Items.Count; k++)
                                    {
                                        if (DeAlloc.Items[k].ToString() == "P" + i.ToString())
                                        { flag2 = 1; break; }
                                    }
                                    if (flag2 == 0)
                                        DeAlloc.Items.Add("P" + i.ToString());
                                    ProcessTable.Rows[i].Cells[1].Value = "Allocated";
                                }
                                else
                                    ProcessTable.Rows[i].Cells[1].Value = "Waiting";
                            }
                            else
                                ind++;
                        }

                    }
                }
                else
                    MessageBox.Show("you must choose the allocation algorithm");

        }

        void Sort_Holes(List<int> hole, List<int> address, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    if (hole[j] < hole[i])
                    {
                        int temp1 = hole[i];
                        hole[i] = hole[j];
                        hole[j] = temp1;

                        int temp2 = address[i];
                        address[i] = address[j];
                        address[j] = temp2;

                    }
                }
            }
        }

        private void MemAllc_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void MemSize_Leave(object sender, EventArgs e)
        {
            if (MemSize.Text.Length == 0)
            {
                MemSize.ForeColor = Color.Silver;
                MemSize.Text = "Enter the Size in (KB)";
            }
        }

        private void MemSize_Enter(object sender, EventArgs e)
        {
            if (MemSize.Text == "Enter the Size in (KB)")
            {
                MemSize.ForeColor = Color.Black;
                MemSize.Text = "";
            }
        }    

        private void NumProcess_Leave(object sender, EventArgs e)
        {
            if (NumProcess.Text.Length == 0)
            {
                NumProcess.ForeColor = Color.Silver;
                NumProcess.Text = "Write a Number (Ex. 5)";
            }
        }

        private void NumProcess_Enter(object sender, EventArgs e)
        {
            if (NumProcess.Text == "Write a Number (Ex. 5)")
            {
                NumProcess.ForeColor = Color.Black;
                NumProcess.Text = "";
            }
        }

        private void NumHoles_Leave(object sender, EventArgs e)
        {
            if (NumHoles.Text.Length == 0)
            {
                NumHoles.ForeColor = Color.Silver;
                NumHoles.Text = "Write a Number (Ex. 5)";
            }
        }

        private void NumHoles_Enter(object sender, EventArgs e)
        {
            if (NumHoles.Text == "Write a Number (Ex. 5)")
            {
                NumHoles.ForeColor = Color.Black;
                NumHoles.Text = "";
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            NewProcess.Enabled = false;
            ProcessClicked = false;
            HolesClicked = false;
            AllocAlgorithm.Enabled = true; ;
            AllocAlgorithm.Text = null;
            DeAlloc.Items.Clear();   
            HoleIndex.Clear();
            ProcessTable.RowCount = 0;
            HolesTable.RowCount = 0; 
            ind = 0;
            showed = 0;
            m.Close();
            MemSize.Text = "";
            MemSize.ForeColor = Color.Gray;
            MemSize.Text = "Enter the Size in (KB)";
            NumProcess.Text = "";
            NumProcess.ForeColor = Color.Gray;
            NumProcess.Text = "Write a Number (Ex. 5)";
            NumHoles.Text = "";
            NumHoles.ForeColor = Color.Gray;
            NumHoles.Text = "Write a Number (Ex. 5)";

        }

        private void GeneProcess_Click(object sender, EventArgs e)
        {
            ProcessClicked = true;
            int rows = 0;

            if (NumProcess.Text == "Write a Number (Ex. 5)")
            {
                MessageBox.Show("You must Enter the number of Processes");
            }
            else if (!int.TryParse(NumProcess.Text, out rows) || Convert.ToInt32(NumProcess.Text) <= 0)
            {

                MessageBox.Show("You must Enter a valid number of Processes");
            }
            else
            {
                rows = Convert.ToInt32(NumProcess.Text);
                ProcessTable.RowCount = rows;  

            }
        }

        private void GeneHole_Click(object sender, EventArgs e)
        {
            HolesClicked = true;
            int rows = 0;

            if (NumHoles.Text == "Write a Number (Ex. 5)")
            {
                MessageBox.Show("You must Enter the number of Holes");
            }
            else if (!int.TryParse(NumHoles.Text, out rows) || Convert.ToInt32(NumHoles.Text) <= 0)
            {

                MessageBox.Show("You must Enter a valid number of Holes");
            }
            else
            {
                rows = Convert.ToInt32(NumHoles.Text);
                HolesTable.RowCount = rows;

            }
        }

        private void ProcessTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.ProcessTable.Rows[e.RowIndex].HeaderCell.Value = "P" + e.RowIndex.ToString();
        }

        private void HolesTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.HolesTable.Rows[e.RowIndex].HeaderCell.Value = "H" + e.RowIndex.ToString();
        }

        private void Allocate_Click(object sender, EventArgs e)
        {
            
             memory = MemSize.Text;
            int memoryParsed,MemorySize = 0;

            if (memory == "Enter the Size in (KB)")
                MessageBox.Show("Please enter the memory size");
            else if (!int.TryParse(memory, out memoryParsed) || Convert.ToInt32(memory) < 0)
                MessageBox.Show("Please enter a valid memory size");
            else
                MemorySize = Convert.ToInt32(MemSize.Text);

            if (!ProcessClicked)
            {
                MessageBox.Show("you must generate the processes table and fill in the data");
            }
            else if (!HolesClicked)
            {
                MessageBox.Show("you must generate the holes table and fill in the data");
            }
            else
            {
                 List<int> ProcessesSize = new List<int>();
                 List<int> HolesSize = new List<int>(); 
                 List<int> StartingAddress = new List<int>();
                 List<int> ProcessAddress = new List<int>();
                 
                 int ProcessRows = 0;
                 int HolesRows = 0;
                 ProcessRows = ProcessTable.RowCount;
                 HolesRows = HolesTable.RowCount;
                 int checked1 = ProcessRows, checked2 = HolesRows * 2;

                
                
                 Allocating(ProcessesSize, HolesSize, StartingAddress, ProcessAddress, MemorySize, ProcessRows, HolesRows, checked1, checked2, HoleIndex);
               
            }

            
        }

        private void NewProcess_Click(object sender, EventArgs e)
        {
            ProcessTable.RowCount++;
        }

        private void DeAllocate_Click(object sender, EventArgs e)
        {
            if (DeAlloc.Items.Count == 0)
                MessageBox.Show("Allocate some Processes first");
            else
            {
                memory = MemSize.Text;
                int memoryParsed, MemorySize = 0;

                if (memory == "Enter the Size in (KB)")
                    MessageBox.Show("Please enter the memory size");
                else if (!int.TryParse(memory, out memoryParsed) || Convert.ToInt32(memory) < 0)
                    MessageBox.Show("Please enter a valid memory size");
                else
                    MemorySize = Convert.ToInt32(MemSize.Text);

                 List<int> ProcessesSize = new List<int>();
                 List<int> HolesSize = new List<int>();
                 List<int> StartingAddress = new List<int>();
                 List<int> ProcessAddress = new List<int>();

                 int ProcessRows = 0;
                 int HolesRows = 0;
                 ProcessRows = ProcessTable.RowCount;
                 HolesRows = HolesTable.RowCount;
                 int checked1 = ProcessRows, checked2 = HolesRows * 2;
                 int flag = 0;

                 int countt = DeAlloc.Items.Count;

                     for (int i = 0; i < countt; i++)
                     {
                         if (DeAlloc.GetItemChecked(i) == true)
                         {

                             int index = Convert.ToInt32(DeAlloc.Items[i].ToString().Remove(0, 1));
                             flag = 1;
                             DeAlloc.Items.RemoveAt(i);
                             i--;
                             countt--;
                             ProcessTable.Rows[index].Cells[1].Value = "De-Allocated";
                             ProcessTable.Rows[index].Cells[0].ReadOnly = true;

                             ProcessTable.Rows[index].Cells[1].Style.BackColor = Color.Silver;
                             ProcessTable.Rows[index].Cells[1].Style.SelectionBackColor = Color.Silver;
                             ProcessTable.Rows[index].Cells[1].Style.SelectionForeColor = Color.Gray;
                             ProcessTable.Rows[index].Cells[1].Style.ForeColor = Color.Gray;

                             ProcessTable.Rows[index].Cells[0].Style.BackColor = Color.Silver;
                             ProcessTable.Rows[index].Cells[0].Style.SelectionBackColor = Color.Silver;
                             ProcessTable.Rows[index].Cells[0].Style.SelectionForeColor = Color.Gray;
                             ProcessTable.Rows[index].Cells[0].Style.ForeColor = Color.Gray;


                         }

                     }
                     if (flag == 1)
                         Allocating(ProcessesSize, HolesSize, StartingAddress, ProcessAddress, MemorySize, ProcessRows, HolesRows, checked1, checked2, HoleIndex);
                     else
                         MessageBox.Show("You should choose a process to de-allocate");
            }
        }

        private void HowToUse_Click(object sender, EventArgs e)
        {
            Tips t = new Tips();
            t.Show();
        }


    }
}