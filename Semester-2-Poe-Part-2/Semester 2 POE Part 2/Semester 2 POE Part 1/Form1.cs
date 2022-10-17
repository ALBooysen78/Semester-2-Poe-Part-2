using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semester_2_POE_Part_1
{
    public partial class Form1 : Form
    {
        GameEngine engine;  //declarations
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //creates game engine object, displays the map
        {
            engine = new GameEngine();            

            DisplayMap();

            engine.getMap().GetEnemies();

            string[] entires = new string[engine.getMap().GetEnemies().Length]; //getting string array of eneimes on form load
            
            for (int i = 0; i < entires.Length; i++) //drop down menu entries
            {
                entires[i] = engine.getMap().GetEnemies()[i].ToString();
                SelectEnemyDropDownList.Items.Add(entires[i]); //adding entires to drop down menu on form load
            }



        }

        private void EnemyStatsTextbox_TextChanged(object sender, EventArgs e)
        {
            
            //EnemyStatsTextbox.Text += "/n";
            //EnemyStatsTextbox.Text += engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].ToString();
            
        }

        private void attackEnemyButton_Click(object sender, EventArgs e)
        {
            if(SelectEnemyDropDownList.SelectedIndex == -1)
            {
                return; // to catch any errors if nothing in entered
            }
            try
            {
                if (engine.getMap().Heroprop.CheckRange(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex]) == true)
                {   //to attack an enemy if one is selected and in range
                    engine.getMap().Heroprop.Attack(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex]);
                    EnemyStatsTextbox.Text = "Attack Success!\n";

                    EnemyStatsTextbox.Text += engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].ToString();
                    if(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].isDead()== true)     //removes dead enemy symbols from the map and updates the map display
                    {
                        engine.getMap().GetMap()[engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].X, engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].Y] = new EmptyTile(engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].X, engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].Y, ". ");
                        DisplayMap();
                        engine.getMap().UpdateVision(engine.getMap().Heroprop);
                        EnemyStatsTextbox.Text += "\nEnemy was killed";
                    }

                }
                else
                {   // if no enemy is in range
                    EnemyStatsTextbox.Text = "Attack Failed, enemy not in range";
                }
            }
            catch(IndexOutOfRangeException)
            {   //if trying to attack an enemy thats dead
                EnemyStatsTextbox.Text = "Enemy is unalived";
            }
            

            RemoveEnemies();
            engine.EnemyAttacks();
            RemoveEnemies();
            EnemyDropdown();
            DisplayMap();

        }

        private void SelectEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnemyStatsTextbox.Text = engine.getMap().GetEnemies()[SelectEnemyDropDownList.SelectedIndex].ToString();

            //add iteams to the iteam array
            //update ++ update on attack
            //if (SelectEnemyDropDownList.Text == "Swamp Creature")
            //{
            //idk man f this
            //}
        }



        private void DisplayMap()   //method to display map with symbols in a textbox
        {
            mapDisplayTextBox.Clear();
            for (int i = 0; i < engine.getMap().GetMapHeight(); i++)
            {
                for (int j = 0; j < engine.getMap().GetMapWidth(); j++)
                {
                    mapDisplayTextBox.Text += engine.getMap().GetSymbol(i, j);
                }
                mapDisplayTextBox.Text += Environment.NewLine;
            }

            playerStatsLabel.Text = engine.getMap().Heroprop.ToString();
        }

        private void upButton_Click(object sender, EventArgs e) //moves hero up 
        {
            engine.MovePlayer(Character.movement.up);
            engine.MoveEnemies();
            engine.EnemyAttacks();
            RemoveEnemies();
            //CheckEnemyStatus();
            DisplayMap();
            EnemyDropdown();

        }

        private void downButton_Click(object sender, EventArgs e)   //moves hero down
        {
            engine.MovePlayer(Character.movement.down);
            engine.MoveEnemies();
            engine.EnemyAttacks();
            RemoveEnemies();
            //CheckEnemyStatus();
            DisplayMap();
            EnemyDropdown();
        }

        private void rightButton_Click(object sender, EventArgs e)  //moves hero right
        {
            engine.MovePlayer(Character.movement.right);
            engine.MoveEnemies();
            engine.EnemyAttacks();
            RemoveEnemies();
            //CheckEnemyStatus();
            DisplayMap();
            EnemyDropdown();
        }
        private void leftButton_Click(object sender, EventArgs e)   //moves hero left
        {
            engine.MovePlayer(Character.movement.left);
            engine.MoveEnemies();
            engine.EnemyAttacks();
            RemoveEnemies();
            //CheckEnemyStatus();
            DisplayMap();
            EnemyDropdown();
        }

        private void EnemyDropdown()
        {
           
            for (int i = 0; i < SelectEnemyDropDownList.Items.Count; i++) //drop down menu entries
            {
                SelectEnemyDropDownList.Items[i] = engine.getMap().GetEnemies()[i].ToString();
            }

        }

        private void RemoveEnemies()                        //check if enemies are dead, if they are dead create a new array without the dead ones
                                                            //set enemies method to overwrite the eneimes array + update combobox
        {
            int tmp = 0;

            for (int i = 0; i < engine.getMap().GetEnemies().Length; i++)
            {
                if (engine.getMap().GetEnemies()[i].isDead() == true)
                {
                    tmp++;
                }
            }

            if (tmp != 0)
            {
               
                Enemy[] noDeadEnemies = new Enemy[engine.getMap().GetEnemies().Length - tmp];
                int j = 0;
                for (int i = 0; i < engine.getMap().GetEnemies().Length; i++)
                {
                    //add all elements into new array except the dead one
                    if(engine.getMap().GetEnemies()[i].isDead() == false)
                    {
                        noDeadEnemies[j] = engine.getMap().GetEnemies()[i];
                        j++;
                    }
                }

                engine.getMap().SetEnemies(noDeadEnemies); //update the array to be the living enemies

                string[] entires = new string[engine.getMap().GetEnemies().Length]; //drop down menu entries

                SelectEnemyDropDownList.Items.Clear();

                for (int i = 0; i < entires.Length; i++)
                {
                    entires[i] = engine.getMap().GetEnemies()[i].ToString();
                    SelectEnemyDropDownList.Items.Add(entires[i]);
                }

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {

        }
    }
}
