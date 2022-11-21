﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Relationship_manager_administration_system
{
    class DatabaseClass
    {
        private static SqlConnection connection = new SqlConnection("Server=tcp:rmas-server.database.windows.net,1433;Initial Catalog=RelationshipManagerAdministrationSystemDB;Persist Security Info=False;User ID=FreddieFaulkner;Password=Goonerfred03;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public static DataTable GetPotentialUser(string username, string role) {
            DataTable potentialUser = new DataTable();
            SqlDataAdapter adapter;

            connection.Open();
            if (role.Equals("Relationship Manager"))
            {
                adapter = new SqlDataAdapter(@"SELECT rmID, Email, [Password] FROM [dbo].[tblRelationshipManagers] WHERE Email = '" + username + "'", connection);
            }
            else {
                adapter = new SqlDataAdapter(@"SELECT icID, email, [password] FROM [dbo].[tblIdeaCreator] WHERE Email = '" + username + "'", connection);
            }

            adapter.Fill(potentialUser);
            connection.Close();

            Debug.WriteLine("getPotentialUser ran");

            return potentialUser;
        }

        public static DataTable GetClients(int rmid) {
            DataTable clients = new DataTable();

            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT ClientID, FirstName, LastName, Email, Company, Phone FROM[dbo].[tblClients] WHERE rmID = '" + rmid + "'", connection);
            adapter.Fill(clients);
            connection.Close();

            return clients;
        }

        public static void UpdateClientData(int clientReference, string client, string email, string contactFirst, string contactLast, string contactNumber) {
            try {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[tblClients] SET Company='" + client + "', Email='" + email + "', FirstName='" + contactFirst + "', LastName='" + contactLast + "', Phone='" + contactNumber + "' WHERE clientID ='" + clientReference + "'", connection);
                command.ExecuteNonQuery();
            }
            catch {
                Debug.WriteLine("Empty data fields!");
            }

            connection.Close();

        }

        public static void DeleteClient(int clientReference) {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[tblClients] WHERE ClientID= '" + clientReference + "'", connection);
                command.ExecuteNonQuery();
            }
            catch {
                Debug.WriteLine("Empty Data fields!");
            }

            connection.Close();
        }

        public static DataTable getClientEmails() {
            DataTable emails = new DataTable();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT Email FROM [dbo].[tblClients]", connection);
            adapter.Fill(emails);
            connection.Close();
            return emails;
        }

        public static void createClient(string client, string email, string contactFirstName, string contactLastName, string contactNumber, int rmID) {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[tblClients] (FirstName, LastName, Email, Phone, Company, rmID) VALUES ('" + contactFirstName + "', '" + contactLastName + "', '" + email + "', '" + contactNumber + "', '" + client + "', '" + rmID + "');", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
