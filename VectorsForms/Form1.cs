using System.Data.SqlClient;
using System.Data;
using System;

namespace VectorsForms
{
    public partial class Form1 : Form
    {
        VectorMapper vectorMapper;
        TriangleMapper triangleMapper;
        public Form1()
        {
            InitializeComponent();
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            vectorMapper = new VectorMapper();
            triangleMapper = new TriangleMapper();
            CreateColumns();
            updateGridVectors();
            updateGridTriangles();
        }        
        public void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("x", "x");
            dataGridView1.Columns.Add("y", "y");

            triangleDataGridView.Columns.Add("id", "id");
            triangleDataGridView.Columns.Add("v1_id", "v1_id");
            triangleDataGridView.Columns.Add("x", "x");
            triangleDataGridView.Columns.Add("y", "y");
            triangleDataGridView.Columns.Add("v2_id", "v2_id");
            triangleDataGridView.Columns.Add("x", "x");
            triangleDataGridView.Columns.Add("y", "y");
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            string x=Convert.ToString(vectorAddX.Text);
            string y= Convert.ToString(vectorAddY.Text);

            List<string> par = new List<string>();
            par.Add(x);par.Add(y);
            Vector v = new Vector(par);

            vectorMapper.Insert(v);
            updateGridVectors();
        }        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        public void updateGridVectors()
        {
            dataGridView1.Rows.Clear();
            List<Vector> vectors = vectorMapper.SelectAll();
            for(int i = 0; i < vectors.Count(); i++)
            {
                dataGridView1.Rows.Add(vectors[i]._id, vectors[i]._x, vectors[i]._y);
            }            
        }
        public void updateGridTriangles()
        {
            triangleDataGridView.Rows.Clear();
            List<Triangle> triangles = triangleMapper.SelectAll();
            for (int i = 0; i < triangles.Count(); i++)
            {
                triangleDataGridView.Rows.Add(triangles[i]._id, triangles[i].v1._id, 
                    triangles[i].v1._x, triangles[i].v1._y, 
                    triangles[i].v2._id, triangles[i].v2._x, triangles[i].v2._y);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textDelById_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(vectorDelById.Text);
            if (!vectorMapper.Delete(id))
            {
                MessageBox.Show("������ �� ������, ��������� id","DELETE");
            }
            updateGridVectors();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string x = Convert.ToString(vectorUpdateX.Text);
            string y = Convert.ToString(vectorUpdateY.Text);
            int id = Convert.ToInt32(vectorUpdateById.Text);

            List<string> par = new List<string>();
            par.Add(x); par.Add(y);
            Vector v = new Vector(par);

            if (!vectorMapper.Update(id, v))
            {
                MessageBox.Show("������ �� ������, ��������� id", "UPDATE");
            }
            updateGridVectors();
        }

        private void triangleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string v1_id = Convert.ToString(triangleAddX.Text);
            string v2_id = Convert.ToString(triangleAddY.Text);

            List<string> par = new List<string>();
            par.Add(v1_id); par.Add(v1_id);
            Triangle t = new Triangle(par);
            try
            {
                triangleMapper.Insert(t);
            }
            catch (Exception ex)
            {
                MessageBox.Show("����� �������� ��� � ����, ��������� id", "INSERT");
            }
            
            updateGridTriangles();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(triangleDelById.Text);
            if (!triangleMapper.Delete(id))
            {
                MessageBox.Show("����������� �� ������, ��������� id", "DELETE");
            }
            updateGridTriangles();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string v1_id = Convert.ToString(triangleUpdateX.Text);
            string v2_id = Convert.ToString(triangleUpdateY.Text);
            int id = Convert.ToInt32(triangleUpdateById.Text);

            List<string> par = new List<string>();
            par.Add(v1_id); par.Add(v1_id);
            Triangle t = new Triangle(par);

            if (!triangleMapper.Update(id, t))
            {
                MessageBox.Show("����������� �� ������, ��������� id", "UPDATE");
            }
            updateGridTriangles();
        }

        private void triangleAddX_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}