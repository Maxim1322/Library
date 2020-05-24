using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace MaxDB
{
   class Query
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Library.mdb";
        OleDbConnection connection;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;
        OleDbCommand command;
        public Query()
        {
            connection = new OleDbConnection(connectionString);
           // myConnection.Open();
            bufferTable = new DataTable();
        }
        public DataTable ReadBooksOnHands()
        {
           string query = "SELECT Issue.IdIssue, Books.Title, Readers.Surname FROM Readers INNER JOIN(Books INNER JOIN Issue ON Books.[IdBook] = Issue.[IdBook]) ON Readers.[IdReader] = Issue.[IdReader];";
            connection.Open();
            dataAdapter = new OleDbDataAdapter(query, connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }
        public DataTable ReadBooks()
        {
            string query = "SELECT Books.[IdBook], Books.[Title], Books.[Autor], Books.[Instance], Books.[Reserved], Books.[Genre] FROM Books";
            connection.Open();
            dataAdapter = new OleDbDataAdapter(query, connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            
            connection.Close();
            return bufferTable;
        }
        public DataTable ReadReaders()
        {
            string query = "SELECT IdReader, Surname, Name FROM Readers; ";
            connection.Open();
            dataAdapter = new OleDbDataAdapter(query, connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }
        public DataTable ReadBooksForIs()
        {
            string query = "SELECT IdBook,  Title, Autor, Instance FROM Books";
            connection.Open();
            dataAdapter = new OleDbDataAdapter(query, connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }
        public DataTable ReadBooksByAutor(string str)
        {
            string query = "SELECT Books.[IdBook], Books.[Title], Books.[Autor], Books.[Instance], Books.[Reserved], Books.[Genre] FROM Books WHERE(((Books.[Instance]) > 0) AND((Books.[Autor]) = '" + str+"'))";
            connection.Open();
            dataAdapter = new OleDbDataAdapter(query, connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }
        public DataTable ReadBooksByGenre(string str)
        {
            string query = "SELECT Books.[Title], Books.[Autor], Books.[Instance], Books.[Genre] FROM Books WHERE(((Books.[Instance]) > 0) AND((Books.[Genre]) = '"+str+"'))";
            connection.Open();
            dataAdapter = new OleDbDataAdapter(query, connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }
        public void AddReader(string surname, string name)
        {
            connection.Open();
            string query = "INSERT INTO Readers(Surname, Name) VALUES(@Surname, @Name)";
            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("Surname", surname);
            command.Parameters.AddWithValue("Name", name);
            command.ExecuteNonQuery();
            connection.Close();
           
        }
        public void UpdateInstace(int IdBook, int Instance)
        {
            connection.Open();
            string query = "UPDATE Books SET Instance = " + Instance + " WHERE IdBook="+IdBook;
            command = new OleDbCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public bool AddIssue(int IdBook, int IdReader)
        {
            connection.Open();
            string query = "SELECT Instance FROM Books WHERE IdBook="+ IdBook;
            command = new OleDbCommand(query, connection);
            int Instance = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            if (Instance > 0)
            {
                connection.Open();
                query = "INSERT INTO Issue(IdBook, IdReader) VALUES(@IdBook, @IdReader)";
                command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("IdBook", IdBook);
                command.Parameters.AddWithValue("IdReader", IdReader);
                command.ExecuteNonQuery();
                connection.Close();
                Instance--;
                UpdateInstace(IdBook, Instance);
            }
            else
                return false; // Книги кончились
            return true;
        }

        public void ReturnBook(int IdIssue)
        {
            
            //-----------------------------------
            connection.Open();
            string query = "SELECT IdBook FROM Issue WHERE IdIssue=" + IdIssue;
            command = new OleDbCommand(query, connection);
            string text = command.ExecuteScalar().ToString();
            int IdBook = Convert.ToInt32(text);
            connection.Close();
            //-----------------------
            connection.Open();
            query = "SELECT Instance FROM Books WHERE IdBook=" + IdBook;
            command = new OleDbCommand(query, connection);
            int Instance = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            Instance++;
            //-----------------------
            connection.Open();
                query = "DELETE FROM Issue WHERE IdIssue="+ IdIssue;
                command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
               UpdateInstace(IdBook, Instance);

        }
        public void AddBook(string Title, string Autor, int Instance, string Genre)
        {
            connection.Open();
            string query = "INSERT INTO Books(Title, Autor, Instance, Reserved, Genre) VALUES(@Title, @Autor, @Instance, @Reserved, @Genre)";
            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("Title", Title);
            command.Parameters.AddWithValue("Autor", Autor);
            command.Parameters.AddWithValue("Instance", Instance);
            command.Parameters.AddWithValue("Reserved", 0);
            command.Parameters.AddWithValue("Genre", Genre);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public void AddIssue(string Title, string Autor, int Instance, string Genre)
        {
            connection.Open();
            string query = "INSERT INTO Books(Title, Autor, Instance, Reserved, Genre) VALUES(@Title, @Autor, @Instance, @Reserved, @Genre)";
            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("Title", Title);
            command.Parameters.AddWithValue("Autor", Autor);
            command.Parameters.AddWithValue("Instance", Instance);
            command.Parameters.AddWithValue("Reserved", 0);
            command.Parameters.AddWithValue("Genre", Genre);
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}
